using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.core.sql
{
    public interface ISqlBuilder
    {
        string getDatabases();

        List<string> getTables();

        List<string> getTableFields();

        string createDatabaseIndexes();

        string getDatabasePrimaryKeys();

        string getDatabaseTables();

        string getDatabaseUniques();

        string getDatabaseForeignKeys();

        string getAllFieldsFromAllTablesInDb();

        string showTablesSql();

        string describeTableSql(string table);

        List<string> removeSystemDatabases(List<string> databases, bool showSystemDb = false);
    }
}
