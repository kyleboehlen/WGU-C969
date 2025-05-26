using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DAO;
using WGUD969.Models;
using WGUD969.Database.DTO;
using WGUD969.Factories;

namespace WGUD969.Database.Repositories
{
    public interface IAppointmentRepository
    {
        public Task CreateAsync(IAppointment appointment);
        public Task<List<IAppointment>> GetAllWithCustomerAsync();
        public Task<bool> DeleteAsync(IAppointment appointment);
    }

    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IDAO<AppointmentDTO> _AppointmentDAO;
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IAppointmentFactory _AppointmentFactory;

        public AppointmentRepository(IDAO<AppointmentDTO> appointmentDAO, ICustomerRepository customerRepository, IAppointmentFactory appointmentFactory)
        {
            _AppointmentDAO = appointmentDAO;
            _CustomerRepository = customerRepository;
            _AppointmentFactory = appointmentFactory;
        }

        public async Task CreateAsync(IAppointment appointment)
        {
            AppointmentDTO appointmentDTO = appointment.ToDTO();
            await _AppointmentDAO.CreateAsync(appointmentDTO);
        }

        public async Task<List<IAppointment>> GetAllWithCustomerAsync()
        {
            List<ICustomer> customers = await _CustomerRepository.GetAllWithAddressesAsync();
            List<AppointmentDTO> appointmentDTOs = await _AppointmentDAO.GetAllAsync() as List<AppointmentDTO>;
            return appointmentDTOs.Select(a =>
            {
                IAppointment appointment = _AppointmentFactory.GetDefaultModel();
                appointment.Initialize(a);
                appointment.HydrateCustomer(customers);
                return appointment;
            }).ToList();
        }

        public async Task<bool> DeleteAsync(IAppointment appointment)
        {
            return await _AppointmentDAO.DeleteByIdAsync(appointment.Id);
        }
    }
}
