using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DTO;
using WGUD969.Factories;
using WGUD969.Services;

namespace WGUD969.Database.DAO
{
    public class CustomerDAO : IDAO<CustomerDTO>
    {
        private readonly IMySqlConnectionFactory _ConnectionFactory;
        private readonly IExceptionHandlingService _ExceptionHandler;
        private readonly IDTOMappingService<UserDTO> _DTOMapper;

        public CustomerDAO(IMySqlConnectionFactory connectionFactory, IExceptionHandlingService exceptionHandler, IDTOMappingService<UserDTO> dtoMapper)
        {
            _ConnectionFactory = connectionFactory;
            _ExceptionHandler = exceptionHandler;
            _DTOMapper = dtoMapper;
        }

        Task<int> IDAO<CustomerDTO>.CreateAsync(CustomerDTO dto)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDAO<CustomerDTO>.DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<CustomerDTO>> IDAO<CustomerDTO>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<CustomerDTO?> IDAO<CustomerDTO>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDAO<CustomerDTO>.UpdateAsync(CustomerDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
