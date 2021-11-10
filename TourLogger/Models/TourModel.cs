namespace TourLogger.Models
{
    public class TourModel
    {
        public TourModel(int id, string driver, string truck, string from, string to, string freight, int dist, int driven,
            int income, int total, int fuel)
        {
            TourID = id;
            Driver = driver;
            TruckUsed = truck;
            From = from;
            To = to;
            Freight = freight;
            TourDistance = dist;
            DrivenDistance = driven;
            JobIncome = income;
            Odo = total;
            FuelUsed = fuel;
        }

        public int TourID { get; set; }

        public string Driver { get; set; }

        public string TruckUsed { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Freight { get; set; }

        public int TourDistance { get; set; }

        public int DrivenDistance { get; set; }

        public int JobIncome { get; set; }

        public int Odo { get; set; }

        public int FuelUsed { get; set; }
    }
}
