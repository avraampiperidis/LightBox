using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dbinfo
{
    public class TableInfo
    {
        public TableInfo() { }

        public string Table { get; set; }

        public string Engine { get; set; }

        public int Version { get; set; }

        public string RowFormat { get; set; }

        public Int64 Rows { get; set; }

        public Int64 AvgRowLength { get; set; }

        public Int64 DataLength { get; set; }

        public Int64 IndexLength { get; set; }

        public string CreateTime { get; set; }

        public string Collation { get; set; }



    }
}
