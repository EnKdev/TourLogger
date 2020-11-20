using System.Reflection;

namespace TourLogger.Utils
{
    public class Versioning
    {
        public static string AppVersion = "6.0.0";
        public static string AppFileVersion = "2";
        public static string DbVersion = "3";
        public static string SecretVersion = "2";
        private static string AppAbbreviation = "TL";
        private static string AppVersionNumber = "600";
        private static string BuildRevisionFull = "0511202141";
        private static string BuildRevisionAbbr = "051120";
        
        private static char FullVerSep = '_';
        private static char AbbrVerSep = ':';
        private static char Joiner = '+';

        public static string FullVersionString = AppVersion + Joiner + BuildRevisionFull + FullVerSep +
                                                 AppAbbreviation + FullVerSep + AppVersionNumber;

        public static string AbbrVersionString = AppVersion + Joiner + BuildRevisionAbbr + AbbrVerSep +
                                                 AppAbbreviation + AbbrVerSep + AppVersionNumber;

        [Obfuscation]
        public static readonly string AppSecret = ""; // Secret, even to the Repository!
    }
}