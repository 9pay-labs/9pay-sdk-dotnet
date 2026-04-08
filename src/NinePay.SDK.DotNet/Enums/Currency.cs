namespace NinePay.SDK.DotNet.Enums
{
    public class Currency
    {
        public string Value { get; }

        private Currency(string value)
        {
            Value = value;
        }

        public static readonly Currency VND = new("VND");
        public static readonly Currency USD = new("USD");
        public static readonly Currency IDR = new("IDR");
        public static readonly Currency EUR = new("EUR");
        public static readonly Currency GBP = new("GBP");
        public static readonly Currency CNY = new("CNY");
        public static readonly Currency JPY = new("JPY");
        public static readonly Currency AUD = new("AUD");
        public static readonly Currency KRW = new("KRW");
        public static readonly Currency CAD = new("CAD");
        public static readonly Currency HKD = new("HKD");
        public static readonly Currency INR = new("INR");

        public static bool IsValid(string code)
        {
            return code != null && new[]
            {
                VND, USD, IDR, EUR, GBP, CNY, JPY, AUD, KRW, CAD, HKD, INR
            }.Any(c => c.Value.Equals(code, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
