namespace NinePay.SDK.DotNet.Enums
{
    public sealed class PaymentMethod
    {
        public static readonly PaymentMethod ATM_CARD = new("ATM_CARD");
        public static readonly PaymentMethod CREDIT_CARD = new("CREDIT_CARD");
        public static readonly PaymentMethod NINE_PAY = new("9PAY");
        public static readonly PaymentMethod COLLECTION = new("COLLECTION");
        public static readonly PaymentMethod APPLE_PAY = new("APPLE_PAY");
        public static readonly PaymentMethod BUY_NOW_PAY_LATER = new("BUY_NOW_PAY_LATER");
        public static readonly PaymentMethod QR_PAY = new("QR_PAY");
        public static readonly PaymentMethod VNPAY_PORTONE = new("VNPAY_PORTONE");
        public static readonly PaymentMethod ZALOPAY_WALLET = new("ZALOPAY_WALLET");
        public static readonly PaymentMethod GOOGLE_PAY = new("GOOGLE_PAY");

        public string Value { get; }

        private PaymentMethod(string value)
        {
            Value = value;
        }

        public static bool IsValid(string method)
        {
            return GetAll().Any(m =>
                m.Value.Equals(method, StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<PaymentMethod> GetAll()
        {
            yield return ATM_CARD;
            yield return CREDIT_CARD;
            yield return NINE_PAY;
            yield return COLLECTION;
            yield return APPLE_PAY;
            yield return BUY_NOW_PAY_LATER;
            yield return QR_PAY;
            yield return VNPAY_PORTONE;
            yield return ZALOPAY_WALLET;
            yield return GOOGLE_PAY;
        }
    }
}
