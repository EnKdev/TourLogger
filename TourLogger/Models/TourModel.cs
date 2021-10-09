using System;

namespace TourLogger.Models
{
	public class TourModel
	{
		private int _tId;

		private string _tDriver;

		private string _tTruck;

		private string _tFrom;

		private string _tTo;

		private string _tFreight;

		private int _tDistance;

		private int _tDriven;

		private int _tIncome;

		private int _tTotal;

		private int _tFuel;

		public int Distance
		{
			get
			{
				return this._tDistance;
			}
			set
			{
				this._tDistance = value;
			}
		}

		public int Driven
		{
			get
			{
				return this._tDriven;
			}
			set
			{
				this._tDriven = value;
			}
		}

		public string Driver
		{
			get
			{
				return this._tDriver;
			}
			set
			{
				this._tDriver = value;
			}
		}

		public string Freight
		{
			get
			{
				return this._tFreight;
			}
			set
			{
				this._tFreight = value;
			}
		}

		public string From
		{
			get
			{
				return this._tFrom;
			}
			set
			{
				this._tFrom = value;
			}
		}

		public int Fuel
		{
			get
			{
				return this._tFuel;
			}
			set
			{
				this._tFuel = value;
			}
		}

		public int Id
		{
			get
			{
				return this._tId;
			}
			set
			{
				this._tId = value;
			}
		}

		public int Income
		{
			get
			{
				return this._tIncome;
			}
			set
			{
				this._tIncome = value;
			}
		}

		public string To
		{
			get
			{
				return this._tTo;
			}
			set
			{
				this._tTo = value;
			}
		}

		public int Total
		{
			get
			{
				return this._tTotal;
			}
			set
			{
				this._tTotal = value;
			}
		}

		public string Truck
		{
			get
			{
				return this._tTruck;
			}
			set
			{
				this._tTruck = value;
			}
		}

		public TourModel(int id, string driver, string truck, string from, string to, string freight, int dist, int driven, int income, int total, int fuel)
		{
			this._tId = id;
			this._tDriver = driver;
			this._tTruck = truck;
			this._tFrom = from;
			this._tTo = to;
			this._tFreight = freight;
			this._tDistance = dist;
			this._tDriven = driven;
			this._tIncome = income;
			this._tTotal = total;
			this._tFuel = fuel;
		}
	}
}