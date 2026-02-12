using Xunit;
using NinePay.SDK.DotNet.Config;
using NinePay.SDK.DotNet.Gateway;
using NinePay.SDK.DotNet.Request;
using NinePay.SDK.DotNet.Response;

namespace NinePay.SDK.DotNet.Test
{
    public class NinePayGatewayTest
    {
        private readonly NinePayGateway gateway;

        public NinePayGatewayTest()
        {
            var config = new NinePayConfig("MID", "SECRET", "CHECKSUM", "SANDBOX");
            gateway = new NinePayGateway(config);
        }

        [Fact]
        public void TestCreatePayment()
        {
            var request = new CreatePaymentRequest("INV123", "1000", "Test");
            ResponseInterface response = gateway.CreatePayment(request);

            Assert.True(response.IsSuccess());
            Assert.NotNull(response.GetData()["redirect_url"]);

            var redirectUrl = response.GetData()["redirect_url"].ToString();
            Assert.Contains("baseEncode=", redirectUrl);
            Assert.Contains("signature=", redirectUrl);
        }

        // ================= REFUND TEST =================
        [Fact]
        public void TestRefund()
        {
            var refundRequest = new ReverseRequest(
                requestId: "REFUND_" + System.DateTime.Now.Ticks,
                orderCode: "INV123"
            );

            ResponseInterface response = gateway.Refund(refundRequest);

            Assert.NotNull(response);
            Assert.NotNull(response.GetMessage());
        }
    }
}
