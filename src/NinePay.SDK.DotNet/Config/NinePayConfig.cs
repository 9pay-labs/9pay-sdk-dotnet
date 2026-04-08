using NinePay.SDK.DotNet.Exceptions;

namespace NinePay.SDK.DotNet.Config
{
    public class NinePayConfig
    {
        public string MerchantId { get; }
        public string SecretKey { get; }
        public string ChecksumKey { get; }
        public string Endpoint { get; }

        public NinePayConfig(string merchantId, string secretKey, string checksumKey, string endpoint)
        {
            if (string.IsNullOrEmpty(merchantId) ||
                string.IsNullOrEmpty(secretKey) ||
                string.IsNullOrEmpty(checksumKey) ||
                string.IsNullOrEmpty(endpoint))
            {
                throw new InvalidConfigException(
                    "NinePay config requires merchantId, secretKey, checksumKey, endpoint"
                );
            }

            MerchantId = merchantId;
            SecretKey = secretKey;
            ChecksumKey = checksumKey;
            Endpoint = endpoint.TrimEnd('/');
        }
    }
}
