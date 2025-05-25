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
    public class AppointmentDAO : IDAO<AppointmentDTO>
    {
        private readonly IExceptionHandlingService _ExceptionHandler;
        private readonly IMySqlConnectionFactory _ConnectionFactory;
        public AppointmentDAO(IExceptionHandlingService exceptionHandler, IMySqlConnectionFactory connectionFactory)
        {
            _ExceptionHandler = exceptionHandler;
            _ConnectionFactory = connectionFactory;
        }
        public async Task<int> CreateAsync(AppointmentDTO dto)
        {
            return await _ExceptionHandler.ExecuteAsync<int>(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        string query = @"
                            INSERT INTO appointment 
                            (appointmentId, customerId, userId, title, description, type, location, contact, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) 
                            VALUES 
                            (
                                @appointmentId,
                                @customerId,
                                @userId,
                                @title,
                                @description,
                                @type,
                                @location,
                                @contact,
                                @url,
                                @start,
                                @end,
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
                "AppointmentDAO.CreateAsync()");
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppointmentDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(AppointmentDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
