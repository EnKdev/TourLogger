using System.Net;

namespace TourLogger.Utils
{
    public class SecretGrabber
    {
        public static string AppSecret;

        public static void GrabSecret()
        {
            using var wc = new WebClient();
            // Now that the backend has a second security layer, I can safely leave this in...
            var secret = wc.DownloadString("Actually no.");
            AppSecret = secret;
        }
    }
}
