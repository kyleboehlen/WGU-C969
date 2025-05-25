using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGUD969.Database.DTO
{
    public class AppointmentDTO : ChangeAuditDTO
    {
        [MaxLength(10)]
        public required int appointmentId { get; set; }
        [MaxLength(10)]
        public required int customerId { get; set; }
        [MaxLength(10)]
        public required int userId { get; set; }
        [StringLength(255)]
        public string? title { get; set; }
        public string? description { get; set; }
        public string? location { get; set; }
        public string? contact {  get; set; }
        public string? type { get; set; }
        [MaxLength(255)]
        public string? url { get; set; }
        public required DateTime start { get; set; }
        public required DateTime end { get; set; }
    }
}
