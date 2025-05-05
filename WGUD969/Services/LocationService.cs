using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WGUD969.Models;
using System.Text.Json;
using System.Globalization;
using System.Diagnostics;

namespace WGUD969.Services
{
    public interface ILocationService
    {
        Task<IUserLocation> GetUserLocationAsync();
    }

    public class LocationService : ILocationService
    {
        private readonly IExceptionHandlingService _ExceptionHandler;
        private readonly IConfiguration _Configuration;
        private readonly ILoggingService _Logger;
        private readonly ITranslationService _Translator;
        public LocationService(IExceptionHandlingService exceptionHandler, IConfiguration configuration, ILoggingService logger, ITranslationService translator)
        {
            _ExceptionHandler = exceptionHandler;
            _Configuration = configuration;
            _Logger = logger;
            _Translator = translator;
        }
        public async Task<IUserLocation> GetUserLocationAsync()
        {
            return await _ExceptionHandler.ExecuteAsync<IUserLocation>(
                async () =>
                {
                    using (HttpClient client = new HttpClient())
                    {
                        // Getting user's locale based on an API call w/ their IP is the preferred method as we can narrow it down to the city
                        // they are in, however in instances where internet access may not be available, or an API is down we will fallback to 
                        // using the Windows Region API
                        string IPLocationServiceAPIURL = _Configuration["LocationService:APIURL"];
                        using (HttpResponseMessage response = await client.GetAsync(IPLocationServiceAPIURL))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string result = await response.Content.ReadAsStringAsync();

                                // We could serialize to IUserLocation if we had a different way to get the ITranslationService to the constructor
                                JsonElement resultJson = JsonSerializer.Deserialize<JsonElement>(result);

                                string timezone = resultJson.GetProperty("Timezone").GetString();
                                string country = resultJson.GetProperty("Country").GetString();
                                string city = resultJson.GetProperty("City").GetString();

                                // We need to pass an instance of ITranslationService since we're not leveraging the DI container here
                                return new UserLocation(timezone, country, city, _Translator);
                            }
                            else
                            {
                                _Logger.LogError($"Failure to get IP location. API Response Code: {response.StatusCode}");
                                CultureInfo culture = CultureInfo.CurrentCulture;
                                RegionInfo region = new RegionInfo(culture.LCID);

                                return new UserLocation(TimeZoneInfo.Local.Id, region.EnglishName, null, _Translator);
                            }
                        }
                    }
                }, "LocationService.GetUserLocationAsync()"
            );
        }
    }
}
