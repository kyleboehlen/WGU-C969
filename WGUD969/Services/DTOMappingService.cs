using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WGUD969.Factories;

namespace WGUD969.Services
{
    public interface IDTOMappingService<T>
    {
        T MapToDTO(DbDataReader reader);
    }

    public class DTOMappingService<T> : IDTOMappingService<T>
    {
        private readonly IDefaultDTOFactory<T> _DefaultDTOFactory;
        public DTOMappingService(IDefaultDTOFactory<T> defaultFactory)
        {
            _DefaultDTOFactory = defaultFactory;
        }

        public T MapToDTO(DbDataReader reader)
        {
            T dto = _DefaultDTOFactory.CreateDefaultWithReqs();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                string columnName = property.Name;

                if (!HasColumn(reader, columnName))
                    continue;

                // If the database value from the reader is null there is no point in mapping it
                if (!reader.IsDBNull(reader.GetOrdinal(columnName)))
                {
                    object value = reader[columnName];

                    // We're checking this to set the value directly if the property is a generic nullable type like int? or DateTime?
                    if (property.PropertyType.IsGenericType &&
                        property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        property.SetValue(dto, value);
                    }
                    else
                    {
                        // Convert.ChangeType does not work directly with nullable types, hence the check above ^
                        property.SetValue(dto, Convert.ChangeType(value, property.PropertyType));
                    }
                }
            }

            return dto;
        }

        private bool HasColumn(DbDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
