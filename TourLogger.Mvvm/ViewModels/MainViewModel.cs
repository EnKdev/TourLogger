using CommunityToolkit.Mvvm.ComponentModel;
using TourLogger.Mvvm.Interfaces;
using TourLogger.Mvvm.Util;

namespace TourLogger.Mvvm.ViewModels;

public partial class MainViewModel : ObservableObject, ITemplatedViewModel
{
    private readonly IPhpService _phpService;

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

    [ObservableProperty]
    private int _currentTourPage;

    [ObservableProperty]
    private int _totalTourPages;

    [ObservableProperty]
    private int _currentRefuelPage;

    [ObservableProperty]
    private int _totalRefuelPages;

    public MainViewModel(IPhpService phpService)
    {
        _phpService = phpService;
    }

    public void InitDefaultValues()
    {
        // TODO: Set Account Name, Truck, Tour-Count and Total Income once we can do so.

        AccountName = ValueHolder.AccountName!;
        TruckName = ValueHolder.TruckUsed!;
        TourCount = ValueHolder.ToursDriven;
        AccountIncomeString = ValueHolder.AccountIncome.ToString("N0") + " €";

        AppVersion = "TourLogger V" + Constants.AppVersion + " | " + ValueHolder.AppVersion;
        CompilationDate = "Compiled on: " + ValueHolder.CompilationDate;

        CurrentTourPage = 1;
        CurrentRefuelPage = 1;

        FetchCurrentPageNumbers();

    }

    private async void FetchCurrentPageNumbers()
    {
        TotalTourPages = await _phpService.GetNumberOfTourPages();
        TotalRefuelPages = await _phpService.GetNumberOfRefuelPages();
    }
}