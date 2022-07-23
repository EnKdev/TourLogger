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

        public void FetchTourDatabaseEntries(int pageNum, int entries = 30)
        {
            var jsonArray = "";
            var tours = new List<TourModel>();
            var dw = new DataWriter();

            #if STABLE
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/getTours.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersion }
                });
            #elif EXPERIMENTAL
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourloggerExperimental/getTours.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersionExperimental },
                    { "pageNum", pageNum.ToString() },
                    { "entryNum", entries.ToString() }
                });
            #endif
            var resString = Encoding.UTF8.GetString(res);

            jsonArray = resString switch
            {
                "Access denied" => throw new TourLoggerException("Cannot fetch entries. Secret was wrong."),
                "Outdated/Unsupported version!" => throw new TourLoggerException(
                    "Cannot fetch entries. Seems like you're using an outdated app."),
                _ => resString
            };

            var json = JArray.Parse(jsonArray);

            for (var i = 0; i < json.Count; i++)
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

        public void FetchRefuelDatabaseEntries(int pageNum, int entries = 20)
        {
            var jsonArray = "";
            var refuels = new List<RefuelModel>();
            var dw = new DataWriter();

            #if STABLE
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/refuels/getRefuels.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersion },
                });
            #elif EXPERIMENTAL
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourloggerExperimental/refuels/getRefuels.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersionExperimental },
                    { "pageNum", pageNum.ToString() },
                    { "entryNum", entries.ToString() }
                });
            #endif
            var resString = Encoding.UTF8.GetString(res);

            jsonArray = resString switch
            {
                "Access denied" => throw new TourLoggerException("Cannot fetch entries. Secret was wrong."),
                "Outdated/Unsupported Version!" => throw new TourLoggerException(
                    "Cannot fetch entries. Seems like you're using an outdated app."),
                _ => resString
            };

            var json = JArray.Parse(jsonArray);

            for (var i = 0; i < json.Count; i++)
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
            #if STABLE
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/getTour.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersion },
                    { "tId", tourId.ToString() }
                });
            #elif EXPERIMENTAL
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourloggerExperimental/getTour.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersionExperimental },
                    { "tId", tourId.ToString() }
                });
            #endif
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
            #if STABLE
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/refuels/getRefuel.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersion },
                    { "rId", refuelId.ToString() }
                });
            #elif EXPERIMENTAL
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourloggerExperimental/refuels/getRefuel.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersionExperimental },
                    { "rId", refuelId.ToString() }
                });
            #endif
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

        public int GetNumberOfTourPages(int entries = 30)
        {
            var tourPages = 0;

#if STABLE
            // TODO: Implement code for stable release after beta testing
#elif EXPERIMENTAL
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourloggerExperimental/paging/getTourPages.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersionExperimental },
                    { "entryNum", entries.ToString() }
                });
#endif
            var resString = Encoding.UTF8.GetString(res);

            switch (resString)
            {
                case "Access denied":
                    throw new TourLoggerException("Cannot fetch page-count for tours. Secret was wrong.");
                case "Outdated/Unsupported Version!":
                    throw new TourLoggerException(
                        "Cannot fetch page-count for tours. Seems like you're using an outdated app.");
                default:
                    tourPages = int.Parse(Encoding.UTF8.GetString(res));
                    return tourPages;
            }
        }

        public int GetNumberOfRefuelPages(int entries = 20)
        {
            var refuelPages = 0;

#if STABLE
            // TODO: Implement code for stable release after beta testing
#elif EXPERIMENTAL
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourloggerExperimental/paging/getRefuelPages.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersionExperimental },
                    { "entryNum", entries.ToString() }
                });
#endif
            var resString = Encoding.UTF8.GetString(res);

            switch (resString)
            {
                case "Access denied":
                    throw new TourLoggerException("Cannot fetch page-count for tours. Secret was wrong.");
                case "Outdated/Unsupported Version!":
                    throw new TourLoggerException(
                        "Cannot fetch page-count for tours. Seems like you're using an outdated app.");
                default:
                    refuelPages = int.Parse(Encoding.UTF8.GetString(res));
                    return refuelPages;
            }
        }

        #endregion

        #region Send stuff to server

        public void SendTourToServer(string driver, string truck, string from, string to, string freight,
            int tourDistance, int drivenDist, int jobIncome, int odo, int fuel)
        {
            #if STABLE
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/newTour.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersion },
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
            #elif EXPERIMENTAL
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourloggerExperimental/newTour.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersionExperimental },
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
            #endif
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
            #if STABLE
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/refuels/newRefuel.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersion },
                    { "driver", driver },
                    { "country", country },
                    { "literPrice", literPrice.ToString(CultureInfo.InvariantCulture) },
                    { "odo", odo.ToString() },
                    { "amount", amount.ToString() },
                    { "totalPrice", totalPrice.ToString() }
                });
            #elif EXPERIMENTAL
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourloggerExperimental/refuels/newRefuel.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersionExperimental },
                    { "driver", driver },
                    { "country", country },
                    { "literPrice", literPrice.ToString(CultureInfo.InvariantCulture) },
                    { "odo", odo.ToString() },
                    { "amount", amount.ToString() },
                    { "totalPrice", totalPrice.ToString() }
                });
            #endif
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
            #if STABLE
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/accounts/migrateProfile.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersion },
                    { "profile", profileName },
                    { "truck", profileTruck }
                });
            #elif EXPERIMENTAL
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourloggerExperimental/accounts/migrateProfile.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersionExperimental },
                    { "profile", profileName },
                    { "truck", profileTruck }
                });
            #endif

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
            #if STABLE
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/accounts/newAccount.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersion },
                    { "profile", accountName },
                    { "truck", accountTruck }
                });
            #elif EXPERIMENTAL
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourloggerExperimental/accounts/newAccount.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersionExperimental },
                    { "profile", accountName },
                    { "truck", accountTruck }
                });
            #endif

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
            #if STABLE
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/accounts/getAccount.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersion },
                    { "name", accountName }
                });
            #elif EXPERIMENTAL
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourloggerExperimental/accounts/getAccount.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersionExperimental },
                    { "name", accountName }
                }); 
            #endif

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
            #if STABLE
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/accounts/updateProfileTours.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersion },
                    { "profile", accountName }
                });
            #elif EXPERIMENTAL
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourloggerExperimental/accounts/updateProfileTours.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersionExperimental },
                    { "profile", accountName }
                });
            #endif

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
            #if STABLE
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/accounts/updateProfileRefuels.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersion },
                    { "profile", accountName }
                });
            #elif EXPERIMENTAL
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourloggerExperimental/accounts/updateProfileRefuels.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersionExperimental },
                    { "profile", accountName }
                });
            #endif
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
            #if STABLE
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourlogger/accounts/updateProfileTruck.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersion },
                    { "profile", accountName },
                    { "truck", newTruck }
                });
            #elif EXPERIMENTAL
            var res = HttpPostHelper.HttpPost(
                "https://enkdev.xyz/cdn/php/tourloggerExperimental/accounts/updateProfileTruck.experimental.php",
                new NameValueCollection
                {
                    { "secret", SecretGrabber.AppSecret },
                    { "version", InternalValues.AppVersionExperimental },
                    { "profile", accountName },
                    { "truck", newTruck }
                });
            #endif
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
