using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Factories;
using WGUD969.Database.DTO;
using MySql.Data.MySqlClient;
using WGUD969.Services;

namespace WGUD969.Database.DAO
{
    public class UserDAO : IDAO<UserDTO>
    {
        private readonly IMySqlConnectionFactory _ConnectionFactory;
        private readonly IExceptionHandlingService _ExceptionHandler;
        private readonly IDTOMappingService<UserDTO> _DTOMapper;

        public UserDAO(IMySqlConnectionFactory connectionFactory, IExceptionHandlingService exceptionHandler, IDTOMappingService<UserDTO> dtoMapper)
        {
            _ConnectionFactory = connectionFactory;
            _ExceptionHandler = exceptionHandler;
            _DTOMapper = dtoMapper;
        }

        public async Task<int> CreateAsync(UserDTO dto)
        {
            return await _ExceptionHandler.ExecuteAsync<int>(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        string query = @"
                            INSERT INTO user 
                            (userID, userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy) 
                            VALUES 
                            (
                                @userID, 
                                @userName, 
                                @password, 
                                COALESCE(@active, DEFAULT(active)), 
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
                "UserDAO.CreateAsync()"
            );
        }

        public async Task<bool> UpdateAsync(UserDTO dto)
        {
            return await _ExceptionHandler.ExecuteAsync<bool>(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        string query = @"
                    UPDATE user
                    SET 
                        userName = COALESCE(@UserName, userName),
                        password = COALESCE(@Password, password),
                        active = COALESCE(@Active, active),
                        lastUpdate = CURRENT_TIMESTAMP,
                        lastUpdateBy = @LastUpdateBy
                    WHERE userId = @UserId";
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = query;

                            // Mapping DTO values to query params, null values are handled in the query
                            command.Parameters.AddRange(
                                dto.GetType().GetProperties()
                                    .Select(prop => new MySqlParameter($"@{prop.Name}", prop.GetValue(dto)))
                                    .ToArray()
                            );

                            // Determine success based on rows affected
                            int rowsAffected = await command.ExecuteNonQueryAsync();

                            return rowsAffected > 0;
                        }
                    }
                },
                "UserDAO.UpdateAsync()"
            );
        }

        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            return await _ExceptionHandler.ExecuteAsync<UserDTO?>(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        string query = "SELECT * FROM user WHERE userId = @id;";
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
                "UserDAO.GetByIDAsync()"
            );
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            return await _ExceptionHandler.ExecuteAsync<IEnumerable<UserDTO>>(
                async () =>
                {
                    var users = new List<UserDTO>();

                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();

                        string query = @"SELECT userId, userName, password, active, 
                                createDate, createdBy, lastUpdate, lastUpdateBy 
                                FROM user";

                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = query;

                            using (var reader = await command.ExecuteReaderAsync())
                            {
                                while (await reader.ReadAsync())
                                {
                                    var userDto = _DTOMapper.MapToDTO(reader);
                                    users.Add(userDto);
                                }
                            }
                        }
                    }

                    return users;
                },
                "UserDAO.GetAllAsync()"
            );
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            // TODO
            return true;
        }
    }
}
