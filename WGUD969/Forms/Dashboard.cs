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
        private ICustomer _Customer;
        private IAddress _Address;
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
            _Customer = _CustomerFactory.GetDefaultModel();
            _Address = _AddressFactory.GetDefaultModel();
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            await SetCityList();
            validateRequiredTextBox();
            await RefreshCustomerList();
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

        private async Task RefreshCustomerList()
        {
            dgvCustomers.Rows.Clear();
            List<ICustomer> customers = await _CustomerRepository.GetAllWithAddressesAsync();
            foreach(ICustomer customer in customers)
            {
                int rowIndex = dgvCustomers.Rows.Add();
                UpdateDGVRow(customer, rowIndex);
            }
        }

        public void UpdateDGVRow(ICustomer customer, int? index = null)
        {
            index = index ?? dgvCustomers.SelectedRows[0].Index;

            DataGridViewRow row = dgvCustomers.Rows[(int)index];

            row.Cells["Name"].Value = customer.Name;
            row.Cells["PhoneNumber"].Value = customer.Address.PhoneNumber;
            row.Cells["City"].Value = customer.Address.City.Name;
            row.Cells["PostalCode"].Value = customer.Address.PostalCode;

            row.Tag = customer;
        }

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                _Customer = dgvCustomers.SelectedRows[0].Tag as Customer ?? _Customer;
                _Address = _Customer.Address ?? _Address;
                UpdateCustomerFormValues();
            }
        }

        private void UpdateCustomerFormValues()
        {
            txtCustomerName.Text = _Customer.Name;
            txtPhoneNumber.Text = _Address.PhoneNumber;
            txtLine1.Text = _Address.Line1;
            txtLine2.Text = _Address.Line2;
            txtZipCode.Text = _Address.PostalCode;
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            _ServiceProvider.GetRequiredService<CityForm>().Show();
        }

        private async void btnCustomerSave_Click(object sender, EventArgs e)
        {
            _Customer.Name = txtCustomerName.Text;

            _Address = _AddressFactory.GetDefaultModel();

            _Address.PhoneNumber = txtPhoneNumber.Text;
            _Address.Line1 = txtLine1.Text;
            _Address.Line2 = txtLine2.Text;

            ICity selectedCity = await _CityRepository.GetCityByIdAsync(int.Parse(cmbCity.SelectedValue.ToString()));
            _Address.HydrateCity(selectedCity);

            _Address.PostalCode = txtZipCode.Text;

            _Customer = await _CustomerRepository.CreateOrUpdateWithAddressAsync(_Customer, _Address);
            _Address = _Customer.Address;

            UpdateCustomerFormValues();
            await RefreshCustomerList();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            _Customer = _CustomerFactory.GetDefaultModel();
            _Address = _AddressFactory.GetDefaultModel();

            UpdateCustomerFormValues();
        }
    }
}
