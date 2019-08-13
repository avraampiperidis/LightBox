using Firedump.usercontrols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.events
{
    
    public sealed class TripletEventArgs<T,S,D> : EventArgs , ITriplet<T,S,D> where T : UserControlReference where S : UserControlReference
    {
        private object data;

        public TripletEventArgs() { }

        public TripletEventArgs(object d):this()
        {
            this.data = d;
        }

        public Type TargetType()
        {
            return typeof(T);
        }

        public Type SourceType()
        {
            return typeof(S);
        }

        public Type DataType()
        {
            return typeof(D);
        }

        public object GetData()
        {
            return this.data;
        }
    }
}
