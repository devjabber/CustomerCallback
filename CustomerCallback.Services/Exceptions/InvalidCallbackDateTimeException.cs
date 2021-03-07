using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCallback.Services.Exceptions
{
    [Serializable]
    public class InvalidCallbackDateTimeException : Exception
    {
        public InvalidCallbackDateTimeException()
        {
        }

        public InvalidCallbackDateTimeException(string message)
            : base(message)
        {
        }

        public InvalidCallbackDateTimeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
