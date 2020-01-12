using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.events
{
    public interface ITriplet<out T, out S, out D> 
    {
        Type TargetType();
        Type SourceType();
        Type DataType();
        object GetData();
    }
}
