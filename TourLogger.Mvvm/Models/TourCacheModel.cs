using System.Collections.Generic;
using Newtonsoft.Json;

namespace TourLogger.Mvvm.Models;

public class TourCacheModel
{
    [JsonProperty("cachedTours")]
    public List<TourModel>? CachedTours { get; set; }
}