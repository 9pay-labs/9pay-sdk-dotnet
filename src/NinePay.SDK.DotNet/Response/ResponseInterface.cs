using System.Collections.Generic;

namespace NinePay.SDK.DotNet.Response
{
    public interface ResponseInterface
    {
        bool IsSuccess();
        Dictionary<string, object> GetData();
        string GetMessage();
    }
}
