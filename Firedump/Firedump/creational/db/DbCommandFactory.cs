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
    public class DbCommandFactory : AbstractDbFactory<DbCommand>
    {
        private string Sql;

        public DbCommandFactory(DbConnection c,string sql):base(c)
        {
            this.Sql = sql;
        }

        public override sealed DbCommand Create()
        {
            DbTypeEnum dbType = _DbUtils.GetDbTypeEnum(Connection);
            if(dbType == DbTypeEnum.MYSQL || dbType == DbTypeEnum.MARIADB)
            {
                return new MySqlCommand(Sql,(MySqlConnection)Connection);
            }
            else if(dbType == DbTypeEnum.ORACLE)
            {
                return new OracleCommand(Sql, (OracleConnection)Connection);
            }

            throw new Exception("Database Vendor Not Supported!");
        }
    }
}
