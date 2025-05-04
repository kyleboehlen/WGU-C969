using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WGUD969.Services
{
    public interface IAuthService
    {
        string HashPassword(string pwd);
    }
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _Configuration;
        public AuthService(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        // Using SHA-256 with a hard coded salt is NOT considered adequite for modern password stores, however...
        // No outside libraries are allowed in the ACs of this project, and I'm not paticularly interested in implementing BCrypt myself so...
        // You get what you get and you don't throw a fit, beggars can't be choosers and all that
        public string HashPassword(string pwd)
        {
            string salt = _Configuration["PasswordSecurity:Salt"]
                ?? throw new InvalidOperationException("Password salt not configured");

            string saltedPassword = pwd + salt;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
