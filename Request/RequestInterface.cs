using System.Collections.Generic;

namespace NinePay.SDK.DotNet.Request
{
    public interface RequestInterface
    {
        Dictionary<string, object> ToPayload();
    }
}