using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;
using Newtonsoft.Json.Linq;
using TourLogger.Models;

namespace TourLogger.Utils
{
    public class PhpHandler
    {
        public void FetchTourDatabaseEntries()
        {
            var jsonArray = "";
            var tours = new List<TourModel>();
            var dw = new DataWriter();

            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/experimental/getTours.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", "7.0.0-beta1" }
                });

            jsonArray = Encoding.UTF8.GetString(res);
            var json = JArray.Parse(jsonArray);

            for (var i = 0; i < GetTotalNumberOfTours(); i++)
            {
                var id = Convert.ToInt32(json[i]["tourId"]);
                var d = (string)json[i]["tourDriver"];
                var t = (string)json[i]["truckUsed"];
                var f = (string)json[i]["from"];
                var tt = (string)json[i]["to"];
                var ff = (string)json[i]["freight"];
                var td = Convert.ToInt32(json[i]["tourDistance"]);
                var tdd = Convert.ToInt32(json[i]["distDriven"]);
                var ji = Convert.ToInt32(json[i]["jobIncome"]);
                var tdt = Convert.ToInt32(json[i]["distanceTotal"]);
                var fff = Convert.ToInt32(json[i]["fuelUsed"]);

                tours.Add(new TourModel(id, d, t, f, tt, ff, td, tdd, ji, tdt, fff));
            }

            dw.WriteCachedTourData(tours);
        }

        public void FetchRefuelDatabaseEntries()
        {
            var jsonArray = "";
            var refuels = new List<RefuelModel>();
            var dw = new DataWriter();

            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/experimental/refuels/getRefuels.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", "7.0.0-beta1" },
                });

            jsonArray = Encoding.UTF8.GetString(res);
            var json = JArray.Parse(jsonArray);

            for (var i = 0; i < GetTotalNumberOfRefuels(); i++)
            {
                var id = Convert.ToInt32(json[i]["refuelId"]);
                var d = (string)json[i]["refuelDriver"];
                var c = (string)json[i]["refuelCountry"];
                var rpl = Convert.ToDouble(json[i]["refuelPrice"]);
                var ro = Convert.ToInt32(json[i]["refuelOdo"]);
                var ra = Convert.ToInt32(json[i]["refuelAmount"]);
                var rtp = Convert.ToInt32(json[i]["refuelTotalPrice"]);

                refuels.Add(new RefuelModel(id, d, c, rpl, ro, ra, rtp));
            }

            dw.WriteCachedRefuelData(refuels);
        }

        public string FetchTour(int tourId)
        {
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/experimental/getTour.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", "7.0.0-beta1" },
                    { "tId", tourId.ToString() }
                });

            var tour = Encoding.UTF8.GetString(res);

            return tour;
        }

        public string FetchRefuel(int refuelId)
        {
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/experimental/refuels/getRefuel.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", "7.0.0-beta1" },
                    { "rId", refuelId.ToString() }
                });

            var refuel = Encoding.UTF8.GetString(res);

            return refuel;
        }

        private int GetTotalNumberOfTours()
        {
            var tours = 0;
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/experimental/getTourCount.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", "7.0.0-beta1" },
                });

            tours = int.Parse(Encoding.UTF8.GetString(res));
            return tours;
        }

        private int GetTotalNumberOfRefuels()
        {
            var refuels = 0;
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/experimental/refuels/getRefuelCount.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", "7.0.0-beta1" }
                });

            refuels = int.Parse(Encoding.UTF8.GetString(res));
            return refuels;
        }

        public void SendTourToServer(string driver, string truck, string from, string to, string freight,
            int tourDistance, int drivenDist, int jobIncome, int odo, int fuel)
        {
            HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/experimental/newTour.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", "7.0.0-beta1" },
                    { "tourDriver", driver },
                    { "tourTruck", truck },
                    { "tourFrom", from },
                    { "tourTo", to },
                    { "tourFreight", freight },
                    { "tourDistance", tourDistance.ToString() },
                    { "distanceDriven", drivenDist.ToString() },
                    { "jobIncome", jobIncome.ToString() },
                    { "distanceTotal", odo.ToString() },
                    { "fuelUsed", fuel.ToString() }
                });
        }

        public void SendRefuelToServer(string driver, string country, double literPrice, int odo, int amount,
            int totalPrice)
        {
            HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/experimental/refuels/newRefuel.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", "7.0.0-beta1" },
                    { "driver", driver },
                    { "country", country },
                    { "literPrice", literPrice.ToString(CultureInfo.InvariantCulture) },
                    { "odo", odo.ToString() },
                    { "amount", amount.ToString() },
                    { "totalPrice", totalPrice.ToString() }
                });
        }
    }
}
