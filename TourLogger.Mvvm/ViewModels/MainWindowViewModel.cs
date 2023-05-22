using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using TourLogger.Mvvm.Interfaces;
using TourLogger.Mvvm.Messages;
using TourLogger.Mvvm.Util;

namespace TourLogger.Mvvm.ViewModels;

/// <summary>
/// The view model for our main window.
/// </summary>
public partial class MainWindowViewModel : ObservableRecipient, IRecipient<SwitchToViewModelMessage>
{
    private readonly IVersioningService _versioningService;

    /// <summary>
    /// The current view we are on.
    /// </summary>
    [ObservableProperty]
    private ITemplatedViewModel? _currentView;

    /// <summary>
    /// The apps title.
    /// </summary>
    [ObservableProperty]
    private string? _title;

    /// <summary>
    /// Standard parameterized constructor.
    /// </summary>
    public MainWindowViewModel(MainViewModel currentView, IVersioningService versioningService)
    {
        _versioningService = versioningService;
        CurrentView = currentView;
        WeakReferenceMessenger.Default.Register(this);

        _versioningService.SetAppVersion(true);
        
        Title = "TourLogger V" + Constants.AppVersion + " | " + ValueHolder.AppVersion;
    }

    /// <summary>
    /// Receives the name of the view model we want to switch to.
    /// </summary>
    /// <param name="message"><see cref="SwitchToViewModelMessage"/></param>
    public void Receive(SwitchToViewModelMessage message)
    {
        if (message.ViewModelName == "MainViewModel")
        {
            CurrentView = App.Current.Services.GetService<MainViewModel>()!;
        }
    }
}