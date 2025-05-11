using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGUD969.Database.DTO
{
    public class AddressDTO : ChangeAuditDTO
    {
        [MaxLength(100)]
        public required int addressId { get; set; }
        [StringLength(50)]
        public required string address {  get; set; }
        [StringLength(50)]
        public string address2 { get; set; }
        [MaxLength(10)]
        public required int cityId { get; set; }
        [StringLength(10)]
        public required string postalCode { get; set; }
        [StringLength(20)]
        public required string phone {  get; set; }
    }
}
