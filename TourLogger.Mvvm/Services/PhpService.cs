using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TourLogger.Mvvm.Exceptions;
using TourLogger.Mvvm.Interfaces;
using TourLogger.Mvvm.Models;
using TourLogger.Mvvm.Util;

namespace TourLogger.Mvvm.Services;

/// <summary>
/// See the documentation of <see cref="IPhpService"/>
/// </summary>
public class PhpService : IPhpService
{
    private readonly IDataService _dataService;
    private readonly ISecretService _secretService;

    /// <summary>
    /// Standard constructor
    /// </summary>
    /// <param name="dataService">The data service.</param>
    /// <param name="secretService">The secret service.</param>
    public PhpService(IDataService dataService, ISecretService secretService)
    {
        _dataService = dataService;
        _secretService = secretService;
    }

    /// <inheritdoc />
    public async void FetchTourEntriesAsync(int pageNum, int entries = 30)
    {
        var jsonArray = "";

#if STABLE
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourlogger/getTours.php",
            new Dictionary<string, string>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "pageNum", pageNum.ToString() },
                { "entryNum", entries.ToString() }
            });
#elif EXPERIMENTAL
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourloggerExperimental/getTours.experimental.php",
            new Dictionary<string, string?>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "pageNum", pageNum.ToString() },
                { "entryNum", entries.ToString() }
            });
#endif

        jsonArray = res switch
        {
            "Access denied" => throw new TourLoggerException("Cannot fetch entries. Secret was wrong."),
            "Outdated/Unsupported Version!" => throw new TourLoggerException(
                "Cannot fetch entries. Seems like you're using an outdated app."),
            _ => res
        };

        var json = JArray.Parse(jsonArray);

        var tours = (
            from t1 in json
            let id = Convert.ToInt32(t1["tourId"])
            let d = (string)t1["tourDriver"]!
            let t = (string)t1["truckUsed"]!
            let f = (string)t1["from"]!
            let tt = (string)t1["to"]!
            let ff = (string)t1["freight"]!
            let td = Convert.ToInt32(t1["tourDistance"])
            let tdd = Convert.ToInt32(t1["distDriven"])
            let ji = Convert.ToInt32(t1["jobIncome"])
            let tdt = Convert.ToInt32(t1["distanceTotal"])
            let fff = Convert.ToInt32(t1["fuelUsed"])
            select new TourModel(id, d, t, f, tt, ff, td, tdd, ji, tdt, fff)
        ).ToList();

        _dataService.WriteCachedTourData(tours);
    }

    /// <inheritdoc />
    public async void FetchRefuelEntriesAsync(int pageNum, int entries = 20)
    {
        var jsonArray = "";

#if STABLE
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourlogger/getRefuels.php",
            new Dictionary<string, string>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "pageNum", pageNum.ToString() },
                { "entryNum", entries.ToString() }
            });
#elif EXPERIMENTAL
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourloggerExperimental/refuels/getRefuels.experimental.php",
            new Dictionary<string, string?>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "pageNum", pageNum.ToString() },
                { "entryNum", entries.ToString() }
            });
#endif

        jsonArray = res switch
        {
            "Access denied" => throw new TourLoggerException("Cannot fetch entries. Secret was wrong."),
            "Outdated/Unsupported Version!" => throw new TourLoggerException(
                "Cannot fetch entries. Seems like you're using an outdated app."),
            _ => res
        };

        var json = JArray.Parse(jsonArray);

        var refuels = (
            from t in json
            let id = Convert.ToInt32(t["refuelId"])
            let d = (string)t["refuelDriver"]!
            let c = (string)t["refuelCountry"]!
            let rpl = Convert.ToDouble(t["refuelPrice"])
            let ro = Convert.ToInt32(t["refuelOdo"])
            let ra = Convert.ToInt32(t["refuelAmount"])
            let rtp = Convert.ToInt32(t["refuelTotalPrice"])
            select new RefuelModel(id, d, c, rpl, ro, ra, rtp)
        ).ToList();

        _dataService.WriteCachedRefuelData(refuels);
    }

    /// <inheritdoc />
    public async void SendTourAsync(
        string? driver, string? truck, string? startLocation, 
        string? destination, string? freight, int distance,
        int driven, int income, int odo, int fuel)
    {
#if STABLE
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourlogger/newTour.php",
            new Dictionary<string, string>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "tourDriver", driver },
                { "tourTruck", truck },
                { "tourFrom", startLocation },
                { "tourTo", destination },
                { "tourFreight", freight },
                { "tourDistance", distance.ToString() },
                { "distanceDriven", driven.ToString() },
                { "jobIncome", income.ToString() },
                { "distanceTotal", odo.ToString() },
                { "fuelUsed", fuel.ToString() }
            });
