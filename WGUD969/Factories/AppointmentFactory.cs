using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WGUD969.Database.DTO;
using WGUD969.Models;
using WGUD969.Services;

namespace WGUD969.Factories
{
    public interface IAppointmentFactory : IDefaultDTOFactory<AppointmentDTO>, IDefaultModelFactory<IAppointment>
    { }
    public class AppointmentFactory : IAppointmentFactory
    {
        private readonly IAuthService _AuthService;
        private readonly IServiceProvider _ServiceProvider;

        public AppointmentFactory(IAuthService authService, IServiceProvider serviceProvider)
        {
            _AuthService = authService;
            _ServiceProvider = serviceProvider;
        }
        public AppointmentDTO GetDefaultDTOWithReqs()
        {
            return new AppointmentDTO
            {
                appointmentId = 0,
                customerId = 0,
                userId = 0,
                title = "not needed",
                description = "not needed",
                type = "Presentation",
                location = "not needed",
                contact = "not needed",
                url = "not needed",
                start = DateTime.Now,
                end = DateTime.Now,
                createdBy = "AppointmentFactory.CreateDefaultDTOWithReqs()",
                lastUpdateBy = "AppointmentFactory.CreateDefaultDTOWithReqs()"
            };
        }

        public IAppointment GetDefaultModel()
        {
            string username = _AuthService?.User?.Username ?? "AppointmentFactory.GetDefaultModel()";
            int userId = _AuthService?.User?.Id ?? 0;
            AppointmentDTO appointmentDTO = GetDefaultDTOWithReqs();
            appointmentDTO.userId = userId;
            appointmentDTO.createdBy = username;
            appointmentDTO.lastUpdateBy = username;
            IAppointment appointment = _ServiceProvider.GetRequiredService<IAppointment>();
            appointment.Initialize(appointmentDTO);
            return appointment;
        }
    }
}
