using Firedump.attributes;
using Firedump.creational;
using Firedump.creational.db;
using Firedump.models.db;
using Firedump.models.pojos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Windows.Forms;

namespace Firedump.models.dbUtils
{
    public class DbUtils
    {
        /**
         * The user can give his own connection, that case i dont have to close it.
         * Its up to user to handle the connection flow.
         * OR if the user dont give any connection i create one and Dispose/Close it after using it to prevent connections leak/and others.
         */
        public static List<string> getDatabases(sqlservers server,DbConnection con = null)
        {
            if(con == null)
            {
                List<string> data = null;
                using (con = DB.connect(server))
                {
                    data = getStringData(con, new SqlBuilderFactory(con).Create(null).getDatabases());
                }
                return data;
            } 
            return getStringData(con, new SqlBuilderFactory(con).Create(null).getDatabases());
        }

        public static List<string> getTables(sqlservers server, string database,DbConnection con = null)
        {
            if(con == null)
            {
                List<string> data = null;
                using (con = DB.connect(server,database))
                {
                    data = getStringData(con, new SqlBuilderFactory(con).Create(database).showTablesSql());
                }
                return data;
            }
            return getStringData(con, new SqlBuilderFactory(con).Create(database).showTablesSql());
        }

        public static List<string> getTables(DbConnection con)
        {
            return getStringData(con, new SqlBuilderFactory(con).Create(con.Database).showTablesSql());
        }

        [Resolve("db specific Parser Needed for result set")]
        internal static List<Table>  getTablesInfo(sqlservers server,DbConnection con)
        {
            var list = new List<Table>();
            using (var r = new DbCommandFactory(con, new SqlBuilderFactory(server).Create(con.Database).getAllFieldsFromAllTablesInDb()).Create().ExecuteReader())
            {
                while(r.Read())
                {
                    list.Add(new Table(r.GetString(0),r.GetString(1),r.GetString(2),r.GetString(3),
                        r.GetValue(4) != DBNull.Value ? r.GetInt64(4) : default(long)));
                }
            }
            return list;
        }

        [Deprecated("Indeed the describe exists for most of the databases, But the results are different! A parser is needed per database")]
        internal static List<string> getTableFields(DbConnection con,string table) {
            var data = new List<string>();
            using (var reader = new DbCommandFactory(con, new SqlBuilderFactory(con).Create(con.Database).describeTableSql(table)).Create().ExecuteReader())
            {
                while (reader.Read())
                {
                    data.Add(reader.GetString(0).ToUpper() + " " + reader.GetString(1) + ", Nullable:"+reader.GetString(2));
                }
            }
            return data;
        }


        internal static int getTableRowCount(sqlservers server, string database, string tablename, DbConnection con = null)
        {
            if(con == null)
            {
                int res = 0;
                using (con = DB.connect(server, database))
                {
                    res = getIntSingleResult(con, "SELECT COUNT(*) FROM " + database + "." + tablename);
                }
                return res;
            }
            return getIntSingleResult(con, "SELECT COUNT(*) FROM " + database + "." + tablename);
        }


        internal static List<string> getStringData(DbConnection con, string sql)
        {
            var data = new List<string>();
            using (var reader = new DbCommandFactory(con,sql).Create().ExecuteReader())
            {
                while (reader.Read())
                {
                    data.Add(reader.GetString(0).ToUpper());
                }
            }
            return data;
        }


        internal static int getIntSingleResult(DbConnection con, string sql)
        {
            int result = 0;
            using (var reader = new DbCommandFactory(con, sql).Create().ExecuteReader())
            {
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
            }
            return result;
        }

        internal static DataTable getDataTableData(DbConnection con,string sql)
        {
            var data = new DataTable();
            using (var adapter = new DbAdapterFactory(con, sql).Create())
            {
                try
                {
                    adapter.Fill(data);
                }
                catch (Exception ex) { }
                
            }
            return data;
        }


        /**
         * !Only For MySql Database!
         * could improved in futture like, categorized system databases, user/schema databases , databases per configuration/permission and other.
         * Now its Just KSERO PSOMI
         */
        [Deprecated("Dont event know if this is needed for other databases except MySql")]
        internal static List<string> removeSystemDatabases(List<string> databases,bool showSystemDb = false)
        {
            if(!showSystemDb)
            {
               return databases.Where(i => i != "sys".ToUpper() && i != "performance_schema".ToUpper() && i != "mysql".ToUpper() && i != "information_schema".ToUpper()).ToList();
            }
            return databases;
        }

        internal static sqlservers getSqlServerFromTable(DataTable table, ListControl control)
        {
            return new sqlservers((string)table.Rows[control.SelectedIndex]["host"], unchecked((int)(long)table.Rows[control.SelectedIndex]["port"]),
                (string)table.Rows[control.SelectedIndex]["username"], (string)table.Rows[control.SelectedIndex]["password"]);
        }
    }
}
