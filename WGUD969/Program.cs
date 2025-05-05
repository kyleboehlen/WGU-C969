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
        static async Task Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            await ServiceProvider.GetRequiredService<IStartupService>().InitializeAsync();

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
            services.AddSingleton<IAuthService, AuthService>(); // The auth service as a singleton means there can only be ONE authenticated User
            services.AddSingleton<ILoggingService, LoggingService>();
            services.AddSingleton<IExceptionHandlingService, ExceptionHandlingService>();
            services.AddSingleton<IDTOMappingService<UserDTO>, DTOMappingService<UserDTO>>();
            services.AddSingleton<ILocationService, LocationService>();
            services.AddSingleton<ITranslationService, TranslationService>();
            services.AddSingleton<ICryptographyService, CryptographyService>();

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
            services.AddTransient<IUserFactory>(provider =>  provider.GetRequiredService<UserFactory>());
            services.AddTransient<IDefaultDTOFactory<UserDTO>>(provider =>  provider.GetRequiredService<UserFactory>());

            // Models
            services.AddTransient<IUser, User>();

            // FORMS
            services.AddTransient<Login>();
            services.AddTransient<Dashboard>();
        }
    }
}