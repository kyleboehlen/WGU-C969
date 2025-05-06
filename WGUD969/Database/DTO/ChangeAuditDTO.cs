using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGUD969.Database.DTO
{
    public abstract class ChangeAuditDTO
    {
        public DateTime? createDate { get; set; }
        [StringLength(50)]
        public required string createdBy { get; set; }
        public DateTime? lastUpdate { get; set; }
        [StringLength(40)]
        public required string lastUpdateBy { get; set; }
    }
}
