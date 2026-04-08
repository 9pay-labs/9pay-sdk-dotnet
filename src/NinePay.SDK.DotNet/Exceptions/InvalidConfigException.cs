using System;

namespace NinePay.SDK.DotNet.Exceptions
{
    public class InvalidConfigException : Exception
    {
        public InvalidConfigException(string message) : base(message)
        {
        }

        public InvalidConfigException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
