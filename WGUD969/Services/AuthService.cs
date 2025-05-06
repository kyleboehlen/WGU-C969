using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WGUD969.Database.Repositories;
using WGUD969.Models;

namespace WGUD969.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string username, string pwd);
        IUser? User { get; }
        bool IsAuthenticated { get; }
    }
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IExceptionHandlingService _ExceptionHandler;
        private readonly ILoggingService _Logger;
        public IUser? User { get; private set; } = null;

        public AuthService(IUserRepository userRepository, IExceptionHandlingService exceptionHandler, ILoggingService logger)
        {
            _UserRepository = userRepository;
            _ExceptionHandler = exceptionHandler;
            _Logger = logger;
        }

        public async Task<bool> LoginAsync(string username, string pwd)
        {
            IUser? user = await _UserRepository.GetUserByUsername(username);

            // Do not move hashing to this service or you will have a DI deadlock
            if (user != null && user.CheckPassword(pwd))
            {
                User = user;
            }

            // Also, logger can't handle using the exception handler cuz.. DI deadlock 
            await _ExceptionHandler.ExecuteAsync(
                async () =>
                {
                    await _Logger.LogToFileWithTimestamp("Login_History", $"{username} login attempt {(IsAuthenticated ? "successful" : "failed")}.");
                },
                "AuthService.LoginAsync()"
            );

            // We only set a user if we get one by username, and the password matches, so utilizing IsAuthenticated is good here
            return IsAuthenticated;
        }

        public bool IsAuthenticated
        {
            get { return User != null; }
        }
    }
}
