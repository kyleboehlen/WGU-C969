using WGUD969.Factories;
using WGUD969.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;

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
            Application.Run(ServiceProvider.GetRequiredService<Login>());
        }

        public static ServiceProvider ServiceProvider { get; private set; }

        private static void ConfigureServices(IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddSingleton<IConfiguration>(configuration);

            // Register IConfiguration
            services.AddSingleton(configuration);
            services.AddSingleton<IMySqlConnectionFactory, MySqlConnectionFactory>();
            services.AddTransient<Login>();
        }
    }
}