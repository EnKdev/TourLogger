using System.Collections.Specialized;
using System.Net;

namespace TourLogger.Utils
{
    public static class HttpPostHelper
    {
        public static byte[] HttpPost(string uri, NameValueCollection pairs)
        {
            using var wc = new WebClient();
            var res = wc.UploadValues(uri, pairs);
            wc.Dispose();

            return res;
        }
    }
}
