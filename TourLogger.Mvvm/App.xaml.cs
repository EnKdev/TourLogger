using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TourLogger.Mvvm.Interfaces;
using TourLogger.Mvvm.Services;

namespace TourLogger.Mvvm;

public sealed partial class App : Application
{
    /// <summary>
    /// Gets the current <see cref="App"/> instance in use
    /// </summary>
    public new static App Current => (App)Application.Current;

    /// <summary>
    /// Gets the <see cref="IServiceProvider"/> instance to resolve application services
    /// </summary>
    public IServiceProvider Services { get; }

    public App()
    {
        Services = ConfigureServices();

        Current.Services.GetService<ISecretService>()?.GrabSecretAsync();
        Current.Services.GetService<ISecretService>()?.GrabCompilationKeyAsync();

        InitializeComponent();
    }

    /// <summary>
    /// Configures the services for the application
    /// </summary>
    private static IServiceProvider ConfigureServices()
    {
        // Service Container
        var services = new ServiceCollection();

        // Service-Registration
        services.AddServices();

        // ViewModel-Registration
        services.AddViewModels();

        return services.BuildServiceProvider();
    }
}
