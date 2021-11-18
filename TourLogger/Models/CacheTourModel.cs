using Newtonsoft.Json;

namespace TourLogger.Models
{
    public class CacheTourModel
    {
        [JsonProperty("cachedTours")]
        public TourModel[] CachedTours { get; set; }
    }
}
