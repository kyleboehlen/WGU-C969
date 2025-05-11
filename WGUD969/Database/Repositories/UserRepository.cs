using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WGUD969.Database.DAO;
using WGUD969.Database.DTO;
using WGUD969.Models;

namespace WGUD969.Database.Repositories
{
    public interface IUserRepository
    {
        Task SetDefaultUserAsync(IUser user);
        Task<IUser?> GetUserByUsername(string username);
    }
    public class UserRepository : IUserRepository
    {
        private readonly IDAO<UserDTO> _UserDAO;
        private readonly IServiceProvider _ServiceProvider;
        public UserRepository(IDAO<UserDTO> userDAO, IServiceProvider serviceProvider)
        {
            _UserDAO = userDAO;
            _ServiceProvider = serviceProvider;
        }

        public async Task SetDefaultUserAsync(IUser user)
        {
            // Converting User model to UserDTO as that is required to use the UserDAO
            UserDTO userDTO = user.ToDTO();

            // We'll check whether a User already exists with that ID to determine whether we use a create or update operation
            if (await _UserDAO.GetByIdAsync(userDTO.userId) != null)
            {
                await _UserDAO.UpdateAsync(userDTO);
            }
            else
            {
                await _UserDAO.CreateAsync(userDTO);
            }
        }

        public async Task<IUser?> GetUserByUsername(string username)
        {
            // Let's all take a moment to appriciate the security flaw that is pulling in all of the users in to memory from
            // a local database with a hard coded connection string B^)
            List<UserDTO> userDTOs = (List<UserDTO>) await _UserDAO.GetAllAsync();

            // *something snarky about lambdas*
            UserDTO? userDTO = userDTOs.FirstOrDefault(u => u.userName == username);

            // et tu
            if (userDTO == null) { return null; }
            IUser user = _ServiceProvider.GetService<IUser>();
            user.Initialize(userDTO);
            return user;
        }
    }
}