#elif EXPERIMENTAL
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourloggerExperimental/newTour.experimental.php",
            new Dictionary<string, string?>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "tourDriver", driver },
                { "tourTruck", truck },
                { "tourFrom", startLocation },
                { "tourTo", destination },
                { "tourFreight", freight },
                { "tourDistance", distance.ToString() },
                { "distanceDriven", driven.ToString() },
                { "jobIncome", income.ToString() },
                { "distanceTotal", odo.ToString() },
                { "fuelUsed", fuel.ToString() }
            });
#endif

        switch (res)
        {
            case "Access denied":
                throw new TourLoggerException("Cannot send tour to server. Secret was wrong.");
            case "Outdated/Unsupported Version!":
                throw new TourLoggerException("Cannot send tour to server. Seems like you're using an outdated app.");
        }
    }

    /// <inheritdoc />
    public async void SendRefuelAsync(
        string? driver, string? country, double literPrice, 
        int odo, int amount, int totalPrice)
    {

#if STABLE
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourlogger/newRefuel.php",
            new Dictionary<string, string>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "driver", driver },
                { "country", country},
                { "literPrice", literPrice.ToString(CultureInfo.InvariantCulture) },
                { "odo", odo.ToString() },
                { "amount", amount.ToString() },
                { "totalPrice", totalPrice.ToString() }
            });
#elif EXPERIMENTAL
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourloggerExperimental/newRefuel.experimental.php",
            new Dictionary<string, string?>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "driver", driver },
                { "country", country},
                { "literPrice", literPrice.ToString(CultureInfo.InvariantCulture) },
                { "odo", odo.ToString() },
                { "amount", amount.ToString() },
                { "totalPrice", totalPrice.ToString() }
            });
#endif

        switch (res)
        {
            case "Access denied":
                throw new TourLoggerException("Cannot send refuel to server. Secret was wrong.");
            case "Outdated/Unsupported Version!":
                throw new TourLoggerException("Cannot send refuel to server. Seems like you're using an outdated app.");
        }
    }

    /// <inheritdoc />
    public async void CreateAccountAsync(string? name, string? truck)
    {
#if STABLE
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourlogger/accounts/newAccount.php",
            new Dictionary<string, string>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "profile", name },
                { "truck", truck }
            });
#elif EXPERIMENTAL
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourloggerExperimental/accounts/newAccount.experimental.php",
            new Dictionary<string, string?>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "profile", name },
                { "truck", truck }
            });
#endif

        switch (res)
        {
            case "Access denied":
                throw new TourLoggerException("Cannot create a new account. Secret was wrong.");
            case "Outdated/Unsupported Version!":
                throw new TourLoggerException("Cannot create a new account. Seems like you're using an outdated app.");
        }
    }

    /// <inheritdoc />
    public async Task<string> GetAccountAsync(string? name)
    {
#if STABLE
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourlogger/accounts/getAccount.php",
            new Dictionary<string, string>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "name", name }
            });
#elif EXPERIMENTAL
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourloggerExperimental/account/getAccount.experimental.php",
            new Dictionary<string, string?>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "name", name }
            });
        #endif

        return res switch
        {
            "Access denied" => throw new TourLoggerException("Cannot get specified account. Secret was wrong."),
            "Outdated/Unsupported Version!" => throw new TourLoggerException("Cannot get specified account. Seems like you're using an outdated app."),
            _ => res
        };
    }

    /// <inheritdoc />
    public async void UpdateToursOfAccountAsync(string? name)
    {
        #if STABLE
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourlogger/accounts/updateProfileTours.php",
            new Dictionary<string, string>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "profile", name }
            });
