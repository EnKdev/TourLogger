using System.Windows;
using System.Windows.Controls;
using TourLogger.Mvvm.ViewModels;

namespace TourLogger.Mvvm.Util;

/// <summary>
/// Selects a define template so we can navigate between views and their respective view models.
/// </summary>
public class TemplateSelector : DataTemplateSelector
{
    /// <summary>
    /// Allows us to navigate between all existing views and view models.
    /// </summary>
    /// <param name="item"><see cref="object"/></param>
    /// <param name="container"><see cref="DependencyObject"/></param>
    /// <returns></returns>
    public override DataTemplate? SelectTemplate(object item, DependencyObject container)
    {
        if (item is MainViewModel)
        {
            return App.Current.FindResource("MainViewTemplate") as DataTemplate;
        }

        return base.SelectTemplate(item, container);
    }
}