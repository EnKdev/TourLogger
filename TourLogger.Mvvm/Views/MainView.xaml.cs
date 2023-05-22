using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using TourLogger.Mvvm.ViewModels;

namespace TourLogger.Mvvm.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = App.Current.Services.GetService<MainViewModel>();
        ((MainViewModel)DataContext!).InitDefaultValues();
    }
}