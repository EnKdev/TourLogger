using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TourLogger.Models;

namespace TourLogger.Utils
{
    public class DataWriter
    {
        public void WriteCachedTourData(List<TourModel> tours)
        {
            var ctm = new CacheTourModel
            {
                CachedTours = tours.ToArray()
            };

            using StreamWriter sw = File.CreateText($"./Userdata/tourCache.dat");
            var fileText = JsonConvert.SerializeObject(ctm, Formatting.Indented);
            sw.Write(fileText);
            sw.Dispose();
        }

        public void WriteCachedRefuelData(List<RefuelModel> refuels)
        {
            var crm = new RefuelCacheModel
            {
                CachedRefuels = refuels.ToArray()
            };

            using StreamWriter sw = File.CreateText($"./Userdata/refuelCache.dat");
            var fileText = JsonConvert.SerializeObject(crm, Formatting.Indented);
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

        public void WriteDefaultConfigFile()
        {
            var config = new ConfigModel
            {
                UsingExperimental = false
            };

            using StreamWriter sw = File.CreateText($"./Userdata/config.dat");

            var fileText = JsonConvert.SerializeObject(config, Formatting.Indented);
            sw.Write(fileText);
            sw.Dispose();
        }

        public void WriteConfigFile(bool? useExperimental)
        {
            var config = new ConfigModel
            {
                UsingExperimental = useExperimental
            };

            using StreamWriter sw = File.CreateText($"./Userdata/config.dat");

            var fileText = JsonConvert.SerializeObject(config, Formatting.Indented);
            sw.Write(fileText);
            sw.Dispose();
        }
    }
}
