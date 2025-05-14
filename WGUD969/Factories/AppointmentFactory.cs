using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DTO;
using WGUD969.Models;

namespace WGUD969.Factories
{
    public interface IAppointmentFactory : IDefaultDTOFactory<AppointmentDTO>, IDefaultModelFactory<IAppointment>
    { }
    public class AppointmentFactory
    {
    }
}
