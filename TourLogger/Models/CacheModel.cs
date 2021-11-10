using Newtonsoft.Json;

namespace TourLogger.Models
{
    public class CacheModel
    {
        [JsonProperty("cachedTours")]
        public TourModel[] CachedTours { get; set; }
    }
}
