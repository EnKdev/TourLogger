using Newtonsoft.Json;

namespace TourLogger.Mvvm.Models;

public class SingleTourModel
{
    [JsonProperty("tourId")]
    public int TourId { get; set; }

    [JsonProperty("tourDriver")]
    public string? Driver { get; set; }

    [JsonProperty("truckUsed")]
    public string? TruckUsed { get; set; }

    [JsonProperty("tourFrom")]
    public string? StartLocation { get; set; }

    [JsonProperty("tourTo")]
    public string? Destination { get; set; }

    [JsonProperty("tourFreight")]
    public string? Freight { get; set; }

    [JsonProperty("tourDistance")]
    public int Distance { get; set; }

    [JsonProperty("distanceDriven")]
    public int Driven { get; set; }

    [JsonProperty("jobIncome")]
    public int Income { get; set; }

    [JsonProperty("odo")]
    public int Odo { get; set; }

    [JsonProperty("fuelUsed")]
    public int FuelUsed { get; set; }
}