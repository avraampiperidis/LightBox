using Firedump.attributes;
using Firedump.creational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.utils
{
    // Remember If order of named sql column results change in this sql's query, remapping is needed for dataSource binding.
    class MySqlSqlBuilder : ISqlBuilder
    {
        public string Database { get; set; }
        public bool IsUpper { get; set; }

        public MySqlSqlBuilder(string db,bool isUpper = true)
        {
            this.Database = db;
            this.IsUpper = isUpper;
        }

        // Remember If order of named sql column results change in this sql query, remapping is needed for dataSource binding.
        public string createDatabaseIndexes() =>
             "SELECT DISTINCT " + getUpperOrLower("TABLE_NAME") + " AS 'Table', "+getUpperOrLower("INDEX_NAME")+" AS 'Index' FROM INFORMATION_SCHEMA.STATISTICS WHERE" +
            " TABLE_SCHEMA = '" + Database + "' ";

        // Remember If order of named sql column results change in this sql query, remapping is needed for dataSource binding.
        public  string getDatabasePrimaryKeys() =>
            "SELECT  "+ getUpperOrLower("sta.index_name") + " as Type,  GROUP_CONCAT(DISTINCT "+getUpperOrLower("sta.column_name") +"  ORDER BY sta.column_name) AS 'Column(s)',  "+getUpperOrLower("tab.table_name") +" AS 'Table'" +
            " FROM information_schema.tables AS tab" +
            "  INNER JOIN information_schema.statistics AS sta ON sta.table_schema = tab.table_schema " +
            "  AND sta.table_name = tab.table_name " +
            "  AND sta.index_name = 'primary'" +
            " WHERE tab.table_schema = '" + Database + "' " +
            "  AND tab.table_type = 'BASE TABLE'" +
            " GROUP BY tab.table_name " +
            " ORDER BY tab.table_name";

        // Remember If order of named sql column results change in this sql query, remapping is needed for dataSource binding.
        public  string getDatabaseTables() =>
            "SELECT "+getUpperOrLower("tab.table_name") +"  AS 'Table', tab.TABLE_ROWS AS 'Rows', tab.AVG_ROW_LENGTH AS 'AvgLen', " +
            "  tab.DATA_LENGTH AS 'Length', tab.DATA_FREE AS 'Free', tab.AUTO_INCREMENT 'AI', "+getUpperOrLower("tab.TABLE_COLLATION") +" AS 'Collation' " +
            " FROM information_schema.tables AS tab" +
            "  LEFT OUTER JOIN information_schema.statistics AS sta ON sta.table_schema = tab.table_schema " +
            "  AND sta.table_name = tab.table_name " +
            "  AND sta.index_name = 'primary'" +
            " WHERE tab.table_schema = '" + Database + "' " +
            "  AND tab.table_type = 'BASE TABLE'" +
            " GROUP BY tab.table_name " +
            " ORDER BY tab.table_name";

        public  string getDatabaseUniques() =>
            "SELECT DISTINCT tab.constraint_name AS 'Name', tab.table_name AS 'Table', tab.enforced AS 'Enforced' " +
            " FROM information_schema.TABLE_CONSTRAINTS tab " +
            " WHERE tab.CONSTRAINT_SCHEMA = '" + Database + "' " +
            " AND tab.CONSTRAINT_TYPE = 'UNIQUE'";

        public  string getDatabaseForeignKeys() =>
            "SELECT DISTINCT tab.constraint_name as 'Name', tab.table_name as 'Table', tab.column_name as 'Column', tab.referenced_table_name as 'Ref Table', " +
            " tab.referenced_column_name as 'Ref Col' from INFORMATION_SCHEMA.KEY_COLUMN_USAGE tab " +
            " INNER JOIN information_schema.TABLE_CONSTRAINTS con ON con.constraint_name = tab.constraint_name AND con.constraint_type = 'FOREIGN KEY' " +
            " WHERE tab.table_schema = '"+ Database + "'";

        public  string getAllFieldsFromAllTablesInDb()
        {
            return "SELECT "+ getUpperOrLower("c.table_name") + " , " + getUpperOrLower("c.column_name") +
                " , " + getUpperOrLower("c.data_type") + " , " + getUpperOrLower("c.is_nullable") + " , c.character_maximum_length " +
                "   FROM information_schema.columns c " +
                "   WHERE c.table_schema = '" + Database + "' order by c.column_name,c.table_name,c.ordinal_position";
        }

        private string getUpperOrLower(string field)
        {
            if (IsUpper)
            {
                return " UPPER(" + field + ") ";
            }
            return " LOWER(" + field + ") ";
        }

        public string getDatabases()
        {
            return "show databases;";
        }

        public List<string> getTables()
        {
            throw new NotImplementedException();
        }

        public List<string> getTableFields()
        {
            throw new NotImplementedException();
        }

        public List<string> removeSystemDatabases(List<string> databases, bool showSystemDb = false)
        {
            throw new NotImplementedException();
        }

        public string showTablesSql()
        {
            return "show tables from "+Database + ";";
        }

        [Implement("Need model for describe output and implementation")]
        public string describeTableSql(string table)
        {
            return "DESCRIBE "+table;
            //throw new NotImplementedException();
        }
    }

   
}
