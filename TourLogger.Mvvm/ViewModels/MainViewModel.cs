using System.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

    [RelayCommand]
    public void NextTablePage(object table)
    {
        var tbl = (string) table;

        switch (tbl)
        {
            case "Tour":
            {
                if (CurrentTourPage > TotalTourPages)
                {
                    CurrentTourPage = TotalTourPages; // Clamp to prevent boundary overflow.
                }
                else
                {
                    CurrentTourPage++;
                }
                
                _phpService.FetchTourEntriesAsync(CurrentTourPage);
            }
                break;
            case "Refuel":
            {
                if (CurrentRefuelPage > TotalRefuelPages)
                {
                    CurrentRefuelPage = TotalRefuelPages; // Clamp to prevent boundary overflow.
                }

                CurrentRefuelPage++;
                _phpService.FetchRefuelEntriesAsync(CurrentRefuelPage);
            }
                break;
        }
    }

    [RelayCommand]
    public void PreviousTablePage(object table)
    {
        var tbl = (string) table;
        
        switch (tbl)
        {
            case "Tour":
            {
                if (CurrentTourPage < 1)
                {
                    CurrentTourPage = 1; // Clamp to prevent boundary underflow.
                }
                else
                {
                    CurrentTourPage--;   
                }
                
                _phpService.FetchTourEntriesAsync(CurrentTourPage);
            }
                break;
            case "Refuel":
            {
                if (CurrentRefuelPage < 1)
                {
                    CurrentRefuelPage = 1; // Clamp to prevent boundary overflow.
                }

                CurrentRefuelPage--;
                _phpService.FetchRefuelEntriesAsync(CurrentRefuelPage);
            }
                break;
        }
    }
}