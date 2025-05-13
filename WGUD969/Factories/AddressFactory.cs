using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WGUD969.Database.DTO;
using WGUD969.Models;
using WGUD969.Services;

namespace WGUD969.Factories
{
    public interface IAddressFactory : IDefaultDTOFactory<AddressDTO>, IDefaultModelFactory<IAddress>
    { }
    public class AddressFactory : IAddressFactory
    {
        public readonly IAuthService _AuthService;
        public readonly IServiceProvider _ServiceProvider;

        public AddressFactory(IAuthService authService, IServiceProvider serviceProvider)
        {
            _AuthService = authService;
            _ServiceProvider = serviceProvider;
        }

        public AddressDTO GetDefaultDTOWithReqs()
        {
            return new AddressDTO
            {
                addressId = 0,
                address = "",
                cityId = 0,
                postalCode = "00000",
                phone = "8888888888",
                createdBy = "AddressFactory.CreateDefaultDTOWithReqs()",
                lastUpdateBy = "AddressFactory.CreateDefaultDTOWithReqs()"
            };
        }

        public IAddress GetDefaultModel()
        {
            string username = _AuthService?.User?.Username ?? "AddressFactory.GetDefaultModel()";
            AddressDTO addressDTO = GetDefaultDTOWithReqs();
            addressDTO.createdBy = username;
            addressDTO.lastUpdateBy = username;
            IAddress address = _ServiceProvider.GetRequiredService<IAddress>();
            address.Initialize(addressDTO);
            return address;
        }
    }
}
