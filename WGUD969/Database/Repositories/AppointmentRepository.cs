using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DAO;
using WGUD969.Models;
using WGUD969.Database.DTO;

namespace WGUD969.Database.Repositories
{
    public interface IAppointmentRepository
    {
        public Task CreateAsync(IAppointment appointment);
    }

    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IDAO<AppointmentDTO> _AppointmentDAO;

        public AppointmentRepository(IDAO<AppointmentDTO> appointmentDAO)
        {
            _AppointmentDAO = appointmentDAO;
        }

        public async Task CreateAsync(IAppointment appointment)
        {
            AppointmentDTO appointmentDTO = appointment.ToDTO();
            await _AppointmentDAO.CreateAsync(appointmentDTO);
        }
    }
}
