using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.exceptions
{
    [Serializable]
    public class AppException : Exception
    {
        public string Message { get;  }
        public int ErrorCode { get;  }

        public int StatusCode { get; }

        public AppException() : base() { }

        public AppException(string msg):this()
        {
            this.Message = msg;
        }

        public AppException(string msg,int errorCode) : this(msg)
        {
            this.ErrorCode = errorCode;
        }

        public AppException(string msg, int errorCode,int statusCode) : this(msg,errorCode)
        {
            this.StatusCode = statusCode;
        }

        public AppException(int errorCode, int statusCode) : this("", errorCode,statusCode)
        {
            this.StatusCode = statusCode;
        }

    }
}
