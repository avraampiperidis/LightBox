using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.sqlitetables
{
    public enum DbTypeEnum : int
    {
        MYSQL = 0,
        MARIADB = 1,
        ORACLE = 2,
        POSTGRES = 3,
        SQLSERVER = 4
    }
}
