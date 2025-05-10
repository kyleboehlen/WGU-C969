using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WGUD969.Models
{
    public interface ICountry : IModelToDTO<CountryDTO>, IModelChangeAudit
    {
        int Id { get; }
        string Name { get; set; }
    }
    public class Country : ICountry
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public string UpdatedBy { get; private set; }

        public void Initialize(CountryDTO? dto)
        {
            Id = dto.countryId;
            Name = dto.country;
            CreatedOn = dto.createDate;
            CreatedBy = dto.createdBy;
            UpdatedOn = dto.lastUpdate;
            UpdatedBy = dto.lastUpdateBy;
        }

        public CountryDTO ToDTO()
        {
            return new CountryDTO
            {
                countryId = Id,
                country = Name,
                createdBy = CreatedBy,
                lastUpdateBy = UpdatedBy,
            };
        }
    }
}
