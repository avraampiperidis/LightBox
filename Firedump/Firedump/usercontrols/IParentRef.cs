using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.usercontrols
{
    //
    // Summary:
    //     The Interface for the base main windows component.
    public interface IParentRef
    {
        DbConnection GetConnection();

        sqlservers GetServer();
    }
}
