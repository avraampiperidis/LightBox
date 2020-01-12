using Firedump.core.exceptions;
using Firedump.sqlitetables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.core.sql
{
    internal sealed class ConnectionStringFactory
    {
        internal static string CreateConnectionString(sqlservers server, string database = null)
        {
            if (server.db_type == (int)DbTypeEnum.MYSQL || server.db_type == (int)DbTypeEnum.MARIADB)
            {
                return MySqlConnectionStringBuilder.connectionStringBuilder(server, database);
            }
            else if (server.db_type == (int)DbTypeEnum.ORACLE)
            {
            }

            throw new SqlException("Database Not Supported!");
        }
    }
}
