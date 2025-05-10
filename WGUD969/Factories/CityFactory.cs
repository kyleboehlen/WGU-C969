using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Models;
using WGUD969.Database.DTO;
using Microsoft.Extensions.DependencyInjection;
using WGUD969.Services;

namespace WGUD969.Factories
{
    public interface ICityFactory : IDefaultDTOFactory<CityDTO>, IDefaultModelFactory<ICity>
    { }
    public class CityFactory : ICityFactory
    {
        public readonly IAuthService _AuthService;
        public readonly IServiceProvider _ServiceProvider;

        public CityFactory(IAuthService authService, IServiceProvider serviceProvider)
        {
            _AuthService = authService;
            _ServiceProvider = serviceProvider;
        }

        public ICity GetDefaultModel()
        {
            string username = _AuthService?.User?.Username ?? "CityFactory.GetDefaultModel()";
            CityDTO cityDTO = GetDefaultDTOWithReqs();
            cityDTO.createdBy = username;
            cityDTO.lastUpdateBy = username;
            ICity city = _ServiceProvider.GetRequiredService<ICity>();
            city.Initialize(cityDTO);
            return city;
        }

        public CityDTO GetDefaultDTOWithReqs()
        {
            return new CityDTO
            {
                cityId = 0,
                city = "",
                countryId = 0,
                createdBy = "CityFactory.CreateDefaultDTOWithReqs()",
                lastUpdateBy = "CityFactory.CreateDefaultDTOWithReqs()"
            };
        }
    }
}
