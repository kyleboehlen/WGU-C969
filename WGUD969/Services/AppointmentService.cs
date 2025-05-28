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
        public Task<bool> HasAppointmentWithin15Minutes();
        public Task<Dictionary<IUser, List<IAppointment>>> GetAppointmentsByUser();
        public Task<Dictionary<ICustomer, int>> GetNumberOfAppointmentsByCustomer();
        public Task<Dictionary<string, int>> GetNumberOfAppointmentsByMonth();
    }
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _AppointmentRepository;
        private readonly ITimezoneService _TimeZoneService;
        private readonly IUserRepository _UserRepository;
        private readonly ICustomerRepository _CustomerRepository;
        private List<IAppointment> _Appointments;

        public AppointmentService(IAppointmentRepository appointmentRepository, ITimezoneService timeZoneService, IUserRepository userRepository, ICustomerRepository customerRepository)
        {
            _AppointmentRepository = appointmentRepository;
            _TimeZoneService = timeZoneService;
            _UserRepository = userRepository;
            _CustomerRepository = customerRepository;
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

        public async Task<bool> HasAppointmentWithin15Minutes()
        {
            await Refresh();
            List<IAppointment> todaysAppointments = await FilterByDate(DateTime.Now);
            return todaysAppointments.Where(a =>
            {
                TimeSpan diff = DateTime.Now - a.Start;
                return diff <= TimeSpan.FromMinutes(15);
            }).ToList().Count > 0;
        }

        public async Task<Dictionary<ICustomer, int>> GetNumberOfAppointmentsByCustomer()
        {
            await Refresh();
            return (await Task.WhenAll(_Appointments
                .GroupBy(a => a.CustomerId)
                .Select(async group => new { Customer = await _CustomerRepository.GetByIdAsync(group.Key), Count = group.Count() })))
                .Where(x => x.Customer != null)
                .ToDictionary(x => x.Customer!, x => x.Count);
        }

        public async Task<Dictionary<IUser, List<IAppointment>>> GetAppointmentsByUser()
        {
            await Refresh();
            return (await Task.WhenAll(_Appointments
                .GroupBy(a => a.UserId)
                .Select(async group => new { User = await _UserRepository.GetByIdAsync(group.Key), Appointments = group.ToList() })))
                .Where(x => x.User != null)
                .ToDictionary(x => x.User!, x => x.Appointments);
        }

        public async Task<Dictionary<string, int>> GetNumberOfAppointmentsByMonth()
        {
            await Refresh();
            return _Appointments
                .GroupBy(a => a.Start.ToString("MMMM"))
                .ToDictionary(
                    group => group.Key,
                    group => group.Count()
                );
        }
    }
}
