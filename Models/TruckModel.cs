using Newtonsoft.Json;

namespace TourLogger.Models
{
    public class TruckModel
    {
        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }
        
        [JsonProperty("model")]
        public string Model { get; set; }
        
        [JsonProperty("driver")]
        public string Driver { get; set; }
    }
}