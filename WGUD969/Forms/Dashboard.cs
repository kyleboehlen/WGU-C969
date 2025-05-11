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
using WGUD969.Services;

namespace WGUD969.Forms
{
    public partial class Dashboard : Form
    {
        private readonly IServiceProvider _ServiceProvider;
        private readonly ICityService _CityService;
        private readonly ICityRepository _CityRepository;
        public Dashboard(IServiceProvider serviceProvider, ICityService cityService, ICityRepository cityRepository)
        {
            _ServiceProvider = serviceProvider;
            _CityService = cityService;
            _CityRepository = cityRepository;
            InitializeComponent();
            // Subcribing to new cities
            _CityRepository.CityAdded += CityRepository_CityAdded;
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            await SetCityList();
        }

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
    }
}
