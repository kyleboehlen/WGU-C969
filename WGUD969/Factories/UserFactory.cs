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
    public interface IUserFactory : IDefaultDTOFactory<UserDTO>
    {
        IUser CreateDefaultEvaluationUser();
    }
    public class UserFactory : IUserFactory
    {
        private readonly IServiceProvider _ServiceProvider;
        public UserFactory(IServiceProvider serviceProvider)
        {
            _ServiceProvider = serviceProvider;
        }

        // For generating the test user for evaluations
        public IUser CreateDefaultEvaluationUser() {
            IUser defaultUser = _ServiceProvider.GetService<IUser>();
            defaultUser.Initialize(new UserDTO
            {
                userId = 1,
                userName = "test",
                password = "test",
                createdBy = "IUserFactory",
                lastUpdateBy = "IUserFactory",
            });

            // Setting the password this way will hash it
            defaultUser.SetNewPassword("test");

            return defaultUser;
        }

        // For creating a UserDTO with default values that are required by the DTO
        public UserDTO GetDefaultDTOWithReqs()
        {
            return new UserDTO
            {
                userId = 0,
                userName = "",
                password = "",
                createdBy = "IDefaultDTOFactory<UserDTO>",
                lastUpdateBy = "IDefaultDTOFactory<UserDTO>",
            };
        }
    }
}
