﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WGUD969.Database;
using WGUD969.Database.Repositories;
using WGUD969.Factories;
using WGUD969.Models;

namespace WGUD969.Services
{
    public interface IStartupService
    {
        Task InitializeAsync();
    }
    public class StartupService : IStartupService
    {
        private readonly IMySqlConnectionFactory _ConnectionFactory;
        private readonly IUserFactory _UserFactory;
        private readonly IUserRepository _UserRepository;
        private readonly IExceptionHandlingService _ExceptionHandler;
        private readonly IDatabaseMigrationService _DBMigrationRunner;

        public StartupService(IMySqlConnectionFactory connectionFactory, IUserFactory userFactory, IUserRepository userRepository, IExceptionHandlingService exceptionHandler, IDatabaseMigrationService dBMigrationRunner)
        {
            _ConnectionFactory = connectionFactory;
            _UserFactory = userFactory;
            _UserRepository = userRepository;
            _ExceptionHandler = exceptionHandler;
            _DBMigrationRunner = dBMigrationRunner;
        }

        public async Task InitializeAsync()
        {
            await RunInitialMigration();
            await CreateTestUser();
        }

        private async Task RunInitialMigration()
        {
            await _DBMigrationRunner.UpAsync();
        }

        // Default user information for the evaluator is configured in the UserFactory, the UserRepository handles
        // checking if the user already exists and either creating it or updating it
        private async Task CreateTestUser()
        {
            IUser DefaultUser = _UserFactory.CreateDefaultEvaluationUser();
            await _UserRepository.SetDefaultUserAsync(DefaultUser);
        }
    }
}
