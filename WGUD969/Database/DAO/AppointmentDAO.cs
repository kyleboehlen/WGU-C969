using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DTO;

namespace WGUD969.Database.DAO
{
    public class AppointmentDAO : IDAO<AppointmentDTO>
    {
        public Task<int> CreateAsync(AppointmentDTO dto)
        {
            throw new NotImplementedException();
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
