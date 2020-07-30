namespace TourLogger.Utils
{
    public class Versioning
    {
        public static string AppVersion = "6.0.0-beta";
        private static string AppAbbreviation = "TL";
        private static string AppVersionNumber = "600-beta";
        private static string BuildRevisionFull = "0606200233";
        private static string BuildRevisionAbbr = "060620";

        private static char FullVerSep = '_';
        private static char AbbrVerSep = ':';
        private static char Joiner = '+';

        public static string FullVersionString = AppVersion + Joiner + BuildRevisionFull + FullVerSep +
                                                 AppAbbreviation + FullVerSep + AppVersionNumber;

        public static string AbbrVersionString = AppVersion + Joiner + BuildRevisionAbbr + AbbrVerSep +
                                                 AppAbbreviation + AbbrVerSep + AppVersionNumber;
    }
}