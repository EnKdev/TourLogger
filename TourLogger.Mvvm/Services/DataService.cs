using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TourLogger.Mvvm.Interfaces;
using TourLogger.Mvvm.Models;

namespace TourLogger.Mvvm.Services;

/// <summary>
/// See the documentation of <see cref="IDataService"/>
/// </summary>
public class DataService : IDataService
{
    /// <inheritdoc />
    public void WriteCachedTourData(List<TourModel> toursToCache)
    {
        var cacheModel = new TourCacheModel
        {
            CachedTours = toursToCache
        };

        using var sw = File.CreateText($"./Userdata/tourCache.dat");
        var fileText = JsonConvert.SerializeObject(cacheModel, Formatting.Indented);
        sw.Write(fileText);
        sw.Dispose();
    }

    /// <inheritdoc />
    public void WriteCachedRefuelData(List<RefuelModel> refuelsToCache)
    {
        var cacheModel = new RefuelCacheModel
        {
            CachedRefuels = refuelsToCache
        };

        using var sw = File.CreateText($"./Userdata/refuelCache.dat");
        var fileText = JsonConvert.SerializeObject(cacheModel, Formatting.Indented);
        sw.Write(fileText);
        sw.Dispose();
    }

    /// <inheritdoc />
    public void WriteProgressingTour(string? driver, string? truck, string? startLocation, string? destination, string? freight,
        int dist, int income)
    {
        var progressingTour = new SingleTourModel
        {
            TourId = -1,
            Driver = driver,
            TruckUsed = truck,
            StartLocation = startLocation,
            Destination = destination,
            Freight = freight,
            Distance = dist,
            Driven = 0,
            Income = income,
            Odo = 0,
            FuelUsed = 0
        };

        using var sw = File.CreateText($"./Userdata/progress.dat");
        var fileText = JsonConvert.SerializeObject(progressingTour, Formatting.Indented);
        sw.Write(fileText);
        sw.Dispose();
    }
}