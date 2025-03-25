using Microsoft.Extensions.DependencyInjection;
using SportMeal.UI.FormDialog;
using SportMeal.UI.Client;

namespace SportMeal.UI;

internal static class Program
{
    private static IServiceProvider? _serviceProvider;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ApiClient>();
        _serviceProvider = services.BuildServiceProvider();

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        var apiClient = _serviceProvider.GetRequiredService<ApiClient>();
        Application.Run(new FormAuth(apiClient));
    }
}
