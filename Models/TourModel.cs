namespace TourLogger.Models
{
    public class TourModel
    {
        private int _tId;
        private string _tDriver;
        private string _tFrom;
        private string _tTo;
        private string _tFreight;
        private int _tDistance;
        private int _tDriven;
        private int _tIncome;
        private int _tTotal;
        private int _tFuel;

        public TourModel(int id, string driver, string from, string to, string freight, int dist, int driven,
            int income, int total, int fuel)
        {
            _tId = id;
            _tDriver = driver;
            _tFrom = from;
            _tTo = to;
            _tFreight = freight;
            _tDistance = dist;
            _tDriven = driven;
            _tIncome = income;
            _tTotal = total;
            _tFuel = fuel;
        }
    }
}