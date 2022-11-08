using Microsoft.Extensions.DependencyInjection;
using TourLogger.Mvvm.Interfaces;
using TourLogger.Mvvm.Services;

namespace TourLogger.Mvvm;

/// <summary>
/// Extends the IServiceCollection methods with two more methods
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Adds all services that the app needs in order to run through Dependency Injection
    /// </summary>
    public static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IVersioningService, VersioningService>();
        services.AddSingleton<IPhpService, PhpService>();
        services.AddSingleton<IDataService, DataService>();
    }

    /// <summary>
    /// Adds all view models that the app needs in order to run through Dependency Injection
    /// </summary>
    public static void AddViewModels(this IServiceCollection services)
    {
    }
}