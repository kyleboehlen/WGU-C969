using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DTO;
using WGUD969.Models;
using WGUD969.Services;

namespace WGUD969.Factories
{
    public interface IUserFactory
    {
        IUser CreateDefaultEvaluationUser();
    }
    public class UserFactory : IUserFactory, IDefaultDTOFactory<UserDTO>
    {
        private IAuthService _AuthService;
        public UserFactory(IAuthService authService)
        {
            _AuthService = authService;
        }

        // For generating the test user for evaluations
        public IUser CreateDefaultEvaluationUser() {
            return new User(new UserDTO
            {
                userID = 1,
                userName = "test",
                password = _AuthService.HashPassword("test"),
                createdBy = "IUserFactory",
                lastUpdateBy = "IUserFactory",
            });
        }

        // For creating a UserDTO with default values that are required by the DTO
        public UserDTO CreateDefaultWithReqs()
        {
            return new UserDTO
            {
                userID = 0,
                userName = "",
                password = "",
                createdBy = "IDefaultDTOFactory<UserDTO>",
                lastUpdateBy = "IDefaultDTOFactory<UserDTO>",
            };
        }
    }
}
