using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using TourLogger.Models;

namespace TourLogger.Utils
{
	public class PhpIntegration
	{
		public List<TourModel> FetchDatabaseEntries()
		{
			List<TourModel> tours = new List<TourModel>();
			string url = "https://enkdev.xyz/cdn/php/tourlogger/test/getToursTest.php";
			string jsonArray = "";

			using (WebClient wc = new WebClient())
			{
				jsonArray = wc.DownloadString(url);
				wc.Dispose();
			}

			var json = JArray.Parse(jsonArray);

			for (int i = 0; i < GetTotalNumberOfTours(); i++)
			{
				int id = Convert.ToInt32(json[i]["tourId"]);
				string d = json[i]["tourDriver"].ToString();
				string f = json[i]["from"].ToString();
				string t = json[i]["to"].ToString();
				string ff = json[i]["freight"].ToString();
				int td = Convert.ToInt32(json[i]["tourDistance"]);
				int tdd = Convert.ToInt32(json[i]["distDriven"]);
				int ji = Convert.ToInt32(json[i]["jobIncome"]);
				int tdt = Convert.ToInt32(json[i]["distanceTotal"]);
				int fff = Convert.ToInt32(json[i]["fuelUsed"]);
				tours.Add(new TourModel(id, d, f, t, ff, td, tdd, ji, tdt, fff));
			}

			return tours;
		}

		public int GetTotalNumberOfTours()
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