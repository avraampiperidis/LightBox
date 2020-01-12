using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.core.exceptions
{
    [Serializable]
    public class AppException : Exception
    {
        public string Message { get; }
        public int ErrorCode { get; }

        public int StatusCode { get; }

        public AppException() : base() { }

        public AppException(string msg) : this()
        {
            Message = msg;
        }

        public AppException(string msg, int errorCode) : this(msg)
        {
            ErrorCode = errorCode;
        }

        public AppException(string msg, int errorCode, int statusCode) : this(msg, errorCode)
        {
            StatusCode = statusCode;
        }

        public AppException(int errorCode, int statusCode) : this("", errorCode, statusCode)
        {
            StatusCode = statusCode;
        }

    }
}
