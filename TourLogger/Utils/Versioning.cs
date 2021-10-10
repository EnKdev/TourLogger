using EnKdev.EnKVer;

namespace TourLogger.Utils
{
    public class Versioning
    {
        private static int _year;
        private static int _month;
        private static int _day;
        private static int _revision;
        private static string _appHash;

        /// <summary>
        /// Sets the app version
        /// </summary>
        /// <param name="hasRevision"><see langword="true"/> if a revision exists, <see langword="false"/> if not</param>
        public static void SetAppVersion(bool hasRevision)
        {
            if (hasRevision)
            {
                EnKVer2.ReadVersionFile($"./EnKVer/ev2.ev", true);
                _year = EnKVer2.Year;
                _month = EnKVer2.Month;
                _day = EnKVer2.Day;
                _revision = EnKVer2.Revision;
                _appHash = EnKVer2.VerHash;

                AppVersion = $"V{_year}.{_month}.{_day}.{_revision}.{_appHash}";
            }
            else
            {
                EnKVer2.ReadVersionFile($"./EnKVer/ev2.ev");
                _year = EnKVer2.Year;
                _month = EnKVer2.Month;
                _day = EnKVer2.Day;
                _appHash = EnKVer2.VerHash;

                AppVersion = $"V{_year}.{_month}.{_day}.{_appHash}";
            }
        }

        /// <summary>
        /// Should only be called after <see cref="SetAppVersion"/> has been invoked
        /// </summary>
        public static string AppVersion { get; private set; }
    }
}