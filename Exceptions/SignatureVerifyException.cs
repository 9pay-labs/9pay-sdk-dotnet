using System;

namespace NinePay.SDK.DotNet.Exceptions
{
    public class SignatureVerifyException : Exception
    {
        public SignatureVerifyException(string message) : base(message)
        {
        }

        public SignatureVerifyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
