
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace WGUD969.Factories
{
    public interface IMySqlConnectionFactory
    {
        MySqlConnection CreateConnection();
    }

    public class MySqlConnectionFactory : IMySqlConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public MySqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MySqlConnection CreateConnection()
        {
            var connString = _configuration.GetConnectionString("SchedulingDatabase");
            var connectionStrings = _configuration.GetSection("ConnectionStrings").GetChildren();
            foreach (var connectionString in connectionStrings)
            {
                Debug.WriteLine($"Key: {connectionString.Key}, Value: {connectionString.Value}");
            }

            return new MySqlConnection(connString);
        }
    }
}
