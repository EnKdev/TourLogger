using EnKdev.EnKVer;
using TourLogger.Mvvm.Interfaces;

namespace TourLogger.Mvvm.Services;

/// <summary>
/// See the documentation of <see cref="IVersioningService"/>.
/// </summary>
public class VersioningService : IVersioningService
{
    /// <inheritdoc />
    public void SetAppVersion(bool hasRevision)
    {
        if (hasRevision)
        {
            EnKVer2.ReadVersionFile($"./EnKVer/ev2.ev", true);

            var y = EnKVer2.Year;
            var m = EnKVer2.Month;
            var d = EnKVer2.Day;
            var r = EnKVer2.Revision;
            var h = EnKVer2.VerHash;

            AppVersion = $"V{y}.{m}.{d}.{r}.{h}";
        }
        else
        {
            EnKVer2.ReadVersionFile($"./EnKVer/ev2.ev");

            var y = EnKVer2.Year;
            var m = EnKVer2.Month;
            var d = EnKVer2.Day;
            var h = EnKVer2.VerHash;

            AppVersion = $"V{y}.{m}.{d}.{h}";
        }
    }

    /// <inheritdoc />
    public string? AppVersion { get; set; }
}