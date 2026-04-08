namespace NinePay.SDK.DotNet.Enums
{
    public class TransactionType
    {
        public string Value { get; }

        private TransactionType(string value)
        {
            Value = value;
        }

        public static readonly TransactionType INSTALLMENT = new("INSTALLMENT");
        public static readonly TransactionType CARD_AUTHORIZATION = new("CARD_AUTHORIZATION");

        public static bool IsValid(string type)
        {
            return type != null && new[]
            {
                INSTALLMENT,
                CARD_AUTHORIZATION
            }.Any(t => t.Value.Equals(type, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
