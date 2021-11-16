using Newtonsoft.Json;

namespace TourLogger.Models
{
    public class RefuelModel
    {
        public RefuelModel(int id, string country, double literPrice, int odo, int amount, int totalPrice)
        {
            RefuelId = id;
            RefuelCountry = country;
            RefuelLiterPrice = literPrice;
            RefuelOdo = odo;
            RefuelAmount = amount;
            RefuelTotalPrice = totalPrice;
        }
        
        public int RefuelId { get; set; }
        
        public string RefuelCountry { get; set; }
        
        public double RefuelLiterPrice { get; set; }
        
        public int RefuelOdo { get; set; }
        
        public int RefuelAmount { get; set; }
        
        public int RefuelTotalPrice { get; set; }
    }
}