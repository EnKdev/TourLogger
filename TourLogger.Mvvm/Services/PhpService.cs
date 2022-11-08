using System.Collections.Generic;
using TourLogger.Mvvm.Interfaces;
using TourLogger.Mvvm.Models;

namespace TourLogger.Mvvm.Services;

/// <summary>
/// See the documentation of <see cref="IPhpService"/>
/// </summary>
public class PhpService : IPhpService
{
    private readonly IDataService _dataService;

    /// <summary>
    /// Standard constructor
    /// </summary>
    /// <param name="service">The data service.</param>
    public PhpService(IDataService dataService)
    {
        _dataService = dataService;
    }

    public void FetchTourEntries()
    {
        var jsonArray = "";
        var tours = new List<TourModel>();
        
        #if STABLE
        var res = HttpPost.SendPost(
            "https://enkdev.xyz/cdn/php/tourlogger/getTours.php",
            new NameValueCollection
            {
                { "secret", _secretService.AppSecret },
                { "version", Constants.AppVersion }
            });
        #elif EXPERIMENTAL
        #endif
    }

    public void FetchRefuelEntries()
    {
        throw new System.NotImplementedException();
    }

    public void FetchTour(int tourId)
    {
        throw new System.NotImplementedException();
    }

    public void FetchRefuel(int refuelId)
    {
        throw new System.NotImplementedException();
    }

    public void SendTour(
        string? driver, string? truck, string? startLocation, 
        string? destination, string? freight, int distance,
        int driven, int income, int odo, int fuel)
    {
        throw new System.NotImplementedException();
    }

    public void SendRefuel(
        string? driver, string? country, double literPrice, 
        int odo, int amount, int totalPrice)
    {
        throw new System.NotImplementedException();
    }

    public void MigrateProfile(string? name, string? truck)
    {
        throw new System.NotImplementedException();
    }

    public void CreateAccount(string? name, string? truck)
    {
        throw new System.NotImplementedException();
    }

    public string GetAccount(string? name)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateToursOfAccount(string? name)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateRefuelsOfAccount(string? name)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateTruckOfAccount(string? name)
    {
        throw new System.NotImplementedException();
    }

    private int GetTotalNumberOfTours()
    {
        throw new System.NotImplementedException();
    }

    private int GetTotalNumberOfRefuels()
    {
        throw new System.NotImplementedException();
    }
}