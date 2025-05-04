using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WGUD969.Database;
using WGUD969.Database.Migrations;
using WGUD969.Database.Repositories;
using WGUD969.Factories;
using WGUD969.Models;

namespace WGUD969.Services
{
    public interface IStartupService
    {
        Task InitializeAsync();
    }
    public class StartupService : IStartupService
    {
        private readonly IMySqlConnectionFactory _ConnectionFactory;
        private readonly IUserFactory _UserFactory;
        private readonly IUserRepository _UserRepository;
        private readonly IExceptionHandlingService _ExceptionHandler;

        public StartupService(IMySqlConnectionFactory connectionFactory, IUserFactory userFactory, IUserRepository userRepository, IExceptionHandlingService exceptionHandler)
        {
            _ConnectionFactory = connectionFactory;
            _UserFactory = userFactory;
            _UserRepository = userRepository;
            _ExceptionHandler = exceptionHandler;
        }

        public async Task InitializeAsync()
        {
            await RunInitialMigration();
            await CreateTestUser();
        }

        private async Task RunInitialMigration()
        {
            // The database table creation query is large and stored in a migration class
            string query = DatabaseCreation.Query;

            // Without using exception handling here we will not be able to see the details of any MySQL error from running the query
            await _ExceptionHandler.ExecuteAsync(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        using (var command = connection.CreateCommand())
                        {

                            command.CommandText = query;
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                },
                "StartupService.RunInitialMigration()"
            );
        }

        // Default user information for the evaluator is configured in the UserFactory, the UserRepository handles
        // checking if the user already exists and either creating it or updating it
        private async Task CreateTestUser()
        {
            IUser DefaultUser = _UserFactory.CreateDefaultEvaluationUser();
            await _UserRepository.SetDefaultUserAsync(DefaultUser);
        }
    }
}
