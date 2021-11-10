using EnKdev.EnKVer;

namespace TourLogger.Utils
{
    public class Versioning
    {

        /// <summary>
        /// Sets the app version
        /// </summary>
        /// <param name="hasRevision"><see langword="true"/> if a revision exists, <see langword="false"/> if not</param>
        public static void SetAppVersion(bool hasRevision)
        {
            if (hasRevision)
            {
                EnKVer2.ReadVersionFile($"./EnKVer/ev2.ev", true);
                var year = EnKVer2.Year;
                var month = EnKVer2.Month;
                var day = EnKVer2.Day;
                var revision = EnKVer2.Revision;
                var appHash = EnKVer2.VerHash;

                AppVersion = $"V{year}.{month}.{day}.{revision}.{appHash}";
            }
            else
            {
                EnKVer2.ReadVersionFile($"./EnKVer/ev2.ev");
                var year = EnKVer2.Year;
                var month = EnKVer2.Month;
                var day = EnKVer2.Day;
                var appHash = EnKVer2.VerHash;

                AppVersion = $"V{year}.{month}.{day}.{appHash}";
            }
        }

        /// <summary>
        /// Should only be called after <see cref="SetAppVersion"/> has been invoked
        /// </summary>
        public static string AppVersion { get; private set; }
    }
}
