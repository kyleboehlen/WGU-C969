using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DTO;

namespace WGUD969.Models
{
    public interface IModelToDTO<T>
    {
        void Initialize(T dto);
        T ToDTO();
    }
}
