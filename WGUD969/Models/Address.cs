using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WGUD969.Database.DTO;
using WGUD969.Database.Repositories;

namespace WGUD969.Models
{
    public interface IAddress : IModelToDTO<AddressDTO>, IModelChangeAudit
    {
        int Id { get; }
        string Line1 { get; set; }
        string? Line2 { get; set; }
        ICity City { get; set; }
        string PostalCode { get; set; }
        string PhoneNumber { get; set; }
        public Task HydrateCity(List<ICity>? cities = null);
        public void HydrateCity(ICity city);
    }
    public class Address : IAddress
    {
        public int Id { get; private set; }

        public string Line1 { get; set; }
        public string? Line2 { get; set; }
        private int _CityId;
        public ICity City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime? CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public string UpdatedBy { get; private set; }
        private readonly ICityRepository _CityRepository;
        public Address(ICityRepository cityRepository)
        {
            _CityRepository = cityRepository;
        }

        public void Initialize(AddressDTO dto)
        {
            Id = dto.addressId;
            Line1 = dto.address;
            Line2 = dto.address2;
            _CityId = dto.cityId;
            PostalCode = dto.postalCode;
            PhoneNumber = dto.phone;
            CreatedOn = dto.createDate;
            CreatedBy = dto.createdBy;
            UpdatedOn = dto.lastUpdate;
            UpdatedBy = dto.lastUpdateBy;
        }

        public async Task HydrateCity(List<ICity>? cities = null)
        {
            if (cities != null)
            {
                City = cities.First(country => country.Id == _CityId);
            }
            else
            {
                City = await _CityRepository.GetCityByIdAsync(_CityId);
            }
        }

        public void HydrateCity(ICity city)
        {
            _CityId = city.Id;
            City = city;
        }

        public AddressDTO ToDTO()
        {
            return new AddressDTO
            {

                addressId = Id,
                address = Line1,
                address2 = Line2,
                cityId = _CityId,
                postalCode = PostalCode,
                phone = PhoneNumber,
                createdBy = CreatedBy,
                lastUpdateBy = UpdatedBy,
            };
        }
    }
}
