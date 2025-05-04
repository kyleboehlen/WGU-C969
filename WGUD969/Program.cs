using WGUD969.Factories;
using WGUD969.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using WGUD969.Models;
using WGUD969.Database.DTO;
using WGUD969.Database.Repositories;
using WGUD969.Database.DAO;
using WGUD969.Services;

namespace WGUD969
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        //static void Main()
        //{
        //    // To customize application configuration such as set high DPI settings or default font,
        //    // see https://aka.ms/applicationconfiguration.
        //    ApplicationConfiguration.Initialize();
        //    Application.Run(new Login());
        //}

        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            // Startup service is in charge of creating the database tables and setting the test user
            ServiceProvider.GetRequiredService<IStartupService>().InitializeAsync();

            // The Login form will be the entry point to the application
            Application.Run(ServiceProvider.GetRequiredService<Login>());
        }

        public static ServiceProvider ServiceProvider { get; private set; }

        private static void ConfigureServices(IServiceCollection services)
        {
            // CONFIG
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton(configuration);

            // SERVICES
            services.AddTransient<IStartupService, StartupService>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<ILoggingService, LoggingService>();
            services.AddSingleton<IExceptionHandlingService, ExceptionHandlingService>();
            services.AddSingleton<IDTOMappingService<UserDTO>, DTOMappingService<UserDTO>>();

            // DATA ACCESS LAYER
            services.AddSingleton<IMySqlConnectionFactory, MySqlConnectionFactory>();
            services.AddTransient<MySqlConnection>(provider =>
            {
                var factory = provider.GetRequiredService<IMySqlConnectionFactory>();
                return factory.CreateConnection();
            });

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDAO<UserDTO>, UserDAO>();

            // FACTORIES
            services.AddSingleton<UserFactory>();
            services.AddSingleton<IUserFactory>(provider =>  provider.GetRequiredService<UserFactory>());
            services.AddSingleton<IDefaultDTOFactory<UserDTO>>(provider =>  provider.GetRequiredService<UserFactory>());

            // FORMS
            services.AddTransient<Login>();
        }
    }
}