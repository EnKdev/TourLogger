﻿using Newtonsoft.Json;

namespace TourLogger.Mvvm.Models;

public class AccountModel
{
    [JsonProperty("accountId")]
    public int AccountId { get; set; }

    [JsonProperty("accountName")]
    public string? Name { get; set; }

    [JsonProperty("accountTruck")]
    public string? Truck { get; set; }

    [JsonProperty("totalTours")]
    public string? TotalTours { get; set; }

    [JsonProperty("totalKilometers")]
    public string? TotalKilometers { get; set; }

    [JsonProperty("totalIncome")]
    public string? TotalIncome { get; set; }

    [JsonProperty("totalRefuels")]
    public string? TotalRefuels { get; set; }

    [JsonProperty("totalLiters")]
    public string? TotalLiters { get; set; }

    [JsonProperty("totalFuelPrice")]
    public string? TotalFuelPrice { get; set; }
}