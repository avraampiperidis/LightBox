using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.jsonconfig.dto
{
    public class SqlDumpDto
    {
        //<!configuration fields section>
        /// <summary>
        /// temporal save path for dump files before saving to intended location
        /// </summary>
        public string tempSavePath { set; get; }
        /// <summary>
        /// the maximum wait time for dump completion before aborting
        /// </summary>
        public int databaseTimeout { set; get; } = 10000;
        /// <summary>
        /// whether to include create schema sql in the dump file
        /// </summary>
        public bool includeCreateSchema { set; get; } = true;
        /// <summary>
        /// whether to include table data in the dump file
        /// </summary>
        public bool includeData { set; get; } = true;
        /// <summary>
        /// wether to include comments in dump file
        /// </summary>
        public bool includeComments { set; get; } = true;
        /// <summary>
        /// Dumps in a single transaction with isolation level repetable read
        /// </summary>
        public bool singleTransaction { set; get; }
        /// <summary>
        /// Locks tables before dumping them (single transaction is better and there is no need for both of these)
        /// </summary>
        public bool lockTables { set; get; }
        /// <summary>
        /// Enclose the INSERT statements for each dumped table with SET autocommit = 0 and COMMIT statements
        /// </summary>
        public bool noAutocommit { set; get; }
        /// <summary>
        /// wether to disable foreign key checks in dump file (makes importing the dump file faster because the indexes are created after all rows are inserted)
        /// </summary>
        public bool disableForeignKeyChecks { set; get; } = true;
        /// <summary>
        /// wether to add drop database in the dump file
        /// </summary>
        public bool addDropDatabase { set; get; }
        /// <summary>
        /// wether to add create database in the dump file
        /// </summary>
        public bool createDatabase { set; get; } = true;
        /// <summary>
        /// produce output that is more compatible with other databse systems or with older mysql servers
        /// </summary>
        public bool moreCompatible { set; get; }
        /// <summary>
        /// custom comment to add in the header of the dump file leave empty or null for no comment
        /// </summary>
        public string addCustomCommentInHeader { set; get; } = "";
        /// <summary>
        /// default character set of the dump file
        /// </summary>
        public string characterSet { set; get; } = "utf8";

        //structure
        /// <summary>
        /// wether to add drop table/view/procedure/function in the dump file
        /// </summary>
        public bool addDropTable { set; get; } = true;
        /// <summary>
        /// Surround each table dump with LOCK TABLES and UNLOCK TABLES statements
        /// </summary>
        public bool addLocks { set; get; }
        /// <summary>
        /// wether to add if not exists sql in the dump file
        /// </summary>
        public bool addIfNotExists { set; get; } = true;
        /// <summary>
        /// wether to add auto increment values in the dump file
        /// </summary>
        public bool addAutoIncrementValue { set; get; } = true;
        /// <summary>
        /// wether to enclose table and field names in backquotes in the dump file
        /// </summary>
        public bool encloseWithBackquotes { set; get; } = true;
        /// <summary>
        /// wether to add create procedure and function statements in the sql file
        /// </summary>
        public bool addCreateProcedureFunction { set; get; }
        /// <summary>
        /// wether to add info comments (creation/update/check dates)
        /// </summary>
        public bool addInfoComments { set; get; } = true;

        //data
        /// <summary>
        /// use complete insert statements that include column names (larger dump file but durable to database structure changes)
        /// </summary>
        public bool completeInsertStatements { set; get; } = true;
        /// <summary>
        /// use multiple-row INSERT syntax that include serveral VALUES lists
        /// </summary>
        public bool extendedInsertStatements { set; get; }
        /// <summary>
        /// maximum length of insert query. If query exceeds the specified length it is split into smaller queries.
        /// </summary>
        public int maximumLengthOfQuery { set; get; } = 50000;
        /// <summary>
        /// the maximum packet length to send or recieve from the server (in MB)
        /// </summary>
        public int maximumPacketLength { set; get; } = 1024;
        /// <summary>
        /// write INSERT DELAYED statements rather than INSERT statements
        /// </summary>
        public bool useDelayedInserts { set; get; }
        /// <summary>
        /// write INSERT IGNORE statements rather than INSERT statements
        /// </summary>
        public bool useIgnoreInserts { set; get; }
        /// <summary>
        /// wether to dump triggers
        /// </summary>
        public bool dumpTriggers { set; get; }
        /// <summary>
        /// wether to dump events
        /// </summary>
        public bool dumpEvents { set; get; }
        /// <summary>
        /// dump binary columns using hexadecimal notation for example 'abc' becomes 0x616263)
        /// </summary>
        public bool useHexadecimal { set; get; } = true;
        /// <summary>
        /// 0 - INSERT statements
        /// 1 - REPLACE statements only replace works
        /// </summary>
        public int exportType { set; get; } = 0;
        /// <summary>
        /// If set to true the dump file is in xml form
        /// </summary>
        public bool xml { set; get; }
    }
}
