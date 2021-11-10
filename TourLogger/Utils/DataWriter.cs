using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TourLogger.Models;

namespace TourLogger.Utils
{
    public class DataWriter
    {

        public void WriteCachedData(List<TourModel> tours)
        {
            var cm = new CacheModel
            {
                CachedTours = tours.ToArray()
            };

            using StreamWriter sw = File.CreateText($"./Userdata/cache.dat");
            var fileText = JsonConvert.SerializeObject(cm, Formatting.Indented);
            sw.Write(fileText);
            sw.Dispose();
        }

        public void WriteProgressingTourData(string driver, string truck, string from, string to, string freight,
            int tDistance, int jobIncome)
        {
            var stm = new SingleTourModel
            {
                TourId = -1,
                TourDriver = driver,
                TruckUsed = truck,
                TourFrom = from,
                TourTo = to,
                TourFreight = freight,
                TourDistance = tDistance,
                DistanceDriven = 0,
                JobIncome = jobIncome,
                Odo = 0,
                FuelUsed = 0
            };

            using StreamWriter sw = File.CreateText($"./Userdata/progress.dat");

            var fileText = JsonConvert.SerializeObject(stm, Formatting.Indented);
            sw.Write(fileText);
            sw.Dispose();
        }
    }
}
