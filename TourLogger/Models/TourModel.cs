namespace TourLogger.Models
{
    public class TourModel
    {
        private int _tId;
        private string _tDriver;
        private string _tTruck;
        private string _tFrom;
        private string _tTo;
        private string _tFreight;
        private int _tDistance;
        private int _tDriven;
        private int _tIncome;
        private int _tTotal;
        private int _tFuel;

        public TourModel(int id, string driver, string truck, string from, string to, string freight, int dist, int driven,
            int income, int total, int fuel)
        {
            _tId = id;
            _tDriver = driver;
            _tTruck = truck;
            _tFrom = from;
            _tTo = to;
            _tFreight = freight;
            _tDistance = dist;
            _tDriven = driven;
            _tIncome = income;
            _tTotal = total;
            _tFuel = fuel;
        }

        public int TourID
        {
            get => _tId;
            set => _tId = value;
        }

        public string Driver
        {
            get => _tDriver;
            set => _tDriver = value;
        }

        public string TruckUsed
        {
            get => _tTruck;
            set => _tTruck = value;
        }

        public string From
        {
            get => _tFrom;
            set => _tFrom = value;
        }

        public string To
        {
            get => _tTo;
            set => _tTo = value;
        }

        public string Freight
        {
            get => _tFreight;
            set => _tFreight = value;
        }

        public int TourDistance
        {
            get => _tDistance;
            set => _tDistance = value;
        }

        public int DrivenDistance
        {
            get => _tDriven;
            set => _tDriven = value;
        }

        public int JobIncome
        {
            get => _tIncome;
            set => _tIncome = value;
        }

        public int ODO
        {
            get => _tTotal;
            set => _tTotal = value;
        }

        public int FuelUsed
        {
            get => _tFuel;
            set => _tFuel = value;
        }
    }
}