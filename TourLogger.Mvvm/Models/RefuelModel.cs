namespace TourLogger.Mvvm.Models;

/// <summary>
/// Model class to reflect a refuel as a .NET object
/// </summary>
public class RefuelModel
{
    public int RefuelId { get; set; }
    public string? Driver { get; set; }
    public string? Country { get; set; }
    public double LiterPrice { get; set; }
    public int Odo { get; set; }
    public int Amount { get; set; }
    public int TotalPrice { get; set; }

    public RefuelModel(
        int refuelId, string? driver, string? country,
        double literPrice, int odo, int amount,
        int totalPrice)
    {
        RefuelId = refuelId; 
        Driver = driver; 
        Country = country; 
        LiterPrice = literPrice;
        Odo = odo;
        Amount = amount;
        TotalPrice = totalPrice;
    }
}