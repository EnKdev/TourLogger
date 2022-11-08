using System.Collections.Generic;
using Newtonsoft.Json;

namespace TourLogger.Mvvm.Models;

public class RefuelCacheModel
{
    [JsonProperty("cachedRefuels")]
    public List<RefuelModel>? CachedRefuels { get; set; }
}