using Firedump.sqlitetables;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.creational
{
    public sealed class _DbUtils
    {
        public static DbTypeEnum _convert(int db_type)
        {
            return (DbTypeEnum)db_type;
        }

        public static DbTypeEnum GetDbTypeEnum(DbConnection c)
        {
            if(c is MySqlConnection)
            {
                return DbTypeEnum.MYSQL;
            } else if(c is OracleConnection)
            {
                return DbTypeEnum.ORACLE;
            }
            throw new Exception("Database Vendor Not Supported!");
        }
    }
}
