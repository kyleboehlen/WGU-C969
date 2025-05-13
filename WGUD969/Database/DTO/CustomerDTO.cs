using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGUD969.Database.DTO
{
    public class CustomerDTO : ChangeAuditDTO
    {
        [MaxLength(10)]
        public required int customerId { get; set; }
        [StringLength(45)]
        public required string customerName { get; set; }
        [MaxLength(10)]
        public int? addressId { get; set; }
        public bool? active { get; set; }
    }
}
