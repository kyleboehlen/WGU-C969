using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DTO;
using WGUD969.Database.Repositories;
using WGUD969.Factories;
using WGUD969.Services;

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
        ICustomer Customer { get; }
        Task HydrateCustomer(List<ICustomer>? customers);
    }
    public class Appointment : IAppointment
    {
        private readonly IAppointmentFactory _AppointmentFactory;
        private readonly ITimezoneService _TimezoneService;
        private readonly ICustomerRepository _CustomerRepository;
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
        public ICustomer Customer { get; private set; }

        public Appointment(IAppointmentFactory appointmentFactory, ITimezoneService timezoneService, ICustomerRepository customerRepository)
        {
            _AppointmentFactory = appointmentFactory;
            _TimezoneService = timezoneService;
            _CustomerRepository = customerRepository;
        }

        public void Initialize(AppointmentDTO dto)
        {
            Id = dto.appointmentId;
            CustomerId = dto.customerId;
            UserId = dto.userId;
            Start = _TimezoneService.ConvertFromUTC(dto.start);
            End = _TimezoneService.ConvertFromUTC(dto.end);
            Type = dto.type;
            CityLocation = dto.location;
            URL = dto.url;
            Description = dto.description;
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
            appointmentDTO.start = _TimezoneService.ConvertToUTC(Start);
            appointmentDTO.end = _TimezoneService.ConvertToUTC(End);
            appointmentDTO.type = Type;
            appointmentDTO.location = CityLocation;
            appointmentDTO.url = URL;
            appointmentDTO.description = Description;
            appointmentDTO.createDate = CreatedOn;
            appointmentDTO.createdBy = CreatedBy;
            appointmentDTO.lastUpdate = UpdatedOn;
            appointmentDTO.lastUpdateBy = UpdatedBy;
            return appointmentDTO;
        }

        public async Task HydrateCustomer(List<ICustomer>? customers = null)
        {
            if (customers != null)
            {
                Customer = customers.First(country => country.Id == CustomerId);
            }
            else
            {
                Customer = await _CustomerRepository.GetByIdAsync(CustomerId);
            }
        }
    }
}
