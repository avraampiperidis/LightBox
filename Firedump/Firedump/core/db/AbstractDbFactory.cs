using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.core.db
{
    public abstract class AbstractDbFactory<T>
    {
        public DbConnection Connection { get; private set; }

        public AbstractDbFactory() { }

        public AbstractDbFactory(DbConnection c) : this()
        {
            Connection = c;
        }
        public abstract T Create();
    }
}
