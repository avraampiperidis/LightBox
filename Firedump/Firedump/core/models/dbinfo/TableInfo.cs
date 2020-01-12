using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models
{
    public class TableInfo
    {
        public TableInfo() { }

        public string Table { get; set; }

        public string Engine { get; set; }

        public int Version { get; set; }

        public string RowFormat { get; set; }

        public long Rows { get; set; }

        public long AvgRowLength { get; set; }

        public long DataLength { get; set; }

        public long IndexLength { get; set; }

        public string CreateTime { get; set; }

        public string Collation { get; set; }



    }
}
