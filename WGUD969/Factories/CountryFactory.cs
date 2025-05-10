using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WGUD969.Database.DTO;
using WGUD969.Services;
using WGUD969.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WGUD969.Factories
{
    public interface ICountryFactory : IDefaultDTOFactory<CountryDTO>, IDefaultModelFactory<ICountry>
    { }
    public class CountryFactory : ICountryFactory
    {
        public readonly IAuthService _AuthService;
        public readonly IServiceProvider _ServiceProvider;
        
        public CountryFactory(IAuthService authService, IServiceProvider serviceProvider)
        {
            _AuthService = authService;
            _ServiceProvider = serviceProvider;
        }

        public ICountry GetDefaultModel()
        {
            string username = _AuthService?.User?.Username ?? "CountryFactory.GetDefaultModel()";
            CountryDTO countryDTO = GetDefaultDTOWithReqs();
            countryDTO.createdBy = username;
            countryDTO.lastUpdateBy = username;
            ICountry country = _ServiceProvider.GetRequiredService<ICountry>();
            country.Initialize(countryDTO);
            return country;
        }

        public CountryDTO GetDefaultDTOWithReqs()
        {
            return new CountryDTO
            {
                countryId = 0,
                country = "",
                createdBy = "CountryFactory.CreateDefaultDTOWithReqs()",
                lastUpdateBy = "CountryFactory.CreateDefaultDTOWithReqs()"
            };
        }
    }
}
