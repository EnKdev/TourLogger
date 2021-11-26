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
        #region Fetch database stuff

        public void FetchTourDatabaseEntries()
        {
            var jsonArray = "";
            var tours = new List<TourModel>();
            var dw = new DataWriter();

            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/getTours.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalVersion.AppVersion }
                });
            var resString = Encoding.UTF8.GetString(res);

            jsonArray = resString switch
            {
                "Access denied" => throw new TourLoggerException("Cannot fetch entries. Secret was wrong."),
                "Outdated/Unsupported version!" => throw new TourLoggerException(
                    "Cannot fetch entries. Seems like you're using an outdated app."),
                _ => resString
            };

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
                "https://enkdev.xyz/cdn/php/tourlogger/refuels/getRefuels.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalVersion.AppVersion },
                });
            var resString = Encoding.UTF8.GetString(res);

            jsonArray = resString switch
            {
                "Access denied" => throw new TourLoggerException("Cannot fetch entries. Secret was wrong."),
                "Outdated/Unsupported Version!" => throw new TourLoggerException(
                    "Cannot fetch entries. Seems like you're using an outdated app."),
                _ => resString
            };

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

        #endregion

        #region Fetch single stuff

        public string FetchTour(int tourId)
        {
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/getTour.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalVersion.AppVersion },
                    { "tId", tourId.ToString() }
                });
            var resString = Encoding.UTF8.GetString(res);

            switch (resString)
            {
                case "Access denied":
                    throw new TourLoggerException("Cannot fetch tour. Secret was wrong.");
                case "Outdated/Unsupported Version!":
                    throw new TourLoggerException("Cannot fetch tour. Seems like you're using an outdated app.");
                default:
                {
                    var tour = Encoding.UTF8.GetString(res);
                    return tour;
                }
            }
        }

        public string FetchRefuel(int refuelId)
        {
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/refuels/getRefuel.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalVersion.AppVersion },
                    { "rId", refuelId.ToString() }
                });
            var resString = Encoding.UTF8.GetString(res);

            switch (resString)
            {
                case "Access denied":
                    throw new TourLoggerException("Cannot fetch refuel. Secret was wrong.");
                case "Outdated/Unsupported Version!":
                    throw new TourLoggerException("Cannot fetch refuel. Seems like you're using an outdated app.");
                default:
                {
                    var refuel = Encoding.UTF8.GetString(res);
                    return refuel;
                }
            }
        }

        #endregion

        #region Total number of x Stuff
        private int GetTotalNumberOfTours()
        {
            var tours = 0;
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/getTourCount.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalVersion.AppVersion },
                });
            var resString = Encoding.UTF8.GetString(res);

            switch (resString)
            {
                case "Access denied":
                    throw new TourLoggerException("Cannot fetch tour-count. Secret was wrong.");
                case "Outdated/Unsupported version!":
                    throw new TourLoggerException("Cannot fetch tour-count. Seems like you're using an outdated app.");
                default:
                    tours = int.Parse(Encoding.UTF8.GetString(res));
                    return tours;
            }

            
        }

        private int GetTotalNumberOfRefuels()
        {
            var refuels = 0;
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/refuels/getRefuelCount.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalVersion.AppVersion }
                });
            var resString = Encoding.UTF8.GetString(res);

            switch (resString)
            {
                case "Access denied":
                    throw new TourLoggerException("Cannot fetch refuel-count. Secret was wrong.");
                case "Outdated/Unsupported Version!":
                    throw new TourLoggerException("Cannot fetch refuel-count. Seems like you're using an outdated app.");
                default:
                    refuels = int.Parse(Encoding.UTF8.GetString(res));
                    return refuels;
            }
        }

        #endregion

        #region Send stuff to server

        public void SendTourToServer(string driver, string truck, string from, string to, string freight,
            int tourDistance, int drivenDist, int jobIncome, int odo, int fuel)
        {
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/newTour.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalVersion.AppVersion },
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
            var resString = Encoding.UTF8.GetString(res);

            switch (resString)
            {
                case "Access denied":
                    throw new TourLoggerException("Cannot send tour to server. Secret was wrong.");
                case "Outdated/Unsupported Version!":
                    throw new TourLoggerException("Cannot send tour to server. Seems like you're using an outdated app.");
            }
        }

        public void SendRefuelToServer(string driver, string country, double literPrice, int odo, int amount,
            int totalPrice)
        {
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/refuels/newRefuel.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalVersion.AppVersion },
                    { "driver", driver },
                    { "country", country },
                    { "literPrice", literPrice.ToString(CultureInfo.InvariantCulture) },
                    { "odo", odo.ToString() },
                    { "amount", amount.ToString() },
                    { "totalPrice", totalPrice.ToString() }
                });
            var resString = Encoding.UTF8.GetString(res);

            switch (resString)
            {
                case "Access denied":
                    throw new TourLoggerException("Cannot send refuel to server. Secret was wrong.");
                case "Outdated/Unsupported Version!":
                    throw new TourLoggerException("Cannot send refuel to server. Seems like you're using an outdated app.");
            }
        }

        #endregion

        #region Accounts

        public void MigrateProfile(string profileName, string profileTruck)
        {
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/accounts/migrateProfile.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalVersion.AppVersion },
                    { "profile", profileName },
                    { "truck", profileTruck }
                });
            var resString = Encoding.UTF8.GetString(res);

            switch (resString)
            {
                case "Access denied":
                    throw new TourLoggerException("Cannot migrate profile to an account. Secret was wrong.");
                case "Outdated/Unsupported Version!":
                    throw new TourLoggerException("Cannot migrate profile to an account. Seems like you're using an outdated app.");
            }
        }

        public void CreateAccount(string accountName, string accountTruck)
        {
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/accounts/newAccount.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalVersion.AppVersion },
                    { "profile", accountName },
                    { "truck", accountTruck }
                });
            var resString = Encoding.UTF8.GetString(res);

            switch (resString)
            {
                case "Access denied":
                    throw new TourLoggerException("Cannot create a new account. Secret was wrong.");
                case "Outdated/Unsupported Version!":
                    throw new TourLoggerException("Cannot create a new account. Seems like you're using an outdated app.");
            }
        }

        public string GetAccount(string accountName)
        {
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/accounts/getAccount.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalVersion.AppVersion },
                    { "name", accountName }
                });
            var resString = Encoding.UTF8.GetString(res);

            switch (resString)
            {
                case "Access denied":
                    throw new TourLoggerException("Cannot get specified account. Secret was wrong.");
                case "Outdated/Unsupported Version!":
                    throw new TourLoggerException("Cannot get specified account. Seems like you're using an outdated app.");
                default:
                {
                    var account = Encoding.UTF8.GetString(res);
                    return account;
                }
            }
        }

        public void UpdateAccountTours(string accountName)
        {
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/accounts/updateProfileTours.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalVersion.AppVersion },
                    { "profile", accountName }
                });
            var resString = Encoding.UTF8.GetString(res);

            switch (resString)
            {
                case "Access denied":
                    throw new TourLoggerException("Cannot migrate profile to an account. Secret was wrong.");
                case "Outdated/Unsupported Version!":
                    throw new TourLoggerException("Cannot migrate profile to an account. Seems like you're using an outdated app.");
            }
        }

        public void UpdateAccountRefuels(string accountName)
        {
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/accounts/updateProfileRefuels.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalVersion.AppVersion },
                    { "profile", accountName }
                });
            var resString = Encoding.UTF8.GetString(res);

            switch (resString)
            {
                case "Access denied":
                    throw new TourLoggerException("Cannot migrate profile to an account. Secret was wrong.");
                case "Outdated/Unsupported Version!":
                    throw new TourLoggerException("Cannot migrate profile to an account. Seems like you're using an outdated app.");
            }
        }

        public void UpdateAccountTruck(string accountName, string newTruck)
        {
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/accounts/updateProfileTruck.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalVersion.AppVersion },
                    { "profile", accountName },
                    { "truck", newTruck }
                });
            var resString = Encoding.UTF8.GetString(res);

            switch (resString)
            {
                case "Access denied":
                    throw new TourLoggerException("Cannot migrate profile to an account. Secret was wrong.");
                case "Outdated/Unsupported version!":
                    throw new TourLoggerException("Cannot migrate profile to an account. Seems like you're using an outdated app.");
            }
        }

        #endregion
    }
}
