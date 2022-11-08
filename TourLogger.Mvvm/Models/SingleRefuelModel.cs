using Newtonsoft.Json;

namespace TourLogger.Mvvm.Models;

public class SingleRefuelModel
{
    [JsonProperty("refuelId")]
    public int RefuelId { get; set; }

    [JsonProperty("refuelDriver")]
    public string? Driver { get; set; }

    [JsonProperty("refuelCountry")]
    public string? Country { get; set; }

    [JsonProperty("refuelLiterPrice")]
    public double LiterPrice { get; set; }

    [JsonProperty("refuelOdo")]
    public int Odo { get; set; }

    [JsonProperty("refuelAmount")]
    public int Amount { get; set; }

    [JsonProperty("refuelTotalPrice")]
    public int TotalPrice { get; set; }
}