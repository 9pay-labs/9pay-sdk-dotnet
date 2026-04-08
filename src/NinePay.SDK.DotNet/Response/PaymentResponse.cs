using System.Collections.Generic;

namespace NinePay.SDK.DotNet.Response
{
    public class PaymentResponse : ResponseInterface
    {
        private readonly bool success;
        private readonly Dictionary<string, object> data;
        private readonly string message;

        public PaymentResponse(bool success, Dictionary<string, object> data, string message)
        {
            this.success = success;
            this.data = data;
            this.message = message;
        }

        public bool IsSuccess()
        {
            return success;
        }

        public Dictionary<string, object> GetData()
        {
            return data;
        }

        public string GetMessage()
        {
            return message;
        }
    }
}