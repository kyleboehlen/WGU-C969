using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WGUD969.Database.DTO;
using WGUD969.Models;
using WGUD969.Services;

namespace WGUD969.Factories
{
    public interface ICustomerFactory : IDefaultDTOFactory<CustomerDTO>, IDefaultModelFactory<ICustomer>
    { }
    public class CustomerFactory : ICustomerFactory
    {
        public readonly IAuthService _AuthService;
        public readonly IServiceProvider _ServiceProvider;
        public CustomerFactory(IAuthService authService, IServiceProvider serviceProvider)
        {
            _AuthService = authService;
            _ServiceProvider = serviceProvider;
        }
        public CustomerDTO GetDefaultDTOWithReqs()
        {
            return new CustomerDTO
            {
                customerId = 0,
                customerName = "",
                addressId = 0,
                createdBy = "CustomerFactory.CreateDefaultDTOWithReqs()",
                lastUpdateBy = "CustomerFactory.CreateDefaultDTOWithReqs()"
            };
        }

        public ICustomer GetDefaultModel()
        {
            string username = _AuthService?.User?.Username ?? "CustomerFactory.GetDefaultModel()";
            CustomerDTO customerDTO = GetDefaultDTOWithReqs();
            customerDTO.createdBy = username;
            customerDTO.lastUpdateBy = username;
            ICustomer customer = _ServiceProvider.GetRequiredService<ICustomer>();
            customer.Initialize(customerDTO);
            return customer;
        }
    }
}
