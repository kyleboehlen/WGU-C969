using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WGUD969.Database.Repositories;
using WGUD969.Models;

namespace WGUD969.Forms
{
    public partial class CityForm : Form
    {
        private readonly ICityRepository _CityRepository;
        public CityForm(ICityRepository cityRepository)
        {
            _CityRepository = cityRepository;
            InitializeComponent();
            validateRequiredTextBox();
        }

        private void OnTextBoxValueChange(object sender, EventArgs e)
        {
            validateRequiredTextBox();
        }

        // With only 2 fields on this form there is no reason to get any fancier than this
        private void validateRequiredTextBox()
        {

            int requiredFields = 2;
            if (string.IsNullOrEmpty(txtCity.Text))
            {
                txtCity.BackColor = Color.Salmon;
            }
            else
            {
                txtCity.BackColor = SystemColors.Window;
                requiredFields--;
            }

            if (string.IsNullOrEmpty(txtCountry.Text))
            {
                txtCountry.BackColor = Color.Salmon;
            }
            else
            {
                txtCountry.BackColor = SystemColors.Window;
                requiredFields--;
            }

            btnCitySave.Enabled = requiredFields == 0;
        }

        private async void btnCitySave_Click(object sender, EventArgs e)
        {
            ICity newCity = await _CityRepository.CreateAsync(txtCity.Text, txtCountry.Text);
            // We're specifically triggering an event saying that the form has been saved, as opposed to having an event
            // whenever a city is created. The dashboard is interested in when THIS form with THIS user creates a city. 
            // But, because this runs locally we don't have to worry about specifying user just that the event was trigger here.
            // TODO: trigger event
            Close();
        }
    }
}
