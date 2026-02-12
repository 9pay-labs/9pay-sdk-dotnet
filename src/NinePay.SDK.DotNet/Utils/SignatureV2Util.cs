using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace NinePay.SDK.DotNet.Utils
{
    public class SignatureV2Util
    {
        public static string BuildHttpQuery(Dictionary<string, object> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return "";

            var sortedParams = new SortedDictionary<string, object>(parameters);

            return string.Join("&", sortedParams.Select(kvp =>
                $"{WebUtility.UrlEncode(kvp.Key)}={WebUtility.UrlEncode(kvp.Value.ToString())}"
            )).Replace("%20", "+");
        }

        public static string CreateSignature(
            string method,
            string url,
            long timestamp,
            string httpQuery,
            string secretKey
        )
        {
            string message = $"{method}\n{url}\n{timestamp}\n{httpQuery}";

            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
