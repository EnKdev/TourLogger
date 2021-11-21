using System.Net;

namespace TourLogger.Utils
{
    public class SecretGrabber
    {
        public static string AppSecret;

        public static void GrabSecret()
        {
            using var wc = new WebClient();
            var secret = wc.DownloadString("https://enkdev.xyz/cdn/php/tourlogger/experimental/secretProvider.experimental.php");
            AppSecret = secret;
        }
    }
}
