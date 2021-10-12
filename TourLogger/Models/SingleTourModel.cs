using Newtonsoft.Json;

namespace TourLogger.Models
{
    public class SingleTourModel
    {
        [JsonProperty("tourId")]
        public long TourId { get; set; }

        [JsonProperty("tourDriver")]
        public string TourDriver { get; set; }

        [JsonProperty("truckUsed")]
        public string TruckUsed { get; set; }

        [JsonProperty("tourFrom")]
        public string TourFrom { get; set; }

        [JsonProperty("tourTo")]
        public string TourTo { get; set; }

        [JsonProperty("tourFreight")]
        public string TourFreight { get; set; }

        [JsonProperty("tourDistance")]
        public long TourDistance { get; set; }

        [JsonProperty("distanceDriven")]
        public long DistanceDriven { get; set; }

        [JsonProperty("jobIncome")]
        public long JobIncome { get; set; }

        [JsonProperty("odo")]
        public long Odo { get; set; }

        [JsonProperty("fuelUsed")]
        public long FuelUsed { get; set; }
    }
}