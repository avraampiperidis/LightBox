using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.events
{
    public class ConnectionEventArgs : EventArgs
    {
        public sqlservers server;
        public DbConnection con;

        public ConnectionEventArgs(DbConnection c,sqlservers s)
        {
            this.server = s;
            this.con = c;
        }
    }
}
