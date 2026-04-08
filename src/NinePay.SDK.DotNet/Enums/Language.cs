namespace NinePay.SDK.DotNet.Enums
{
    public class Language
    {
        public string Value { get; }

        private Language(string value)
        {
            Value = value;
        }

        public static readonly Language VI = new("vi");
        public static readonly Language EN = new("en");

        public static bool IsValid(string lang)
        {
            return lang != null && new[]
            {
                VI, EN
            }.Any(l => l.Value.Equals(lang, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
