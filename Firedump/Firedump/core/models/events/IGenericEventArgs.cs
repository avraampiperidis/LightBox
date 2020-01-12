using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.events
{
    public interface IGenericEventArgs<out T>
    {
        object GetObject();
    }
}
