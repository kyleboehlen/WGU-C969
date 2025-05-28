using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using WGUD969.Database.DTO;
using WGUD969.Factories;
using WGUD969.Models;
using WGUD969.Services;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WGUD969.Database.DAO
{
    public class CustomerDAO : IDAO<CustomerDTO>
    {
        private readonly IMySqlConnectionFactory _ConnectionFactory;
        private readonly IExceptionHandlingService _ExceptionHandler;
        private readonly IDTOMappingService<CustomerDTO> _DTOMapper;

        public CustomerDAO(IMySqlConnectionFactory connectionFactory, IExceptionHandlingService exceptionHandler, IDTOMappingService<CustomerDTO> dtoMapper)
        {
            _ConnectionFactory = connectionFactory;
            _ExceptionHandler = exceptionHandler;
            _DTOMapper = dtoMapper;
        }

        public async Task<int> CreateAsync(CustomerDTO dto)
        {
            return await _ExceptionHandler.ExecuteAsync<int>(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        string query = @"
                                        INSERT INTO customer 
                                        (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) 
                                        VALUES 
                                        (
                                            @customerName,
                                            @addressId,
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
                "CityDAO.CreateAsync()");
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _ExceptionHandler.ExecuteAsync<bool>(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        string query = "DELETE FROM customer WHERE customerId = @id;";
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.Parameters.AddWithValue("id", id);

                            // Determine success based on rows affected
                            int rowsAffected = await command.ExecuteNonQueryAsync();

                            return rowsAffected > 0;
                        }
                    }
                },
                "CustomerDAO.DeleteByIdAsync()"
            );
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            return await _ExceptionHandler.ExecuteAsync<IEnumerable<CustomerDTO>>(
                async () =>
                {
                    var customers = new List<CustomerDTO>();

                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();

                        string query = @"SELECT * FROM customer;";

                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = query;

                            using (var reader = await command.ExecuteReaderAsync())
                            {
                                while (await reader.ReadAsync())
                                {
                                    var customerDTO = _DTOMapper.MapToDTO(reader);
                                    customers.Add(customerDTO);
                                }
                            }
                        }
                    }

                    return customers;
                },
                "CustomerDAO.GetAllAsync()"
            );
        }

        public async Task<CustomerDTO?> GetByIdAsync(int id)
        {
            return await _ExceptionHandler.ExecuteAsync<CustomerDTO?>(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        string query = "SELECT * FROM customer WHERE customerId = @id;";
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
                "CustomerDAO.GetByIDAsync()"
            );
        }

        public async Task<bool> UpdateAsync(CustomerDTO dto)
        {
            return await _ExceptionHandler.ExecuteAsync<bool>(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        string query = @"
                                UPDATE customer
                                SET 
                                    customerName = COALESCE(@customerName, customerName),
                                    addressId = @addressId,
                                    active = COALESCE(@active, active), 
                                    lastUpdate = CURRENT_TIMESTAMP,
                                    lastUpdateBy = @lastUpdateBy
                                WHERE customerId = @customerId";
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
                "CustomerDAO.UpdateAsync()"
            );
        }
    }
}
