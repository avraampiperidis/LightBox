using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.core.sql
{
    // No reason to add 3 chars words
    // words record for intellisense popup menu only use.
    public sealed class Words
    {
        public static List<string> SQL = new List<string>()
        {
            "AGAINST",
            "AUTO_INCREMENT",
            "BETWEEN",
            "BIGINT",
            "BINARY",
            "BLOB",
            "BOOL",
            "BOOLEAN",
            "BOTH",
            "CASCADE",
            "CHANGE",
            "COALESCE",
            "COLLATE",
            "DATE",
            "DISTINCT",
            "EXISTS",
        };

        public const string INNER_JOIN = "INNER JOIN";
        public const string LEFT_JOIN = "LEFT JOIN";
        public const string FULL_OUTER_JOIN = "FULL OUTER JOIN";
        public const string RIGHT_JOIN = "RIGHT JOIN";

        public static readonly List<string> JOINS = new List<string>()
        {
            INNER_JOIN,
            LEFT_JOIN,
            FULL_OUTER_JOIN,
            RIGHT_JOIN
        };

        public static readonly List<string> PL_SQL = new List<string>()
        {
           // "BEGIN",
            "END IF",
            "DECLARE",
            "THEN",
            "LOOP"
        };
    }
}
