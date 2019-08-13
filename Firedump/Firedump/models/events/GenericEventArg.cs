using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.events
{
    public class GenericEventArg<T> :  EventArgs  , IGenericEventArgs<T>
    {
        public T t;

        public GenericEventArg() { }
        public GenericEventArg(T t):this()
        {
            this.t = t;
        }

        public object GetObject()
        {
            return t;
        }
    }
}
