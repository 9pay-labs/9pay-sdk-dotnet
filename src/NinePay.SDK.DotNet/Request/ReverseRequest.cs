using System.Collections.Generic;

namespace NinePay.SDK.DotNet.Request
{
    public class ReverseRequest : RequestInterface
    {
        public string request_id { get; set; }
        public string order_code { get; set; }

        public ReverseRequest(string requestId, string orderCode)
        {
            this.request_id = requestId;
            this.order_code = orderCode;
        }

        public Dictionary<string, object> ToPayload()
        {
            return new Dictionary<string, object>
            {
                { "request_id", request_id },
                { "order_code", order_code }
            };
        }
    }
}