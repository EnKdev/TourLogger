using Newtonsoft.Json;

namespace TourLogger.Models
{
    public class ConfigModel
    {
        [JsonProperty("usingExperimental")]
        public bool? UsingExperimental { get; set; }
    }
}