using Firedump.exceptions;
using Firedump.sqlitetables;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.creational.db
{
    public class DbConnectionFactory : AbstractDbFactory<DbConnection>
    {
        private sqlservers Server;

        private string ConnectionString;
        public DbConnectionFactory(sqlservers s)
        {
            this.Server = s;
        }

        public DbConnectionFactory(sqlservers s, string connectionString):this(s)
        {
            this.ConnectionString = connectionString;
        }

        public override sealed DbConnection Create()
        {
            DbTypeEnum dbType = _DbUtils._convert(Server.db_type);
            if(dbType == DbTypeEnum.MYSQL || dbType == DbTypeEnum.MARIADB)
            {
                return string.IsNullOrEmpty(ConnectionString) ? new MySqlConnection() : new MySqlConnection(ConnectionString);
            }
            else if(dbType == DbTypeEnum.ORACLE)
            {
                return string.IsNullOrEmpty(ConnectionString) ? new OracleConnection() : new OracleConnection(ConnectionString);
            }
            // Other dbs here...

            throw new SqlException("Database Vendor Not Supported!");
        }
    }
}
