using Firedump.sqlitetables;
using Firedump.utils;
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
    public class SqlBuilderFactory
    {
        private sqlservers server;
        private DbConnection con;
        public SqlBuilderFactory(sqlservers s)
        {
            this.server = s;
        }

        public SqlBuilderFactory(DbConnection c)
        {
            this.con = c;
        }

        public ISqlBuilder Create(string database,bool isUpper = true)
        {
            DbTypeEnum dbType = getDbTypeEnum();
            if (dbType == DbTypeEnum.MYSQL || dbType == DbTypeEnum.MARIADB)
            {
                return new MySqlSqlBuilder(database, isUpper);
            }
            else if(dbType == DbTypeEnum.ORACLE)
            {
                return new OracleSqlBuilder(database, isUpper);
            }

            throw new Exception("Wrong Database Type/Vendor!");
        }

        private DbTypeEnum getDbTypeEnum()
        {
            if(server != null)
            {
                return _DbUtils._convert(server.db_type);
            }
            return _DbUtils.GetDbTypeEnum(con);
        }

    }
}
