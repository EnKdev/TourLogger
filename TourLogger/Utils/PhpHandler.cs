using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using TourLogger.Models;

namespace TourLogger.Utils
{
    public class PhpHandler
    {
        public void FetchDatabaseEntries()
        {
            var jsonArray = "";
            var tours = new List<TourModel>();
            var dw = new DataWriter();

            var res = HttpPostHelper.HttpPost("https://enkdev.xyz/cdn/php/tourlogger/getTours.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret }
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

            dw.WriteCachedData(tours);
        }

        public string FetchTour(int tourId)
        {
            var res = HttpPostHelper.HttpPost("https://enkdev.xyz/cdn/php/tourlogger/getTour.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "tId", tourId.ToString() }
                });

            var tour = Encoding.UTF8.GetString(res);

            return tour;
        }

        private int GetTotalNumberOfTours()
        {
            var tours = 0;
            var res = HttpPostHelper.HttpPost("https://enkdev.xyz/cdn/php/tourlogger/getTourCount.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret }
                });

            tours = Convert.ToInt32(Encoding.UTF8.GetString(res));
            return tours;
        }

        public void SendTourToServer(string driver, string truck, string from, string to, string freight,
            int tourDistance, int drivenDist, int jobIncome, int odo, int fuel)
        {
            HttpPostHelper.HttpPost("https://enkdev.xyz/cdn/php/tourlogger/newTour.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
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
    }
}