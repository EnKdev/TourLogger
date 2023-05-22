using CommunityToolkit.Mvvm.ComponentModel;
using TourLogger.Mvvm.Interfaces;
using TourLogger.Mvvm.Util;

namespace TourLogger.Mvvm.ViewModels;

public partial class MainViewModel : ObservableObject, ITemplatedViewModel
{
    [ObservableProperty]
    private string _accountName;

    [ObservableProperty]
    private string _truckName;

    [ObservableProperty]
    private int _tourCount;

    [ObservableProperty]
    private string _accountIncomeString;

    [ObservableProperty]
    private long _rawIncome;

    [ObservableProperty]
    private string _appVersion;

    [ObservableProperty]
    private string _compilationDate;

    public void InitDefaultValues()
    {
        // TODO: Set Account Name, Truck, Tour-Count and Total Income once we can do so.

        AppVersion = "TourLogger V" + Constants.AppVersion + " | " + ValueHolder.AppVersion;
        CompilationDate = "Compiled on: " + ValueHolder.CompilationDate;
    }
}