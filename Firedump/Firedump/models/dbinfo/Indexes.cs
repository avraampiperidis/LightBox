using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dbinfo
{
    public class Indexes
    {
        public Indexes() { }

        public string Table { get; set; }

        public string Unique { get; set; }

        public string KeyName { get; set; }

        public int SeqInIndex { get; set; }

        public string ColumnName { get; set; }

        public int Cardinality { get; set; }

        public string IndexType { get; set; }


    }
}
