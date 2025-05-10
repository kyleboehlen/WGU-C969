using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGUD969.Database.DTO
{
    public class CountryDTO : ChangeAuditDTO
    {
        public required int countryId { get; set; }
        [StringLength(50)]
        public required string country { get; set; }
    }
}
