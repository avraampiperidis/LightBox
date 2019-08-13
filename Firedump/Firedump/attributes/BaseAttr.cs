using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.attributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class BaseAttr : Attribute
    {
        public string Label { get;  }

        public BaseAttr() { }

        public BaseAttr(string label) : this()
        {
            this.Label = label;
        }
    }
}
