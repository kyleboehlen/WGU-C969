using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DTO;
using WGUD969.Factories;

namespace WGUD969.Models
{
    public interface IAppointment : IModelToDTO<AppointmentDTO>, IModelChangeAudit
    {
        int Id { get; }
        int CustomerId { get; set; }
        int UserId { get; set; }
        DateTime Start { get; set; }
        DateTime End { get; set; }
        string Type { get; set; }
        string CityLocation { get; set; }
        string URL { get; set; }
        string Description { get; set; }
    }
    public class Appointment : IAppointment
    {
        private readonly IAppointmentFactory _AppointmentFactory;
        public int Id { get; private set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Type { get; set; }
        public string CityLocation { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public string UpdatedBy { get; private set; }

        public Appointment(IAppointmentFactory appointmentFactory)
        {
            _AppointmentFactory = appointmentFactory;
        }

        public void Initialize(AppointmentDTO dto)
        {
            Id = dto.appointmentId;
            CustomerId = dto.customerId;
            UserId = dto.userId;
            Start = dto.start;
            End = dto.end;
            Type = dto.type;
            CityLocation = dto.location;
            URL = dto.url;
            CreatedOn = dto.createDate;
            CreatedBy = dto.createdBy;
            UpdatedOn = dto.lastUpdate;
            UpdatedBy = dto.lastUpdateBy;
        }

        public AppointmentDTO ToDTO()
        {
            AppointmentDTO appointmentDTO = _AppointmentFactory.GetDefaultDTOWithReqs();
            appointmentDTO.appointmentId = Id;
            appointmentDTO.customerId = CustomerId;
            appointmentDTO.userId = UserId;
            appointmentDTO.start = Start;
            appointmentDTO.end = End;
            appointmentDTO.type = Type;
            appointmentDTO.location = CityLocation;
            appointmentDTO.url = URL;
            appointmentDTO.createDate = CreatedOn;
            appointmentDTO.createdBy = CreatedBy;
            appointmentDTO.lastUpdate = UpdatedOn;
            appointmentDTO.lastUpdateBy = UpdatedBy;
            return appointmentDTO;
        }
    }
}
