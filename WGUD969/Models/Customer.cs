using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DTO;

namespace WGUD969.Models
{
    public interface ICustomer : IModelToDTO<CustomerDTO>, IModelChangeAudit
    {
        int Id { get; }
        string Name { get; }
        public bool IsActive { get; set; }
    }
    public class Customer : ICustomer
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        private bool? _IsActive = null;
        public DateTime? CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public string UpdatedBy { get; private set; }

        void IModelToDTO<CustomerDTO>.Initialize(CustomerDTO? dto)
        {
            throw new NotImplementedException();
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

        CustomerDTO IModelToDTO<CustomerDTO>.ToDTO()
        {
            throw new NotImplementedException();
        }
    }
}
