using CommunityToolkit.Mvvm.Messaging.Messages;

namespace TourLogger.Mvvm.Messages;

/// <summary>
/// Data class that receives the name of a view model we want to switch to.
/// </summary>
public class SwitchToViewModelMessage : RequestMessage<string>
{
    /// <summary>
    /// The name of the view model we want to switch to.
    /// </summary>
    public string ViewModelName { get; set; }

    /// <summary>
    /// Standard parameterized constructor.
    /// </summary>
    /// <param name="viewModelName"><see cref="ViewModelName"/></param>
    public SwitchToViewModelMessage(string viewModelName)
    {
        ViewModelName = viewModelName;
    }
}