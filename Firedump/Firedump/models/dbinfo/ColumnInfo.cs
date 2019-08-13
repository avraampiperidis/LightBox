using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dbinfo
{
    public class ColumnInfo
    {
        public ColumnInfo()
        {

        }

        public string Table { get; set; }

        public string Field { get; set; }

        public string Type { get; set; }

        public string IsNullable { get; set; }

        public string Default { get; set; }
    }
}
