using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using TourLogger.Models;

namespace TourLogger.Utils
{
	public class PhpIntegration
	{
		public void FetchDatabaseEntries()
		{
			List<TourModel> tours = new List<TourModel>();
			DataWriter dw = new DataWriter();
			string url = "https://enkdev.xyz/cdn/php/tourlogger/test/getToursTest.php";
			string jsonArray;

			using (WebClient wc = new WebClient())
			{
				jsonArray = wc.DownloadString(url);
				wc.Dispose();
			}

			var json = JArray.Parse(jsonArray);

			for (int i = 0; i < GetTotalNumberOfTours(); i++)
			{
                int id = Convert.ToInt32(json[i]["tourId"]);
                string d = (string)json[i]["tourDriver"];
				string f = (string)json[i]["from"];
				string t = (string)json[i]["to"];
				string ff = (string)json[i]["freight"];
				int td = Convert.ToInt32(json[i]["tourDistance"]);
				int tdd = Convert.ToInt32(json[i]["distDriven"]);
				int ji = Convert.ToInt32(json[i]["jobIncome"]);
				int tdt = Convert.ToInt32(json[i]["distanceTotal"]);
				int fff = Convert.ToInt32(json[i]["fuelUsed"]);
				tours.Add(new TourModel(id, d, f, 
                    t, ff, td, 
                    tdd, ji, tdt, 
                    fff));
			}

            dw.WriteCachedData(tours);
		}

        public void SendTourToServer(string driver, string from, string to, string freight, int tourDist,
            int drivenDist, int jobIncome, int odo, int fuel)
        {
            string url = "https://enkdev.xyz/cdn/php/tourlogger/newTour.php?tourDriver=" + driver + "&tourFrom=" +
                         from + "&tourTo=" + to + "&tourFreight=" + freight + "&tourDistance=" + tourDist +
                         "&distanceDriven=" + drivenDist + "&jobIncome=" + jobIncome + "&distanceTotal=" + odo +
                         "&fuelUsed=" + fuel;

            using (WebClient wc = new WebClient())
            {
                wc.DownloadString(url);
                wc.Dispose();
            }
        }

        public string FetchTour(int tourId)
        {
            string tour;
            string url = "https://enkdev.xyz/cdn/php/tourlogger/getTour.php?tId=" + tourId;

            using (WebClient wc = new WebClient())
            {
                byte[] res = wc.DownloadData(url);
                UTF8Encoding utf = new UTF8Encoding();
                tour = utf.GetString(res);
                wc.Dispose();
            }

            return tour;
        }

		private int GetTotalNumberOfTours()
		{
			int tours;
			string url = "https://enkdev.xyz/cdn/php/tourlogger/getTours.php";

			using (WebClient wc = new WebClient())
			{
				string res = wc.DownloadString(url);
				tours = Convert.ToInt32(res);
				wc.Dispose();
			}

			return tours;
		}
    }
}