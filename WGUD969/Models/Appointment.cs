using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DTO;

namespace WGUD969.Models
{
    public interface IAppointment : IModelToDTO<AppointmentDTO>, IModelChangeAudit
    { }
    public class Appointment : IAppointment
    {
        public DateTime? CreatedOn => throw new NotImplementedException();

        public DateTime? UpdatedOn => throw new NotImplementedException();

        public string CreatedBy => throw new NotImplementedException();

        public string UpdatedBy => throw new NotImplementedException();

        public void Initialize(AppointmentDTO dto)
        {
            throw new NotImplementedException();
        }

        public AppointmentDTO ToDTO()
        {
            throw new NotImplementedException();
        }
    }
}
