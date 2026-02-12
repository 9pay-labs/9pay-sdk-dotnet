using NinePay.SDK.DotNet.Request;
using NinePay.SDK.DotNet.Response;

namespace NinePay.SDK.DotNet.Gateway
{
    public interface PaymentGatewayInterface
    {
        ResponseInterface CreatePayment(CreatePaymentRequest request);
        ResponseInterface Inquiry(string transactionId);
        PaymentResponse Refund(ReverseRequest request);
    }
}
