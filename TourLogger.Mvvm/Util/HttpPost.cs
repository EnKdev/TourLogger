using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TourLogger.Mvvm.Util;

/// <summary>
/// Utility class to help creating post requests
/// </summary>
public static class HttpPost
{
    /// <summary>
    /// Prepares a new HTTP POST request with a given URI and a value dictionary
    /// </summary>
    /// <param name="uri">The target uri of the request</param>
    /// <param name="values">The values of the post request</param>
    /// <returns>A result string of the said post request</returns>
    public static async Task<string> PostAsync(string uri, Dictionary<string, string?> values)
    {
        using var httpClient = new HttpClient();
        var res = await httpClient.SendAsync(new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            Content = new FormUrlEncodedContent(values),
            RequestUri = new Uri(uri)
        });

        var result = await res.Content.ReadAsStringAsync();

        return result;
    }
}