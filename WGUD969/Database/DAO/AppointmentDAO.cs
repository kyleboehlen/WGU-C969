﻿using System;
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
        private readonly IDTOMappingService<AppointmentDTO> _DTOMapper;

        public AppointmentDAO(IExceptionHandlingService exceptionHandler, IMySqlConnectionFactory connectionFactory, IDTOMappingService<AppointmentDTO> dTOMapper)
        {
            _ExceptionHandler = exceptionHandler;
            _ConnectionFactory = connectionFactory;
            _DTOMapper = dTOMapper;
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

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _ExceptionHandler.ExecuteAsync<bool>(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        string query = "DELETE FROM appointment WHERE appointmentId = @id;";
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
                "AppointmentDAO.DeleteByIdAsync()"
            );
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAsync()
        {
            return await _ExceptionHandler.ExecuteAsync<IEnumerable<AppointmentDTO>>(
                async () =>
                {
                    var appointments = new List<AppointmentDTO>();

                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();

                        string query = @"SELECT * FROM appointment;";

                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = query;

                            using (var reader = await command.ExecuteReaderAsync())
                            {
                                while (await reader.ReadAsync())
                                {
                                    var appointmentDTO = _DTOMapper.MapToDTO(reader);
                                    appointments.Add(appointmentDTO);
                                }
                            }
                        }
                    }

                    return appointments;
                },
                "AppointmentDAO.GetAllAsync()"
            );
        }

        public Task<AppointmentDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(AppointmentDTO dto)
        {
            return await _ExceptionHandler.ExecuteAsync<bool>(
                async () =>
                {
                    using (var connection = _ConnectionFactory.CreateConnection())
                    {
                        await connection.OpenAsync();
                        string query = @"
                                UPDATE appointment
                                SET 
                                    appointmentId = @appointmentId,
                                    customerId = @customerId,
                                    userId = @userId,
                                    title = @title,
                                    description = @description,
                                    type = @type,
                                    location = @location,
                                    contact = @contact,
                                    url = @url,
                                    start = @start,
                                    end = @end,
                                    lastUpdate = COALESCE(@lastUpdate, NOW()), 
                                    lastUpdateBy = @lastUpdateBy
                                WHERE appointmentId = @appointmentId";
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
                "AppointmentDAO.UpdateAsync()"
            );
        }
    }
}
