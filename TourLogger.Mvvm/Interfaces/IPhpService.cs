using System.Threading.Tasks;

namespace TourLogger.Mvvm.Interfaces;

/// <summary>
/// Base implementation for handling server requests and responses.
/// </summary>
public interface IPhpService
{
    /// <summary>
    /// Fetches tours as a page and writes them into a cache.
    /// </summary>
    /// <param name="pageNum">The page number.</param>
    /// <param name="entries">The entries per page. Default = 30</param>
    public void FetchTourEntriesAsync(int pageNum, int entries = 30);

    /// <summary>
    /// Fetches refuels as a page and writes them into a cache.
    /// </summary>
    /// <param name="pageNum">The page number.</param>
    /// <param name="entries">The entries per page. Default = 20</param>
    public void FetchRefuelEntriesAsync(int pageNum, int entries = 20);

    /// <summary>
    /// Fetches a tour with a given Id.
    /// </summary>
    /// <param name="tourId">The Id of the tour.</param>
    public Task<string> FetchTourAsync(int tourId);

    /// <summary>
    /// Fetches a refuel with a given Id.
    /// </summary>
    /// <param name="refuelId">The Id of the refuel.</param>
    public Task<string> FetchRefuelAsync(int refuelId);

    /// <summary>
    /// Sends a tour to the server.
    /// </summary>
    /// <param name="driver">The driver of the tour.</param>
    /// <param name="truck">The truck the driver used for the tour.</param>
    /// <param name="startLocation">The starting location of the tour.</param>
    /// <param name="destination">The destination of the tour.</param>
    /// <param name="freight">The freight the driver transported.</param>
    /// <param name="distance">The distance the tour had in total.</param>
    /// <param name="driven">The actual driven distance the driver has driven.</param>
    /// <param name="income">The income of the tour.</param>
    /// <param name="odo">The total driven distance the driver has driven with their truck.</param>
    /// <param name="fuel">The total amount of fuel burnt in this tour.</param>
    public void SendTourAsync(
        string? driver, string? truck, string? startLocation,
        string? destination, string? freight, int distance,
        int driven, int income, int odo,
        int fuel);

    /// <summary>
    /// Sends a refuel to the server.
    /// </summary>
    /// <param name="driver">The driver who made the refuel.</param>
    /// <param name="country">The country where the driver made the refuel.</param>
    /// <param name="literPrice">The price for a liter of fuel in that country.</param>
    /// <param name="odo">The total driven distance the driver has driven with their truck.</param>
    /// <param name="amount"></param>
    /// <param name="totalPrice"></param>
    public void SendRefuelAsync(
        string? driver, string? country, double literPrice,
        int odo, int amount, int totalPrice);

    /// <summary>
    /// Migrates an old profile to an account.
    /// </summary>
    /// <param name="name">The name of the old profile.</param>
    /// <param name="truck">The truck of the old profile.</param>
    public void MigrateProfileAsync(string? name, string? truck);

    /// <summary>
    /// Creates a new account with a given truck and name.
    /// </summary>
    /// <param name="name">The name of the new account.</param>
    /// <param name="truck">The truck of the new account.</param>
    public void CreateAccountAsync(string? name, string? truck);

    /// <summary>
    /// Gets an account by name.
    /// </summary>
    /// <param name="name">The name of the account.</param>
    /// <returns></returns>
    public Task<string> GetAccountAsync(string? name);

    /// <summary>
    /// Updates the amount of tours someone has driven.
    /// </summary>
    /// <param name="name">The name of the account to update.</param>
    public void UpdateToursOfAccountAsync(string? name);

    /// <summary>
    /// Updates the amount of refuels someone has made.
    /// </summary>
    /// <param name="name">The name of the account to update.</param>
    public void UpdateRefuelsOfAccountAsync(string? name);

    /// <summary>
    /// Updates the Truck of someone.
    /// </summary>
    /// <param name="name">The name of the account to update.</param>
    /// <param name="newTruck">The new truck of the account.</param>
    public void UpdateTruckOfAccountAsync(string? name, string? newTruck);
}