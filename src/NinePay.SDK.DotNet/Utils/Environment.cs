namespace NinePay.SDK.DotNet.Utils
{
    public static class Environment
    {
        public const string SAND = "https://sand-payment.9pay.vn";
        public const string PROD = "https://payment.9pay.vn";

        public static string Endpoint(string env)
        {
            if ("PRODUCTION".Equals(env, System.StringComparison.OrdinalIgnoreCase))
            {
                return PROD;
            }
            return SAND;
        }
    }
}