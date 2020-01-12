using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models
{
    public class BaseStatus
    {
        public BaseStatus()
        {
            wasSuccessful = true;
        }
        public virtual bool wasSuccessful { set; get; }
        public virtual string errorMessage { set; get; }
    }
}
