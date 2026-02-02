using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Web;

namespace NinePay.SDK.DotNet.Utils
{
    public class MessageBuilder
    {
        private string method = "GET";
        private string uri = "";
        private readonly SortedDictionary<string, string> headers = new();
        private string date = "";
        private readonly SortedDictionary<string, string> paramsMap = new();
        private string body = null;

        public static MessageBuilder Instance()
        {
            return new MessageBuilder();
        }

        public MessageBuilder With(string date, string uri, string method, Dictionary<string, string> headers)
        {
            this.date = date;
            this.uri = uri;
            this.method = method;

            if (headers != null)
            {
                foreach (var h in headers)
                {
                    this.headers[h.Key] = h.Value;
                }
            }

            return this;
        }

        public MessageBuilder With(string date, string uri, string method)
        {
            return With(date, uri, method, null);
        }

        public MessageBuilder WithBody(object body)
        {
            if (body is string s)
            {
                this.body = s;
            }
            else
            {
                this.body = JsonSerializer.Serialize(body);
            }
            return this;
        }

        public MessageBuilder WithParams(Dictionary<string, string> parameters)
        {
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    paramsMap[p.Key] = p.Value;
                }
            }
            return this;
        }

        public string Build()
        {
            Validate();

            var canonicalHeaders = BuildCanonicalString(headers);
            string canonicalPayload;

            if ("POST".Equals(method, StringComparison.OrdinalIgnoreCase) && body != null)
            {
                canonicalPayload = CanonicalBody();
            }
            else
            {
                canonicalPayload = BuildCanonicalString(paramsMap);
            }

            var components = new List<string>
            {
                method.ToUpper(),
                uri,
                date
            };

            if (!string.IsNullOrEmpty(canonicalHeaders))
                components.Add(canonicalHeaders);

            if (!string.IsNullOrEmpty(canonicalPayload))
                components.Add(canonicalPayload);

            return string.Join("\n", components);
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(uri) || string.IsNullOrEmpty(date))
            {
                throw new System.Exception("MessageBuilder: missing uri/date");
            }
        }

        private string BuildCanonicalString(SortedDictionary<string, string> map)
        {
            if (map == null || map.Count == 0) return "";

            return string.Join("&", map.Select(e =>
                $"{HttpUtility.UrlEncode(e.Key)}={HttpUtility.UrlEncode(e.Value)}"
            ));
        }

        private string CanonicalBody()
        {
            if (string.IsNullOrEmpty(body)) return "";

            using var sha = SHA256.Create();
            var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(body));
            return Convert.ToBase64String(hash);
        }

        public override string ToString()
        {
            try
            {
                return Build();
            }
            catch
            {
                return "";
            }
        }
    }
}