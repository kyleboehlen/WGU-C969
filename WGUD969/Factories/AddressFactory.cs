using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DTO;
using WGUD969.Models;

namespace WGUD969.Factories
{
    public interface IAddressFactory : IDefaultDTOFactory<AddressDTO>, IDefaultModelFactory<IAddress>
    { }
    public class AddressFactory : IAddressFactory
    {
        public AddressDTO GetDefaultDTOWithReqs()
        {
            throw new NotImplementedException();
        }

        public IAddress GetDefaultModel()
        {
            throw new NotImplementedException();
        }
    }
}
