using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using WGUD969.Database.Repositories;
using WGUD969.Factories;
using WGUD969.Services;
using WGUD969.Models;

namespace WGUD969.Forms
{
    public partial class Dashboard : Form
    {
        private readonly IServiceProvider _ServiceProvider;
        private readonly ICityService _CityService;
        private readonly ICityRepository _CityRepository;
        private readonly ICustomerFactory _CustomerFactory;
        private readonly IAddressFactory _AddressFactory;
        private readonly ICustomerRepository _CustomerRepository;
        private List<TextBox> requiredTextFields = new List<TextBox>();
        public Dashboard(IServiceProvider serviceProvider, ICityService cityService, ICityRepository cityRepository,
            ICustomerFactory customerFactory, IAddressFactory addressFactory, ICustomerRepository customerRepository)
        {
            _ServiceProvider = serviceProvider;
            _CityService = cityService;
            _CityRepository = cityRepository;
            _CustomerFactory = customerFactory;
            _AddressFactory = addressFactory;
            _CustomerRepository = customerRepository;
            InitializeComponent();
            // Subcribing to new cities
            _CityRepository.CityAdded += CityRepository_CityAdded;
            // Setting all of our required text fields for easy iterative validation
            requiredTextFields.Add(txtCustomerName);
            requiredTextFields.Add(txtPhoneNumber);
            requiredTextFields.Add(txtLine1);
            requiredTextFields.Add(txtZipCode);
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            await SetCityList();
            validateRequiredTextBox();
        }

        private void OnTextBoxValueChange(object sender, EventArgs e)
        {
            validateRequiredTextBox();
        }

        private void validateRequiredTextBox()
        {
            int requiredFieldsLeft = requiredTextFields.Select(tf =>
            {
                if (string.IsNullOrEmpty(tf.Text))
                {
                    tf.BackColor = Color.Salmon;
                    return 1;
                }
                else
                {
                    tf.BackColor = SystemColors.Window;
                    return 0;
                }
            }).Sum(x => x);

            btnCustomerSave.Enabled = requiredFieldsLeft == 0;
        }

        // CITY STUFF
        private async Task CityRepository_CityAdded(object sender, CityEventArgs e)
        {
            await SetCityList(e.CityId);
        }

        private async Task SetCityList(int? cityId = null)
        {
            var cityLabelDict = await _CityService.GetCityLabelsAsync();
            if (cmbCity.DataSource == null)
            {
                cmbCity.Items.Clear();
            }
            cmbCity.DataSource = cityLabelDict.Select(x => new { Id = x.Key, Name = x.Value }).ToList();
            cmbCity.DisplayMember = "Name";
            cmbCity.ValueMember = "Id";
            if (cityId != null)
            {
                cmbCity.SelectedValue = (int)cityId;

            }
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            _ServiceProvider.GetRequiredService<CityForm>().Show();
        }

        private async void btnCustomerSave_Click(object sender, EventArgs e)
        {
            ICustomer newCustomer = _CustomerFactory.GetDefaultModel();
            newCustomer.Name = txtCustomerName.Text;
            IAddress newAddress = _AddressFactory.GetDefaultModel();
            newAddress.PhoneNumber = txtPhoneNumber.Text;
            newAddress.Line1 = txtLine1.Text;
            newAddress.Line2 = txtLine2.Text;
            ICity selectedCity = await _CityRepository.GetCityByIdAsync(int.Parse(cmbCity.SelectedValue.ToString()));
            newAddress.HydrateCity(selectedCity);
            newAddress.PostalCode = txtZipCode.Text;
            newCustomer = await _CustomerRepository.CreateOrUpdateWithAddressAsync(newCustomer, newAddress);
            // TODO - refresh the customer list, pass the customer id to set it as selected
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            // TODO: clear form and unselect customer from right list
        }
    }
}
