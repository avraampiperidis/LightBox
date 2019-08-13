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
    public class DbAdapterFactory : AbstractDbFactory<DbDataAdapter>
    {
        private string Sql;

        public DbAdapterFactory(DbConnection c,string sql) : base(c)
        {
            this.Sql = sql;
        }

        public override sealed DbDataAdapter Create()
        {
            DbTypeEnum dbType = _DbUtils.GetDbTypeEnum(Connection);
            if (dbType == DbTypeEnum.MYSQL || dbType == DbTypeEnum.MARIADB)
            {
                return new MySqlDataAdapter(Sql, (MySqlConnection)Connection);
            }
            else if (dbType == DbTypeEnum.ORACLE)
            {
                return new OracleDataAdapter(Sql, (OracleConnection)Connection);
            }

            throw new Exception("Database Vendor Not Supported!");
        }

    }
}
