
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

            return new MySqlConnection(connString);
        }
    }
}
