using Firedump.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.pojos
{
    public class BaseStatus
    {
        public BaseStatus()
        {
            this.wasSuccessful = true;
        }
        public virtual bool wasSuccessful { set; get; }
        public virtual string errorMessage { set; get; }
    }
}
