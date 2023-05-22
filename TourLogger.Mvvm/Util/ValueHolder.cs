using EnKdev.EnKVer;

namespace TourLogger.Mvvm.Util;

/// <summary>
/// Helper class to hold various values for various purposes.
/// </summary>
public static class ValueHolder
{
    /// <summary>
    /// The name of a new account
    /// </summary>
    public static string? NewAccountName { get; set; }
    
    /// <summary>
    /// The secret for the apps backend
    /// </summary>
    public static string? AppSecret { get; set; }
    
    /// <summary>
    /// The secret for the compilation database
    /// </summary>
    public static string? CompilationSecret { get; set; }
    
    /// <summary>
    /// The <see cref="EnKVer2"/>-Version of the app.
    /// </summary>
    public static string? AppVersion { get; set; }
    
    /// <summary>
    /// The compilation date of the app.
    /// </summary>
    public static string? CompilationDate { get; set; }

    /// <summary>
    /// The name of the currently used account.
    /// </summary>
    public static string? AccountName { get; set; }
    
    /// <summary>
    /// The name of the currently used truck.
    /// </summary>
    public static string? TruckUsed { get; set; }
    
    /// <summary>
    /// Total incurred income the truck driver made.
    /// </summary>
    public static long AccountIncome { get; set; }
    
    /// <summary>
    /// Total driven tours.
    /// </summary>
    public static int ToursDriven { get; set; }
}