using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.creational
{
    class OracleSqlBuilder : ISqlBuilder
    {
        public string SCHEMA;
        public bool IsUpper;

        public OracleSqlBuilder(string schema,bool isUpper = true)
        {
            this.SCHEMA = schema;
            this.IsUpper = isUpper;
        }

        public string createDatabaseIndexes()
        {
            throw new NotImplementedException();
        }

        public string getAllFieldsFromAllTablesInDb()
        {
            throw new NotImplementedException();
        }

        public string getDatabaseForeignKeys()
        {
            throw new NotImplementedException();
        }

        public string getDatabasePrimaryKeys()
        {
            throw new NotImplementedException();
        }

        public string getDatabaseTables()
        {
            throw new NotImplementedException();
        }

        public string getDatabaseUniques()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public string describeTableSql(string table)
        {
            throw new NotImplementedException();
        }
    }
}
