using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Firedump.utils.parsers.SqlStatementParser;

namespace Firedump.utils.parsers
{
    public class SqlStatementParserWrapper
    {
        private readonly string sql;
        public SqlStatementParserWrapper(string sql)
        {
            this.sql = sql;
        }

        // returns a list<struct::pair> with the ranges only without the sql.
        // This method is fast and capable of handling millions of lines of code
        public List<pair> Parse()
        {
            unsafe
            {
                List<pair> ranges = new List<pair>();
                SqlStatementParser p = new SqlStatementParser(this.sql);
                fixed (char* s = sql)
                {
                    p.determineStatementRanges(s, sql.Length, ";", ranges, "\n");
                    return ranges;                   
                }
            }
        }

        // In case that someone need to convert a List<pair> to. ready to use list<string> with the sql statements!
        // The two methods are seperated and optional 
        // for the need of speed that provides the Parse method(capable of handling hundreds of thousands of lines of sql)
        // optional trim default to true, trim the statements the start and end
        public List<string> convert(List<pair> ranges,bool trim = true)
        {
            List<string> pairs = new List<string>();
            foreach(pair p in ranges) {
                string statement = this.sql.Substring((int)p.start, (int)p.end);
                if(trim)
                {
                    statement = statement.Trim();
                }
                pairs.Add(statement);
            }
            return pairs;
        }

    }
}
