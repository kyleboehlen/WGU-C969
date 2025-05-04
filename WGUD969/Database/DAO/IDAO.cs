using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WGUD969.Database.DAO
{
    public interface IDAO<DTO>
    {
        // Return the ID of the newly created T
        Task<int> CreateAsync(DTO dto);
        // Return success/failure of updating T
        Task<bool> UpdateAsync(DTO dto);
        Task<DTO?> GetByIdAsync(int id);
        Task<IEnumerable<DTO>> GetAllAsync();
        // Return success/failure of updating T
        Task<bool> DeleteByIdAsync(int id);
    }
}
