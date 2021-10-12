using System.Net;

namespace TourLogger.Utils
{
    public class SecretGrabber
    {
        public static string AppSecret;

        public static void GrabSecret()
        {
            using var wc = new WebClient();
            var secret = wc.DownloadString("Lol, you thought I'd include the secret here.");
            AppSecret = secret;
        }
    }
}