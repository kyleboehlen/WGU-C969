using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.Repositories;
using WGUD969.Models;

namespace WGUD969.Services
{
    public interface IAppointmentService
    {
        public Task Refresh();
        public Task<List<IAppointment>> FilterByDate(DateTime? date);
        public Task<bool> HasOverlappingAppointments(DateTime dateTime);
    }
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _AppointmentRepository;
        private readonly ITimezoneService _TimeZoneService;
        private List<IAppointment> _Appointments;

        public AppointmentService(IAppointmentRepository appointmentRepository, ITimezoneService timeZoneService)
        {
            _AppointmentRepository = appointmentRepository;
            _TimeZoneService = timeZoneService;
        }

        public async Task Refresh()
        {
            _Appointments = await _AppointmentRepository.GetAllWithCustomerAsync();
        }

        public async Task<List<IAppointment>> FilterByDate(DateTime? date)
        {
            await Refresh();
            if (date == null)
            {
                return _Appointments;
            }
            
            return _Appointments.Where(a => a.Start.Date == date.Value.Date).ToList();
        }

        public async Task<bool> HasOverlappingAppointments(DateTime dateTime)
        {
            await Refresh();
            return _Appointments.Where(a => dateTime > a.Start && dateTime < a.End).ToList().Count() > 0;
        }
    }
}
