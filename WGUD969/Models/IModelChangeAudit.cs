using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGUD969.Models
{
    public interface IModelChangeAudit
    {
        DateTime? CreatedOn { get; }
        DateTime? UpdatedOn { get; }
        string CreatedBy { get; }
        string UpdatedBy { get; }
    }
}
