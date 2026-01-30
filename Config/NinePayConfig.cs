using NinePay.SDK.DotNet.Exceptions;

namespace NinePay.SDK.DotNet.Config
{
    public class NinePayConfig
    {
        public string MerchantId { get; }
        public string SecretKey { get; }
        public string ChecksumKey { get; }
        public string Env { get; }

        public NinePayConfig(string merchantId, string secretKey, string checksumKey, string env)
        {
            if (string.IsNullOrEmpty(merchantId) ||
                string.IsNullOrEmpty(secretKey) ||
                string.IsNullOrEmpty(checksumKey))
            {
                throw new InvalidConfigException(
                    "NinePay config requires merchantId, secretKey, checksumKey"
                );
            }

            MerchantId = merchantId;
            SecretKey = secretKey;
            ChecksumKey = checksumKey;
            Env = string.IsNullOrEmpty(env) ? "SANDBOX" : env;
        }

        public NinePayConfig(string merchantId, string secretKey, string checksumKey)
            : this(merchantId, secretKey, checksumKey, "SANDBOX")
        {
        }
    }
}
