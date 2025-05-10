using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DTO;
using WGUD969.Models;
using WGUD969.Database.DAO;
using WGUD969.Factories;
using System.Numerics;

namespace WGUD969.Database.Repositories
{
    public interface ICountryRepository
    {
        Task<List<ICountry>> GetAllAsync();
        Task<ICountry> CreateCountryAsync(string name);
        Task<ICountry> GetCountryByIdAsync(int id);
    }

    public class CountryRepository : ICountryRepository
    {
        public readonly IDAO<CountryDTO> _CountryDAO;
        public readonly ICountryFactory _CountryFactory;

        public CountryRepository(IDAO<CountryDTO> countryDAO, ICountryFactory countryFactory)
        {
            _CountryDAO = countryDAO;
            _CountryFactory = countryFactory;
        }

        public async Task<List<ICountry>> GetAllAsync()
        {
            List<CountryDTO> countryDTOs = (List<CountryDTO>)await _CountryDAO.GetAllAsync();

            List<ICountry> countries = countryDTOs
                .Select(dto =>
                {
                    ICountry country = _CountryFactory.GetDefaultModel();
                    country.Initialize(dto);
                    return country;
                })
                .ToList();

            return countries;
        }

        public async Task<ICountry> CreateCountryAsync(string name)
        {
            // Getting model to map audit fields properly
            ICountry countryModel = _CountryFactory.GetDefaultModel();
            CountryDTO countryDTO = countryModel.ToDTO();
            countryDTO.country = name;
            int countryId = await _CountryDAO.CreateAsync(countryDTO);
            return await GetCountryByIdAsync(countryId);
        }

        public async Task<ICountry> GetCountryByIdAsync(int id)
        {
            CountryDTO countryDTO = await _CountryDAO.GetByIdAsync(id);
            ICountry country = _CountryFactory.GetDefaultModel();
            country.Initialize(countryDTO);
            return country;
        }
    }
}
