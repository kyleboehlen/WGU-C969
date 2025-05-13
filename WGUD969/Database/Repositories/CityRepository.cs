using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DAO;
using WGUD969.Database.DTO;
using WGUD969.Factories;
using WGUD969.Models;
using static WGUD969.Database.Repositories.CityRepository;

namespace WGUD969.Database.Repositories
{
    public delegate Task AsyncEventHandler<TEventArgs>(object sender, TEventArgs e) where TEventArgs : EventArgs;

    public class CityEventArgs : EventArgs
    {
        public int CityId { get; }

        public CityEventArgs(int cityId)
        {
            CityId = cityId;
        }
    }

    public interface ICityRepository
    {
        public Task<List<ICity>> GetAllWithCountriesAsync();
        public Task<ICity> CreateAsync(string city, string country);
        public Task<ICity> GetCityByIdAsync(int cityId);
        public event AsyncEventHandler<CityEventArgs> CityAdded;
    }
    public class CityRepository : ICityRepository
    {
        private readonly IDAO<CityDTO> _CityDAO;
        private readonly ICountryRepository _CountryRepository;
        private readonly ICityFactory _CityFactory;
        public event AsyncEventHandler<CityEventArgs> CityAdded;

        public CityRepository(IDAO<CityDTO> CityDAO, ICountryRepository countryRepository, ICityFactory cityFactory)
        {
            _CityDAO = CityDAO;
            _CountryRepository = countryRepository;
            _CityFactory = cityFactory;
        }

        public async Task<ICity> CreateAsync(string cityName, string countryName)
        {
            // We want to check if a country with this name already exists and save it's id, if not we'll want to create a new one
            List<ICountry> countries = await _CountryRepository.GetAllAsync();

            // We'll set case when we create countries so we want to ignore case when matching
            countryName = countryName.ToLower();

            // Checking for a country, and assigning the ID here if found so we don't have to assign it later with extra logic
            ICountry country;
            int countryID = countries.FirstOrDefault(c => c.Name.ToLower() == countryName)?.Id ?? 0;
            if (countryID == 0)
            {
                // No country found, we need to make one. Using the country repository where the case rules are in place
                country = await _CountryRepository.CreateCountryAsync(countryName);

            } else
            {
                country = await _CountryRepository.GetCountryByIdAsync(countryID);
            }

            // We're going to get a model and convert it to a DTO instead of getting a default DTO directly as the audit information is set
            // by the factory by default
            ICity city = _CityFactory.GetDefaultModel();
            city.Name = cityName;
            city.Country = country;
            CityDTO cityDTO = city.ToDTO();
            cityDTO.cityId = await _CityDAO.CreateAsync(cityDTO);
            // If the audit data ever mattered to get from here to a very exact degree this would need to be updated to get a fresh copy of cityDTO
            city.Initialize(cityDTO);
            // We want to fire an event that allows the dashboard to update with the new city list, we'll pass the new city ID so you can select the new city by default
            await OnCityAddedAsync(new CityEventArgs(city.Id));
            return city;
        }

        protected virtual async Task OnCityAddedAsync(CityEventArgs e)
        {
            var handler = CityAdded;
            if (handler != null)
            {
                List<Task> tasks = new List<Task>();

                foreach (var subscriber in handler.GetInvocationList())
                {
                    AsyncEventHandler<CityEventArgs> asyncSubscriber = (AsyncEventHandler<CityEventArgs>)subscriber;
                    tasks.Add(asyncSubscriber.Invoke(this, e));
                }

                await Task.WhenAll(tasks);
            }
        }


        private async Task<List<ICity>> GetAllAsync()
        {
            List<CityDTO> cityDTOs = (List<CityDTO>)await _CityDAO.GetAllAsync();

            List<ICity> cities = cityDTOs
                .Select(dto =>
                {
                    ICity city = _CityFactory.GetDefaultModel();
                    city.Initialize(dto);
                    return city;
                })
                .ToList();

            return cities;
        }

        public async Task<ICity> GetCityByIdAsync(int id)
        {
            CityDTO cityDTO = await _CityDAO.GetByIdAsync(id);
            ICity city = _CityFactory.GetDefaultModel();
            city.Initialize(cityDTO);
            return city;
        }

        public async Task<List<ICity>> GetAllWithCountriesAsync()
        {
            List<ICountry> countries = await _CountryRepository.GetAllAsync();
            List<ICity> cities = await GetAllAsync();
            return cities.Select(city =>
            {
                city.HydrateCountry(countries);
                return city;
            }).ToList();
        }
    }
}
