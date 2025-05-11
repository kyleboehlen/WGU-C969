using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.Repositories;
using WGUD969.Models;

namespace WGUD969.Services
{
    public interface ICityService
    {
        Task<Dictionary<int, string>> GetCityLabelsAsync();
    }
    public class CityService : ICityService
    {
        ICityRepository _CityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _CityRepository = cityRepository;
        }

        public async Task<Dictionary<int, string>> GetCityLabelsAsync()
        {
            // Calling this function from the repository is more preformant than getting all of the cities and hydrating their countries
            List<ICity> cities = await _CityRepository.GetAllWithCountriesAsync();

            // We want a list of all of the cities with duplicate names so you're not confusing Paris, France and Paris, Texas ya feel?
            List<string> duplicateCityNames = cities
                .GroupBy(city => city.Name)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key)
                .ToList();

            // Adding country names for any cities that share the same name, the data model prevents having a duplicate city in a duplicate country
            Dictionary<int, string> cityLabels = cities
                .Select(city => {
                    string label = city.Name;
                    if (duplicateCityNames.Contains(label)) {
                        label += $" ({city.Country.Name})";
                    }
                    return new
                    {
                        Id = city.Id,
                        Label = label
                    };
                })
                .ToDictionary(
                    city => city.Id,
                    city => city.Label
                );
            return cityLabels;
        }
    }
}
