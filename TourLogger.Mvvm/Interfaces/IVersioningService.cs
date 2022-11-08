namespace TourLogger.Mvvm.Interfaces;

/// <summary>
/// Base implementation of the <see cref="VersioningService"/>.
/// </summary>
public interface IVersioningService
{
    /// <summary>
    /// Sets the apps version.
    /// </summary>
    /// <param name="hasRevision">true if a revision exists, false if not.</param>
    public void SetAppVersion(bool hasRevision);

    /// <summary>
    /// Should only be accessed after <see cref="SetAppVersion"/> has been invoked.
    /// </summary>
    public string? AppVersion { get; set; }
}