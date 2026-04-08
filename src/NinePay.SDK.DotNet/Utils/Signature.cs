using System.Security.Cryptography;
using System.Text;

namespace NinePay.SDK.DotNet.Utils
{
    public static class Signature
    {
        public static string Sign(string message, string key)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            return System.Convert.ToBase64String(hash);
        }

        public static bool Verify(string signature, string message, string key)
        {
            var valid = Sign(message, key);
            return HashEquals(valid, signature);
        }

        private static bool HashEquals(string a, string b)
        {
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;

            var result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i];
            }
            return result == 0;
        }
    }
}