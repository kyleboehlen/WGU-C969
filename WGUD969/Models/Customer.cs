using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DTO;
using WGUD969.Database.Repositories;

namespace WGUD969.Models
{
    public interface ICustomer : IModelToDTO<CustomerDTO>, IModelChangeAudit
    {
        int Id { get; }
        string Name { get; set; }
        public bool IsActive { get; set; }
        public IAddress Address { get; }
        public void HydrateAddress(IAddress address);
    }
    public class Customer : ICustomer
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        private bool? _IsActive = null;
        private int? _AddressID { get; set; }
        public IAddress Address { get; private set; }
        public DateTime? CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public string UpdatedBy { get; private set; }

        void IModelToDTO<CustomerDTO>.Initialize(CustomerDTO? dto)
        {
            Id = dto.customerId;
            Name = dto.customerName;
            _AddressID = dto.addressId;
            _IsActive = dto.active;
            CreatedOn = dto.createDate;
            CreatedBy = dto.createdBy;
            UpdatedOn = dto.lastUpdate;
            UpdatedBy = dto.lastUpdateBy;
        }

        public bool IsActive
        {
            get
            {
                if (_IsActive == null) return false;
                return _IsActive.Value;
            }

            set { _IsActive = value; }
        }

        public void HydrateAddress(IAddress? address)
        {
            if (address != null)
            {
                _AddressID = address.Id;
                Address = address;
            }
        }

        CustomerDTO IModelToDTO<CustomerDTO>.ToDTO()
        {
            return new CustomerDTO
            {

                customerId = Id,
                customerName = Name,
                addressId = _AddressID,
                createdBy = CreatedBy,
                lastUpdateBy = UpdatedBy,
            };
        }
    }
}
