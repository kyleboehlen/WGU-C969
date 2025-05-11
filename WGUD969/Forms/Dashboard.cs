using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using WGUD969.Services;

namespace WGUD969.Forms
{
    public partial class Dashboard : Form
    {
        private readonly IServiceProvider _ServiceProvider;
        private readonly ICityService _CityService;
        public Dashboard(IServiceProvider serviceProvider, ICityService cityService)
        {
            _ServiceProvider = serviceProvider;
            InitializeComponent();
            _CityService = cityService;
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            await SetCityList();
        }

        private async Task SetCityList(int? cityId = null)
        {
            var cityLabelDict = await _CityService.GetCityLabelsAsync();
            cmbCity.Items.Clear();
            cmbCity.DataSource = cityLabelDict.Select(x => new { Id = x.Key, Name = x.Value }).ToList();
            cmbCity.DisplayMember = "Name";
            cmbCity.ValueMember = "Id";
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            _ServiceProvider.GetRequiredService<CityForm>().Show();
        }
    }
}
