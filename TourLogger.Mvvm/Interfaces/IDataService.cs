using System.Collections.Generic;
using TourLogger.Mvvm.Models;

namespace TourLogger.Mvvm.Interfaces;

/// <summary>
/// Base implementation to handle write operations for TourLogger-data
/// </summary>
public interface IDataService
{
    /// <summary>
    /// Writes a list of tours to a cache file.
    /// </summary>
    /// <param name="toursToCache">A list of <see cref="TourModel"/> to write to a cache file.</param>
    public void WriteCachedTourData(List<TourModel> toursToCache);

    /// <summary>
    /// Writes a list of refuels to a cache file.
    /// </summary>
    /// <param name="refuelsToCache">A list of <see cref="RefuelModel"/> to write to a cache file.</param>
    public void WriteCachedRefuelData(List<RefuelModel> refuelsToCache);

    /// <summary>
    /// Writes a progressing tour to a progress file in case the driver needs to take a break.
    /// </summary>
    /// <param name="driver">The driver.</param>
    /// <param name="truck">The truck.</param>
    /// <param name="startLocation">The starting location of the tour.</param>
    /// <param name="destination">The destination of the tour.</param>
    /// <param name="freight">The freight.</param>
    /// <param name="dist">The total distance of the tour.</param>
    /// <param name="income">The income of the tour.</param>
    public void WriteProgressingTour(string? driver, string? truck, string? startLocation, string? destination,
        string? freight, int dist, int income);
}