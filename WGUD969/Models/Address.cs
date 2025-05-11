using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WGUD969.Database.DTO;

namespace WGUD969.Models
{
    public interface IAddress : IModelToDTO<AddressDTO>, IModelChangeAudit
    {
        int Id { get; }
        string Line1 { get; set; }
        string? Line2 { get; set; }
        ICity City { get; set; }
        string PostalCode { get; set; }
        string PhoneNumber { get; set; }
    }
    public class Address : IAddress
    {
        public int Id { get; private set; }

        public string Line1 { get; set; }
        public string? Line2 { get; set; }
        private int _CityId;
        public ICity City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime? CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public string UpdatedBy { get; private set; }

        public void Initialize(AddressDTO dto)
        {
            Id = dto.cityId;
            Line1 = dto.address;
            Line2 = dto.address2;
            _CityId = dto.cityId;
            PostalCode = dto.postalCode;
            PhoneNumber = dto.phone;
            CreatedOn = dto.createDate;
            CreatedBy = dto.createdBy;
            UpdatedOn = dto.lastUpdate;
            UpdatedBy = dto.lastUpdateBy;
        }

        public AddressDTO ToDTO()
        {
            throw new NotImplementedException();
        }
    }
}
