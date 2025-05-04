using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGUD969.Factories
{
    // The point of this interface is to allow the implementation of DTO factories that can be injected based
    // on the type of DTO they generate. They facilitate the ability to get DTOs with defaults for the required fields.
    // This is paticularly useful when using the DTOMapper as you know you will be overwritng the default DTO values for 
    // the required fields as it wouldn't be possible to store a database entry without those required fields, however
    // you still need to have an instance of the DTO to reflect the values on to with the generic DTO Mapper
    public interface IDefaultDTOFactory<T>
    {
        T CreateDefaultWithReqs();
    }
}
