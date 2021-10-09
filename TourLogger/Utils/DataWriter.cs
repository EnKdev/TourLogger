using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TourLogger.Models;

namespace TourLogger.Utils
{
	public class DataWriter
	{
		private SingleTourModel _stm;

		private CacheModel _cm;

		public DataWriter()
		{
		}

		private void FlushCacheModel()
		{
			this._cm = null;
		}

		private void FlushSingleTourModel()
		{
			this._stm = null;
		}

		public void WriteCachedData(List<TourModel> tours)
		{
			this._cm = new CacheModel()
			{
				CachedTours = tours.ToArray()
			};
			using (StreamWriter sw = File.CreateText("./Userdata/cache.dat"))
			{
				sw.Write(JsonConvert.SerializeObject(this._cm, Formatting.Indented));
				sw.Dispose();
			}
			this.FlushCacheModel();
		}

		public void WriteProgressingTourData(string driver, string truck, string from, string to, string freight, int tDistance, int jobIncome)
		{
			this._stm = new SingleTourModel()
			{
				TourId = (long)-1,
				TourDriver = driver,
				TruckUsed = truck,
				TourFrom = from,
				TourTo = to,
				TourFreight = freight,
				TourDistance = (long)tDistance,
				DistanceDriven = (long)0,
				JobIncome = (long)jobIncome,
				Odo = (long)0,
				FuelUsed = (long)0
			};
			using (StreamWriter sw = File.CreateText("./Userdata/progress.dat"))
			{
				sw.Write(JsonConvert.SerializeObject(this._stm, Formatting.Indented));
				sw.Dispose();
			}
			this.FlushSingleTourModel();
		}
	}
}