#elif EXPERIMENTAL
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourloggerExperimental/accounts/updateProfileTours.experimental.php",
            new Dictionary<string, string?>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "profile", name }
            });
        #endif

        switch (res)
        {
            case "Access denied":
                throw new TourLoggerException("Cannot update tours of your account. Secret was wrong.");
            case "Outdated/Unsupported Version!":
                throw new TourLoggerException("Cannot update tours of your account. Seems like you're using an outdated app.");
        }
    }

    /// <inheritdoc />
    public async void UpdateRefuelsOfAccountAsync(string? name)
    {
#if STABLE
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourlogger/accounts/updateProfileRefuels.php",
            new Dictionary<string, string>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "profile", name }
            });
#elif EXPERIMENTAL
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourloggerExperimental/accounts/updateProfileRefuels.experimental.php",
            new Dictionary<string, string?>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "profile", name }
            });
#endif

        switch (res)
        {
            case "Access denied":
                throw new TourLoggerException("Cannot update refuels of your account. Secret was wrong.");
            case "Outdated/Unsupported Version!":
                throw new TourLoggerException("Cannot update refuels of your account. Seems like you're using an outdated app.");
        }
    }

    /// <inheritdoc />
    public async void UpdateTruckOfAccountAsync(string? name, string? newTruck)
    {
#if STABLE
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourlogger/accounts/updateProfileTruck.php",
            new Dictionary<string, string>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "profile", name },
            });
#elif EXPERIMENTAL
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourloggerExperimental/accounts/updateProfileTruck.experimental.php",
            new Dictionary<string, string?>
            {
                { "secret", ValueHolder.AppSecret },
                { "version", Constants.AppVersion },
                { "profile", name },
                { "truck", newTruck }
            });
#endif

        switch (res)
        {
            case "Access denied":
                throw new TourLoggerException("Cannot update truck of your account. Secret was wrong.");
            case "Outdated/Unsupported Version!":
                throw new TourLoggerException("Cannot update truck of your account. Seems like you're using an outdated app.");
        }
    }

    /// <inheritdoc />
    public async Task<int> GetNumberOfTourPages(int entries = 30)
    {
        var tourPages = 0;
        
#if STABLE
        // TODO: Stable implementation
#elif EXPERIMENTAL
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourloggerExperimental/paging/getTourPages.experimental.php",
            new Dictionary<string, string?>
            {
                {"secret", ValueHolder.AppSecret},
                {"version", Constants.AppVersion},
                {"entryNum", entries.ToString()}
            });
#endif

        switch (res)
        {
            case "Access denied":
                throw new TourLoggerException("Cannot fetch page-count for tours. Secret was wrong.");
            case "Outdated/Unsupported Version!":
                throw new TourLoggerException(
                    "Cannot fetch page-count for tours. Seems like you're using an outdated app.");
            default:
                tourPages = int.Parse(res);
                return tourPages;
        }
    }

    /// <inheritdoc />
    public async Task<int> GetNumberOfRefuelPages(int entries = 20)
    {
        var refuelPages = 0;
        
#if STABLE
        // TODO: Stable implementation
#elif EXPERIMENTAL
        var res = await HttpPost.PostAsync(
            "https://enkdev.xyz/cdn/php/tourloggerExperimental/paging/getRefuelPages.experimental.php",
            new Dictionary<string, string?>
            {
                {"secret", ValueHolder.AppSecret},
                {"version", Constants.AppVersion},
                {"entryNum", entries.ToString()}
            });
#endif

        switch (res)
        {
            case "Access denied":
                throw new TourLoggerException("Cannot fetch page-count for tours. Secret was wrong.");
            case "Outdated/Unsupported Version!":
                throw new TourLoggerException(
                    "Cannot fetch page-count for tours. Seems like you're using an outdated app.");
            default:
                refuelPages = int.Parse(res);
                return refuelPages;
        }
    }
}