using Newtonsoft.Json;
using System;
using System.Runtime.CompilerServices;

namespace TourLogger.Models
{
	public class TruckModel
	{
		[JsonProperty("driver")]
		public string Driver
		{
			get;
			set;
		}

		[JsonProperty("truck")]
		public string Truck
		{
			get;
			set;
		}

		public TruckModel()
		{
		}
	}
}