using System.Collections.Generic;

namespace NinePay.SDK.DotNet.Response
{
    public class ReverseResponse : ResponseInterface
    {
        private readonly bool success;
        private readonly string message;
        private readonly Dictionary<string, object> data;

        public ReverseResponse(bool success, string message, Dictionary<string, object> data)
        {
            this.success = success;
            this.message = message;
            this.data = data;
        }

        public bool IsSuccess() => success;

        public Dictionary<string, object> GetData() => data;

        public string GetMessage() => message;
    }
}
