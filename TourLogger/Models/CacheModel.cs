using Newtonsoft.Json;
using System;
using System.Runtime.CompilerServices;

namespace TourLogger.Models
{
	public class CacheModel
	{
		[JsonProperty("cachedTours")]
		public TourModel[] CachedTours
		{
			get;
			set;
		}

		public CacheModel()
		{
		}
	}
}