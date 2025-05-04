using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WGUD969.Database.DTO
{
    public class UserDTO
    {
        public required int userID {  get; set; }
        [StringLength(50)]
        public required string userName { get; set; }
        [StringLength(50)]
        public required string password { get; set; }
        public bool? active {  get; set; }
        public DateTime? createDate { get; set; }
        [StringLength(50)]
        public required string createdBy { get; set; }
        public DateTime? lastUpdate {  get; set; }
        [StringLength(40)]
        public required string lastUpdateBy { get; set; }
    }
}
