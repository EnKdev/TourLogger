using Newtonsoft.Json;

namespace TourLogger.Models
{
    public class RefuelCacheModel
    {
        [JsonProperty("cachedRefuels")]
        public RefuelModel[] CachedRefuels { get; set; }
    }
}