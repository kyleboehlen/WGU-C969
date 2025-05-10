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
    public class CityDAO : IDAO<CityDTO>
    {
        private readonly IExceptionHandlingService _ExceptionHandler;
        private readonly IMySqlConnectionFactory _ConnectionFactory;
        private readonly IDTOMappingService<CityDTO> _DTOMapper;

        public CityDAO(IExceptionHandlingService exceptionHandler, IMySqlConnectionFactory connectionFactory, IDTOMappingService<CityDTO> dTOMapper)
        {
            _ExceptionHandler = exceptionHandler;
            _ConnectionFactory = connectionFactory;
            _DTOMapper = dTOMapper;
        }

        public async Task<int> CreateAsync(CityDTO dto)
        {
            return await _ExceptionHandler.ExecuteAsync<int>(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        string query = @"
                            INSERT INTO city 
                            (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) 
                            VALUES 
                            (
                                @city,
                                @countryId,
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
                "CityDAO.CreateAsync()"
);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CityDTO>> GetAllAsync()
        {
            return await _ExceptionHandler.ExecuteAsync<IEnumerable<CityDTO>>(
                async () =>
                {
                    var cities = new List<CityDTO>();

                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();

                        string query = @"SELECT * FROM city;";

                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = query;

                            using (var reader = await command.ExecuteReaderAsync())
                            {
                                while (await reader.ReadAsync())
                                {
                                    var cityDto = _DTOMapper.MapToDTO(reader);
                                    cities.Add(cityDto);
                                }
                            }
                        }
                    }

                    return cities;
                },
                "CityDAO.GetAllAsync()"
            );
        }

        public async Task<CityDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(CityDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
