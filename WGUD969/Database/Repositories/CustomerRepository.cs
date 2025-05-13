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
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDAO<CustomerDTO> _CustomerDAO;
        private readonly IDAO<AddressDTO> _AddressDAO;

        public CustomerRepository(IDAO<CustomerDTO> customerDAO,  IDAO<AddressDTO> addressDAO)
        {
            _CustomerDAO = customerDAO;
            _AddressDAO = addressDAO;
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

        public Task<List<ICustomer>> GetAllWithAddressesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
