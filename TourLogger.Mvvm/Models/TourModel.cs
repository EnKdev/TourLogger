namespace TourLogger.Mvvm.Models;

/// <summary>
/// Model class to reflect a tour as a .NET object
/// </summary>
public class TourModel
{
    public int TourId { get; set; }
    public string? Driver { get; set; }
    public string? TruckUsed { get; set; }
    public string? StartLocation { get; set; }
    public string? Destination { get; set; }
    public string? Freight { get; set; }
    public int Distance { get; set; }
    public int Driven { get; set; }
    public int Income { get; set; }
    public int Odo { get; set; }
    public int FuelUsed { get; set; }

    public TourModel(
        int tourId, string? driver, string? truckUsed,
        string? startLocation, string? destination, string? freight,
        int distance, int driven, int income,
        int odo, int fuelUsed)
    {
        TourId = tourId;
        Driver = driver;
        TruckUsed = truckUsed;
        StartLocation = startLocation;
        Destination = destination;
        Freight = freight;
        Distance = distance;
        Driven = driven;
        Income = income;
        Odo = odo;
        FuelUsed = fuelUsed;
    }
}