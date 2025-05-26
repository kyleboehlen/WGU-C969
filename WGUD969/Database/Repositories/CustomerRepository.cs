using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DAO;
using WGUD969.Database.DTO;
using WGUD969.Factories;
using WGUD969.Models;

namespace WGUD969.Database.Repositories
{
    public interface ICustomerRepository
    {
        public Task<List<ICustomer>> GetAllWithAddressesAsync();
        public Task<ICustomer> CreateOrUpdateWithAddressAsync(ICustomer customer, IAddress address);
        public Task<bool> DeleteAsync(ICustomer customer);
        public Task<ICustomer> GetByIdAsync(int id);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDAO<CustomerDTO> _CustomerDAO;
        private readonly IDAO<AddressDTO> _AddressDAO;
        private readonly IAddressFactory _AddressFactory;
        private readonly ICustomerFactory _CustomerFactory;
        private readonly ICityRepository _CityRepository;

        public CustomerRepository(IDAO<CustomerDTO> customerDAO,  IDAO<AddressDTO> addressDAO, IAddressFactory addressFactory,
            ICustomerFactory customerFactory, ICityRepository cityRepository)
        {
            _CustomerDAO = customerDAO;
            _AddressDAO = addressDAO;
            _AddressFactory = addressFactory;
            _CustomerFactory = customerFactory;
            _CityRepository = cityRepository;
        }

        public async Task<ICustomer> CreateOrUpdateWithAddressAsync(ICustomer customer, IAddress address)
        {
            AddressDTO addressDTO = address.ToDTO();
            if (await _AddressDAO.GetByIdAsync(addressDTO.addressId) != null)
            {
                await _AddressDAO.UpdateAsync(addressDTO);
            }
            else
            {
                addressDTO.addressId = await _AddressDAO.CreateAsync(addressDTO);
            }

            addressDTO = await _AddressDAO.GetByIdAsync(addressDTO.addressId);
            address.Initialize(addressDTO);

            CustomerDTO customerDTO = customer.ToDTO();
            customerDTO.addressId = addressDTO.addressId;
            if (await _CustomerDAO.GetByIdAsync(customerDTO.customerId) != null)
            {
                await _CustomerDAO.UpdateAsync(customerDTO);
            }
            else
            {
                customerDTO.customerId = await _CustomerDAO.CreateAsync(customerDTO);
            }

            customer.HydrateAddress(address);
            return customer;
        }

        public async Task<List<ICustomer>> GetAllWithAddressesAsync()
        {
            List<ICity> cities = await _CityRepository.GetAllWithCountriesAsync();
            List<AddressDTO> addressDTOs = (List<AddressDTO>)await _AddressDAO.GetAllAsync();
            List<IAddress> addresses = addressDTOs.Select(dto =>
            {
                IAddress address = _AddressFactory.GetDefaultModel();
                address.Initialize(dto);
                address.HydrateCity(cities);
                return address;
            }).ToList();

            List<CustomerDTO> customerDTOs = (List<CustomerDTO>)await _CustomerDAO.GetAllAsync();
            List<ICustomer> customers = customerDTOs.Select(dto =>
            {
                ICustomer customer = _CustomerFactory.GetDefaultModel();
                customer.Initialize(dto);
                customer.HydrateAddress(addresses);
                return customer;
            }).ToList();
            return customers;
        }
    
        public async Task<bool> DeleteAsync(ICustomer customer)
        {
            return await _CustomerDAO.DeleteByIdAsync(customer.Id);
        }

        public async Task<ICustomer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
