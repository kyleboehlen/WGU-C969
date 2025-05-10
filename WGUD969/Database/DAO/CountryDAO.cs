using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WGUD969.Database.DTO;
using WGUD969.Factories;
using WGUD969.Services;

namespace WGUD969.Database.DAO
{
    public class CountryDAO : IDAO<CountryDTO>
    {
        private readonly IExceptionHandlingService _ExceptionHandler;
        private readonly IMySqlConnectionFactory _ConnectionFactory;
        private readonly IDTOMappingService<CountryDTO> _DTOMapper;

        public CountryDAO(IExceptionHandlingService exceptionHandler, IMySqlConnectionFactory connectionFactory, IDTOMappingService<CountryDTO> dTOMapper)
        {
            _ExceptionHandler = exceptionHandler;
            _ConnectionFactory = connectionFactory;
            _DTOMapper = dTOMapper;
        }

        public async Task<int> CreateAsync(CountryDTO dto)
        {
            return await _ExceptionHandler.ExecuteAsync<int>(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        string query = @"
                                        INSERT INTO country 
                                        (country, createDate, createdBy, lastUpdate, lastUpdateBy) 
                                        VALUES 
                                        (
                                            @country, 
                                            COALESCE(@createDate, NOW()), 
                                            @createdBy, 
                                            COALESCE(@lastUpdate, NOW()), 
                                            @lastUpdateBy
                                        );
                                        SELECT LAST_INSERT_ID();";

                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = query;

                            // Map DTO values to query params, null values are mapped to defaults in the query
                            command.Parameters.AddRange(
                                dto.GetType().GetProperties()
                                    .Select(prop => new MySqlParameter($"@{prop.Name}", prop.GetValue(dto) ?? DBNull.Value))
                                    .ToArray()
                            );

                            // Using scalar to return only the value of the final select statement
                            var newId = await command.ExecuteScalarAsync();

                            return Convert.ToInt32(newId);
                        }
                    }
                },
                "CountryDAO.CreateAsync()"
            );
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CountryDTO>> GetAllAsync()
        {
            return await _ExceptionHandler.ExecuteAsync<IEnumerable<CountryDTO>>(
                async () =>
                {
                    var countries = new List<CountryDTO>();

                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();

                        string query = @"SELECT * FROM country;";

                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = query;

                            using (var reader = await command.ExecuteReaderAsync())
                            {
                                while (await reader.ReadAsync())
                                {
                                    var countryDto = _DTOMapper.MapToDTO(reader);
                                    countries.Add(countryDto);
                                }
                            }
                        }
                    }

                    return countries;
                },
                "CountryDAO.GetAllAsync()"
            );
        }

        public async Task<CountryDTO?> GetByIdAsync(int id)
        {
            return await _ExceptionHandler.ExecuteAsync<CountryDTO?>(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        string query = "SELECT * FROM country WHERE countryId = @id;";
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.Parameters.AddWithValue("id", id);
                            using (var reader = await command.ExecuteReaderAsync())
                            {
                                if (await reader.ReadAsync())
                                {
                                    // Using the DTO mapper becaause our DTOs are mapped 1:1 with the tables
                                    return _DTOMapper.MapToDTO(reader);
                                }
                                else
                                {
                                    return null;
                                }
                            }
                        }
                    }
                },
                "CountryDAO.GetByIDAsync()"
            );
        }

        public Task<bool> UpdateAsync(CountryDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
