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
    public class AddressDAO : IDAO<AddressDTO>
    {
        private readonly IMySqlConnectionFactory _ConnectionFactory;
        private readonly IExceptionHandlingService _ExceptionHandler;
        private readonly IDTOMappingService<AddressDTO> _DTOMapper;

        public AddressDAO(IMySqlConnectionFactory connectionFactory, IExceptionHandlingService exceptionHandler, IDTOMappingService<AddressDTO> dtoMapper)
        {
            _ConnectionFactory = connectionFactory;
            _ExceptionHandler = exceptionHandler;
            _DTOMapper = dtoMapper;
        }

        public async Task<int> CreateAsync(AddressDTO dto)
        {
            return await _ExceptionHandler.ExecuteAsync<int>(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        string query = @"
                                        INSERT INTO address 
                                        (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) 
                                        VALUES 
                                        (
                                            @address,
                                            @address2,
                                            @cityId,
                                            @postalCode,
                                            @phone,
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
                "AddressDAO.CreateAsync()");
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AddressDTO?> GetByIdAsync(int id)
        {
            return await _ExceptionHandler.ExecuteAsync<AddressDTO?>(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        string query = "SELECT * FROM address WHERE addressId = @id;";
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
                "AddressDAO.GetByIDAsync()"
            );
        }

        public Task<bool> UpdateAsync(AddressDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
