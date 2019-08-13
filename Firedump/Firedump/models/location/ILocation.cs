using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    interface ILocation
    {
        LocationConnectionResultSet connect();

        LocationConnectionResultSet connect(object o);

        LocationResultSet getFile();

        LocationResultSet send();
    }
}
