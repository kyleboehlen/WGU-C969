using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WGUD969.Database.DTO;
using WGUD969.Factories;

namespace WGUD969.Services
{
    public interface IDatabaseMigrationService
    {
        Task UpAsync();
        Task DownAsync();
    }
    public class DatabaseMigrationService : IDatabaseMigrationService
    {
        private readonly IMySqlConnectionFactory _ConnectionFactory;
        private readonly IExceptionHandlingService _ExceptionHandler;
        private List<string> _Migrations;
        // This can be set to true to start with a fresh databse when running Up()
        private readonly bool _DropAllTables = true;

        public DatabaseMigrationService(IMySqlConnectionFactory connectionFactory, IExceptionHandlingService exceptionHandler)
        {
            _ConnectionFactory = connectionFactory;
            _ExceptionHandler = exceptionHandler;
        }

        private async Task ReadMigrations()
        {
            await _ExceptionHandler.ExecuteAsync(
                async () =>
                {
                    string migrationPath = Path.Combine(AppContext.BaseDirectory, "Database", "Migrations");
                    string[] migrationFiles = Directory.GetFiles(migrationPath);

                    _Migrations = await Task.WhenAll(migrationFiles.Select(async file =>
                        await File.ReadAllTextAsync(file)
                    )).ContinueWith(task => task.Result.ToList());
                },
                "DataMigrationService.ReadMigrations()"
            );
        }

        private async Task DropAllTablesAsync()
        {
            await _ExceptionHandler.ExecuteAsync(
                async () =>
                {
                    var tableNames = new List<string>();

                    await using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();

                        await using (var command = connection.CreateCommand())
                        {
                            command.CommandText = @"
                                SELECT CONCAT('DROP TABLE IF EXISTS `', table_name, '`;')
                                FROM information_schema.tables
                                WHERE table_schema = 'client_schedule';";
                            using (var reader = await command.ExecuteReaderAsync())
                            {
                                while (await reader.ReadAsync())
                                {
                                    tableNames.Add(reader.GetString(0));
                                }
                                await reader.CloseAsync();
                            }
                        }

                        await connection.CloseAsync();
                    }

                    await using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();

                        await using (var dropCommand = connection.CreateCommand())
                        {
                            dropCommand.CommandText = $"SET FOREIGN_KEY_CHECKS=0;{string.Join(string.Empty, tableNames)}SET FOREIGN_KEY_CHECKS=1;";
                            await dropCommand.ExecuteNonQueryAsync();
                        }

                        await connection.CloseAsync();
                    }
                },
                "DataMigrationService.DropAllTables()"
            );
        }

        public async Task UpAsync()
        {
            // For making database modifications on the VM
            if (_DropAllTables && !File.Exists("alreadydropped"))
            {
                await DropAllTablesAsync();
                File.WriteAllText("alreadydropped", string.Empty);
            }

            await ReadMigrations();

            await _ExceptionHandler.ExecuteAsync(
                async () =>
                {
                    await using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();

                        foreach (var query in _Migrations)
                        {
                            await using (var command = connection.CreateCommand())
                            {
                                // Check if this is a seeder query and replace placeholders
                                var processedQuery = ProcessSeederQuery(query);
                                Debug.WriteLine(processedQuery);
                                command.CommandText = processedQuery;
                                await command.ExecuteNonQueryAsync();
                            }
                        }
                    }
                },
                "DataMigrationService.UpAsync()"
            );
        }

        private string ProcessSeederQuery(string query)
        {
            if (IsSeederQuery(query))
            {
                return query
                    .Replace("@createdBy", "'test'")
                    .Replace("@lastUpdatedBy", "'test'")
                    .Replace("@seedDate", "'2019-01-01 00:00:00'")
                    .Replace("@notNeeded", "'not needed'");
            }
            return query;
        }

        private bool IsSeederQuery(string query)
        {
            return query.Contains("@createdBy") ||
                   query.Contains("@seedDate") ||
                   query.Contains("@notNeeded");
        }

        public async Task DownAsync()
        {
            throw new NotImplementedException();
        }
    }
}
