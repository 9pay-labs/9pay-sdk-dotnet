using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NinePay.SDK.DotNet.Utils
{
    public class HttpHelper
    {
        private static readonly HttpClient _client = new HttpClient();

        public static string PostForm(string url, Dictionary<string, object> data, Dictionary<string, string> headers)
        {
            var stringData = new Dictionary<string, string>();
            foreach (var item in data)
            {
                stringData[item.Key] = item.Value?.ToString() ?? "";
            }

            var content = new FormUrlEncodedContent(stringData);

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = content;

            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Key, h.Value);
            }

            var response = _client.SendAsync(request).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        public static string Get(
            string url,
            Dictionary<string, string> headers
        )
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            foreach (var h in headers)
            {
                request.Headers.TryAddWithoutValidation(h.Key, h.Value);
            }

            var response = _client.SendAsync(request).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
