using Newtonsoft.Json;

namespace TourLogger.Mvvm.Models;

public class TruckModel
{
    [JsonProperty("truck")]
    public string? Truck { get; set; }

    [JsonProperty("driver")]
    public string? Driver { get; set; }
}