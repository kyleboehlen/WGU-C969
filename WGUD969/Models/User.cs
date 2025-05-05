using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Database.DTO;
using WGUD969.Services;

namespace WGUD969.Models
{
    public interface IUser : IModelToDTO<UserDTO>
    {
        int Id { get; }
        string Username { get; set; }
        DateTime? CreatedOn { get; }
        DateTime? UpdatedOn { get; }
        string CreatedBy { get; }
        string UpdatedBy { get; }
        public bool IsActive { get; set; }
        void Initialize(UserDTO? dto);
        bool CheckPassword(string pwd);
        void SetNewPassword(string pwd);
        void TouchUpdated(string updatedBy);
    }
    public class User : IUser
    {
        public int Id { get; private set; }
        public string Username { get; set; }
        private string PasswordHash;
        private bool? _IsActive = null;
        public DateTime? CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public string UpdatedBy { get; private set; }

        private readonly ICryptographyService _CryptoService;

        public User(ICryptographyService cryptoService)
        {
            _CryptoService = cryptoService;
        }

        public void Initialize(UserDTO dto)
        {
            Id = dto.userID;
            Username = dto.userName;
            PasswordHash = dto.password;
            _IsActive = dto.active ?? false;
            CreatedOn = dto.createDate;
            CreatedBy = dto.createdBy;
            UpdatedOn = dto.lastUpdate;
            UpdatedBy = dto.lastUpdateBy;
        }

        public bool IsActive
        {
            get
            {
                if (_IsActive == null) return false;
                return _IsActive.Value;
            }

            set { _IsActive = value; }
        }

        public bool CheckPassword(string pwd)
        {
            return _CryptoService.HashPassword(pwd) == PasswordHash;
        }

        public void SetNewPassword(string pwd)
        {
            PasswordHash = _CryptoService.HashPassword(pwd);
        }

        public void TouchUpdated(string? updatedBy)
        {
            UpdatedOn = DateTime.UtcNow;
            if (updatedBy != null)
            {
                UpdatedBy = updatedBy;
            }
        }

        public UserDTO ToDTO()
        {
            return new UserDTO
            {
                userID = Id,
                userName = Username,
                password = PasswordHash,
                createdBy = CreatedBy,
                lastUpdateBy = UpdatedBy,
            };
        }
    }
}
