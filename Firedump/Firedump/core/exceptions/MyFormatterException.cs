using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.core.exceptions
{
    [Serializable]
    public class MyFormatterException : AppException
    {
        public MyFormatterException() : base() { }

        public MyFormatterException(string msg) : base(msg) { }
    }
}
