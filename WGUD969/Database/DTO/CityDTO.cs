using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGUD969.Database.DTO
{
    public class CityDTO : ChangeAuditDTO
    {
        public required int cityId { get; set; }
        [StringLength(50)]
        public required string city { get; set; }
        public required int countryId { get; set; }
    }
}
