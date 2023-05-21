using CommunityToolkit.Mvvm.ComponentModel;

namespace TourLogger.Mvvm.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string _accountName;

    [ObservableProperty]
    private string _truckName;

    [ObservableProperty]
    private int _tourCount;

    [ObservableProperty]
    private decimal _accountIncome;

    public MainViewModel()
    {
        AccountName = "Frank Rosin";
        TruckName = "Iveco Stralis";
        TourCount = 30;
        AccountIncome = 1329200;
    }
}