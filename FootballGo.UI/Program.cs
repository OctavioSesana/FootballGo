using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Services;

namespace FootballGo.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();

            // Registrar servicios y forms
            services.AddScoped<ClienteService>();
            services.AddScoped<EmpleadoService>();
            services.AddScoped<Form1>();
            services.AddScoped<Form2>();
            services.AddScoped<LoginForm>();
            services.AddScoped<MenuForm>();
            services.AddTransient<EmpleadoLoginForm>();
            services.AddTransient<EmpleadoDashboardForm>();

            var provider = services.BuildServiceProvider();

            // arrancar con el menú
            Application.Run(provider.GetRequiredService<MenuForm>());
        }
    }
}
