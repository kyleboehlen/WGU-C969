using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DTO;
using WGUD969.Database.Repositories;

namespace WGUD969.Models
{
    public interface ICity : IModelToDTO<CityDTO>, IModelChangeAudit
    {
        int Id { get; }
        string Name { get; set; }
        ICountry Country { get; set; }
        Task HydrateCountry(List<ICountry>? countries);
    }
    public class City : ICity
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        private int _CountryId;
        public ICountry Country { get; set; }
        public DateTime? CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public string UpdatedBy { get; private set; }
        private readonly ICountryRepository _CountryRepository;
        public City(ICountryRepository countryRepository)
        {
            _CountryRepository = countryRepository;
        }

        public void Initialize(CityDTO dto)
        {
            Id = dto.cityId;
            _CountryId = dto.countryId;
            Name = dto.city;
            CreatedOn = dto.createDate;
            CreatedBy = dto.createdBy;
            UpdatedOn = dto.lastUpdate;
            UpdatedBy = dto.lastUpdateBy;
        }

        public async Task HydrateCountry(List<ICountry>? countries = null)
        {
            if (countries != null)
            {
                Country = countries.First(country => country.Id == _CountryId);
            } else
            {
                Country = await _CountryRepository.GetCountryByIdAsync(_CountryId);
            }
        }

        public CityDTO ToDTO()
        {
            return new CityDTO
            {

                cityId = Id,
                city = Name,
                countryId = Country.Id,
                createdBy = CreatedBy,
                lastUpdateBy = UpdatedBy,
            };
        }
    }
}
