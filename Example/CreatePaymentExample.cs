using System;
using NinePay.SDK.DotNet.Config;
using NinePay.SDK.DotNet.Enums;
using NinePay.SDK.DotNet.Gateway;
using NinePay.SDK.DotNet.Request;
using NinePay.SDK.DotNet.Response;

namespace NinePay.SDK.DotNet.Example
{
    public class CreatePaymentExample
    {
        public static void Run()
        {
            var merchantId = Environment.GetEnvironmentVariable("NINEPAY_MERCHANT_ID");
            var secretKey = Environment.GetEnvironmentVariable("NINEPAY_SECRET_KEY");
            var checksumKey = Environment.GetEnvironmentVariable("NINEPAY_CHECKSUM_KEY");
            var env = Environment.GetEnvironmentVariable("NINEPAY_ENV");

            var config = new NinePayConfig(
                merchantId,
                secretKey,
                checksumKey,
                env
            );

            var gateway = new NinePayGateway(config);

            var request = new CreatePaymentRequest(
                "INV_" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                "50000",
                "Payment for Order 1",
                "https://site.com/callback",
                "https://site.com/return"
            )
            .WithMethod(PaymentMethod.ATM_CARD)
            .WithClientIp("127.0.0.1")
            .WithCurrency(Currency.VND)
            .WithLang(Language.VI);

            ResponseInterface response = gateway.CreatePayment(request);

            if (response.IsSuccess())
            {
                var redirectUrl = response.GetData()["redirect_url"];
                Console.WriteLine("Redirect user to: " + redirectUrl);
            }
            else
            {
                Console.WriteLine("Error: " + response.GetMessage());
            }
        }
    }
}
