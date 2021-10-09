using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;
using TourLogger.Models;

namespace TourLogger.Utils
{
	public class PhpIntegration
	{
		public PhpIntegration()
		{
		}

		public bool[] CheckVersions()
		{
			string verString;
			bool[] versionsAreValid = new bool[4];
			string urlVersions = "https://enkdev.xyz/cdn/php/tourlogger/versions.php";
			string[] verStrings = new string[4];
			using (WebClient wc = new WebClient())
			{
				byte[] res = wc.DownloadData(urlVersions);
				verString = (new UTF8Encoding()).GetString(res);
				wc.Dispose();
			}
			verString = verString.Replace("~|~", "|");
			verStrings = verString.Split(new char[] { '|' });
			if (Versioning.AppVersion != verStrings[0])
			{
				versionsAreValid[0] = false;
			}
			else
			{
				versionsAreValid[0] = true;
			}
			if (Versioning.AppFileVersion != verStrings[1])
			{
				versionsAreValid[1] = false;
			}
			else
			{
				versionsAreValid[1] = true;
			}
			if (Versioning.DbVersion != verStrings[2])
			{
				versionsAreValid[2] = false;
			}
			else
			{
				versionsAreValid[2] = true;
			}
			if (Versioning.SecretVersion != verStrings[3])
			{
				versionsAreValid[3] = false;
			}
			else
			{
				versionsAreValid[3] = true;
			}
			return versionsAreValid;
		}

		public void FetchDatabaseEntries()
		{
			string jsonArray;
			List<TourModel> tours = new List<TourModel>();
			DataWriter dw = new DataWriter();
			string url = string.Concat("https://enkdev.xyz/cdn/php/tourlogger/getTours.php?secret=", Versioning.AppSecret);
			using (WebClient wc = new WebClient())
			{
				jsonArray = wc.DownloadString(url);
				wc.Dispose();
			}
			JArray json = JArray.Parse(jsonArray);
			for (int i = 0; i < this.GetTotalNumberOfTours(); i++)
			{
				int id = Convert.ToInt32(json[i]["tourId"]);
				string d = (string)json[i]["tourDriver"];
				string t = (string)json[i]["truckUsed"];
				string f = (string)json[i]["from"];
				string tt = (string)json[i]["to"];
				string ff = (string)json[i]["freight"];
				int td = Convert.ToInt32(json[i]["tourDistance"]);
				int tdd = Convert.ToInt32(json[i]["distDriven"]);
				int ji = Convert.ToInt32(json[i]["jobIncome"]);
				int tdt = Convert.ToInt32(json[i]["distanceTotal"]);
				int fff = Convert.ToInt32(json[i]["fuelUsed"]);
				tours.Add(new TourModel(id, d, t, f, tt, ff, td, tdd, ji, tdt, fff));
			}
			dw.WriteCachedData(tours);
		}

		public string FetchTour(int tourId)
		{
			string tour;
			string url = string.Concat("https://enkdev.xyz/cdn/php/tourlogger/getTour.php?secret=", Versioning.AppSecret, "&tId=", tourId.ToString());
			using (WebClient wc = new WebClient())
			{
				byte[] res = wc.DownloadData(url);
				tour = (new UTF8Encoding()).GetString(res);
				wc.Dispose();
			}
			return tour;
		}

		private int GetTotalNumberOfTours()
		{
			int tours;
			string url = string.Concat("https://enkdev.xyz/cdn/php/tourlogger/getTourCount.php?secret=", Versioning.AppSecret);
			using (WebClient wc = new WebClient())
			{
				tours = Convert.ToInt32(wc.DownloadString(url));
				wc.Dispose();
			}
			return tours;
		}

		public void SendTourToServer(string driver, string truckUsed, string from, string to, string freight, int tourDist, int drivenDist, int jobIncome, int odo, int fuel)
		{
			string url = string.Concat(new string[] { "https://enkdev.xyz/cdn/php/tourlogger/newTour.php?secret=", Versioning.AppSecret, "&tourDriver=", driver, "&tourTruck=", truckUsed, "&tourFrom=", from, "&tourTo=", to, "&tourFreight=", freight, "&tourDistance=", tourDist.ToString(), "&distanceDriven=", drivenDist.ToString(), "&jobIncome=", jobIncome.ToString(), "&distanceTotal=", odo.ToString(), "&fuelUsed=", fuel.ToString() });
			using (WebClient wc = new WebClient())
			{
				wc.DownloadString(url);
				wc.Dispose();
			}
		}
	}
}