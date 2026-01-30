using System;

namespace NinePay.SDK.DotNet.Exceptions
{
    public class PaymentException : Exception
    {
        public PaymentException(string message) : base(message)
        {
        }

        public PaymentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
