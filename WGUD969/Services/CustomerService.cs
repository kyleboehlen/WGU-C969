using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.Repositories;
using WGUD969.Models;

namespace WGUD969.Services
{
    public interface ICustomerService
    {
        Task<Dictionary<int, string>> GetCustomerLabelsAsync();
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _CustomerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _CustomerRepository = customerRepository;
        }

        public async Task<Dictionary<int, string>> GetCustomerLabelsAsync()
        {
            List<ICustomer> customers = await _CustomerRepository.GetAllWithAddressesAsync();

            Dictionary<int, string> customerLabels = customers
                .Select(customer => new {
                    Id = customer.Id,
                    Label = customer.Name
                })
                .ToDictionary(
                    customer => customer.Id,
                    customer => customer.Label
                );
            return customerLabels;
        }
    }
}
