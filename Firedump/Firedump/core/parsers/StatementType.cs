using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.core.parsers
{
    public enum StatementType : int
    {
        SELECT = 1,
        OTHER = 20
    }

    public sealed class StatementTypeResolver
    {
        public static StatementType Resolve(string sql)
        {   if(string.IsNullOrEmpty(sql))
            {
                return StatementType.OTHER;
            }
            if(sql.Length > 5)
            {
                if (sql.Trim().Split(' ')[0].ToLower() == "select")
                {
                    return StatementType.SELECT;
                }
            }
            return StatementType.OTHER;
        }
    }
}
