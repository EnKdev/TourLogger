using Newtonsoft.Json;

namespace TourLogger.Models
{
    public class SingleRefuelModel
    {
        [JsonProperty("refuelId")]
        public int RefuelId { get; set; }

        [JsonProperty("refuelDriver")]
        public string RefuelDriver { get; set; }

        [JsonProperty("refuelCountry")]
        public string RefuelCountry { get; set; }

        [JsonProperty("refuelLiterPrice")]
        public double RefuelLiterPrice { get; set; }

        [JsonProperty("refuelOdo")]
        public int RefuelOdo { get; set; }

        [JsonProperty("refuelAmount")]
        public int RefuelAmount { get; set; }

        [JsonProperty("refuelTotalPrice")]
        public int RefuelTotalPrice { get; set; }
    }
}