using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WGUD969.Database.Repositories;
using WGUD969.Factories;
using WGUD969.Models;
using WGUD969.Services;

namespace WGUD969.Forms
{
    public partial class AppointmentForm : Form
    {
        private readonly ICityService _CityService;
        private readonly ICustomerService _CustomerService;
        private readonly IAppointmentRepository _AppointmentRepository;
        private readonly IAppointmentFactory _AppointmentFactory;
        private IAppointment _Appointment;

        public AppointmentForm(ICityService cityService, ICustomerService customerService, IAppointmentRepository appointmentRepository,
            IAppointmentFactory appointmentFactory)
        {
            _CityService = cityService;
            _CustomerService = customerService;
            _AppointmentRepository = appointmentRepository;
            _AppointmentFactory = appointmentFactory;
            _Appointment = _AppointmentFactory.GetDefaultModel();

            InitializeComponent();

        }

        public async void Form_Load(object sender, EventArgs e)
        {
            await SetCustomerList();
            await SetCityList();
        }

        private async Task SetCustomerList()
        {
            var customerLabelDict = await _CustomerService.GetCustomerLabelsAsync();
            if (cmbCustomer.DataSource == null)
            {
                cmbCustomer.Items.Clear();
            }

            cmbCustomer.DataSource = customerLabelDict.Select(x => new { Id = x.Key, Name = x.Value }).ToList();

            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.ValueMember = "Id";
        }

        private async Task SetCityList()
        {
            var cityLabelDict = await _CityService.GetCityLabelsAsync();
            if (cmbLocationCity.DataSource == null)
            {
                cmbLocationCity.Items.Clear();
            }

            cmbLocationCity.DataSource = cityLabelDict.Select(x => new { Id = x.Key, Name = x.Value }).ToList();

            cmbLocationCity.DisplayMember = "Name";
            cmbLocationCity.ValueMember = "Id";
        }

        private void rabInPerson_CheckedChanged(object sender, EventArgs e)
        {
            cmbLocationCity.Enabled = rabInPerson.Checked;
            txtVirtualMeetingURL.Enabled = rabVirtually.Checked;

            if (!cmbLocationCity.Enabled)
            {
                cmbLocationCity.SelectedIndex = -1;
            }
            else
            {
                cmbLocationCity.SelectedIndex = 0;
            }

            if (!txtVirtualMeetingURL.Enabled)
            {
                txtVirtualMeetingURL.Text = "";
            }

            RunValidation(sender, e);
        }

        private void RunValidation(object sender, EventArgs e)
        {
            int validationErrors = 0;
            if (cmbCustomer.SelectedIndex < 0)
            {
                validationErrors++;
                cmbCustomer.BackColor = Color.Salmon;
            }
            else
            {
                cmbCustomer.BackColor = SystemColors.Window;
            }

            if (new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday }.Contains(dtpDate.Value.DayOfWeek))
            {
                validationErrors++;
                lblDate.ForeColor = Color.Salmon;
            }
            else
            {
                lblDate.ForeColor = Color.Black;
            }

            // Check for start time before end time, not between 9-5 EST, overlapping appointments

            if (cmbAppointmentType.SelectedIndex < 0)
            {
                validationErrors++;
                lblType.ForeColor = Color.Salmon;
            }
            else
            {
                lblType.ForeColor = Color.Black;
            }

            if (rabInPerson.Checked && cmbLocationCity.SelectedIndex < 0)
            {
                validationErrors++;
                rabInPerson.BackColor = Color.Salmon;
            }
            else
            {
                rabInPerson.BackColor = SystemColors.Window;
            }

            if (rabVirtually.Checked && txtVirtualMeetingURL.Text.Length < 1)
            {
                validationErrors++;
                txtVirtualMeetingURL.BackColor = Color.Salmon;
            }
            else
            {
                txtVirtualMeetingURL.BackColor = SystemColors.Window;
            }

            btnSave.Enabled = validationErrors == 0;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            _Appointment.CustomerId = int.Parse(cmbCustomer.SelectedValue.ToString());
            _Appointment.Start = dtpDate.Value.Date + dtpStartTime.Value.TimeOfDay;
            _Appointment.End = dtpDate.Value.Date + dtpEndTime.Value.TimeOfDay;
            _Appointment.Type = cmbAppointmentType.SelectedText;
            _Appointment.CityLocation = rabInPerson.Checked ? cmbLocationCity.SelectedText : "not needed";
            _Appointment.URL = rabVirtually.Checked ? txtVirtualMeetingURL.Text : "not needed";
            _Appointment.Description = rtbAppointmentDetails.Text;
            await _AppointmentRepository.CreateAsync(_Appointment);
            this.Close();
        }
    }
}
