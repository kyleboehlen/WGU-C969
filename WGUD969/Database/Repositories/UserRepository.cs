using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DAO;
using WGUD969.Database.DTO;
using WGUD969.Models;

namespace WGUD969.Database.Repositories
{
    public interface IUserRepository
    {
        Task SetDefaultUserAsync(IUser user);
    }
    public class UserRepository : IUserRepository
    {
        private readonly IDAO<UserDTO> _UserDAO;
        public UserRepository(IDAO<UserDTO> userDAO)
        {
            _UserDAO = userDAO;
        }

        public async Task SetDefaultUserAsync(IUser user)
        {
            // Converting User model to UserDTO as that is required to use the UserDAO
            UserDTO userDTO = user.ToDTO();

            // We'll check whether a User already exists with that ID to determine whether we use a create or update operation
            if (await _UserDAO.GetByIdAsync(user.Id) != null)
            {
                await _UserDAO.UpdateAsync(userDTO);
            }
            else
            {
                await _UserDAO.CreateAsync(userDTO);
            }
        }
    }
}
