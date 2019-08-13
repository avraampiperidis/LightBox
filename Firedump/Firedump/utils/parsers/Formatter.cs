using Firedump.models.sql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Firedump.utils.editor
{
    // https://github.com/mitchavines/SQL_Formatter
    //An Experimental sql formatter
    internal class Formatter
    {

        private int tabLevel = 0;               // SQL indentation
        private int procLevel = 0;              // T-SQL indentation
        private int parenLevel = 0;             // Nested parens
        private int caseLevel = 0;              // Case statement indentation
        private string stmt = null;             // Statement being formatted

        private StringBuilder result = null;    // The formatted statement


        #region Properties

        public bool Success { get; private set; }

        public string LastResult { get; private set; }

        #endregion

        #region Methods

        private string UnFormat(string str)
        {
            int index = 0;
            int eot = 0;
            string ch = null;
            var result = new StringBuilder();

            while (index < str.Length)
            {
                ch = str.Substring(index, 1);

                if (ch == "/" && str.Substring(index, 2) == "/*")
                {
                    eot = str.IndexOf("*/", index) + 2;
                    if (eot < index)
                        throw new MyFormatterException("Unterminated comment (/*).");
                    result.Append(str.Substring(index, eot - index));
                    index = eot;
                    continue;
                }

                if (ch == "-" && str.Substring(index, 2) == "--")
                {
                    eot = str.IndexOf("\r\n", index) + 2;
                    if (eot < index)
                        eot = str.Length;
                    result.Append(str.Substring(index, eot - index));
                    index = eot;
                    continue;
                }

                if (ch == "[")
                {
                    eot = str.IndexOf("]", index) + 1;
                    if (eot < index)
                        throw new MyFormatterException("Unterminated literal ([).");
                    result.Append(str.Substring(index, eot - index));
                    index = eot;
                    continue;
                }

                if (ch == "'")
                {
                    eot = str.IndexOf("'", index + 1) + 1;
                    if (eot < index)
                        throw new MyFormatterException("Unterminated literal (').");
                    result.Append(str.Substring(index, eot - index));
                    index = eot;
                    continue;
                }

                if (ch == "\"")
                {
                    eot = str.IndexOf("\"", index + 1) + 1;
                    if (eot < index)
                        throw new MyFormatterException("Unterminated literal (\").");
                    result.Append(str.Substring(index, eot - index));
                    index = eot;
                    continue;
                }

                if (ch.In(new string[] { "\r", "\n", "\t" }))
                    ch = " ";

                switch (ch)
                {
                    case " ":           // Collapse whitespace
                        if (result.Right(1).In(new string[] { "(", " " })) ch = "";
                        break;

                    case "(":           // Force leading spaces
                        if (result.Right(1) != " " & str.Mid(index + 1, index + 7).Equals("select", Str.IgnoreCase))
                            ch = " " + ch;
                        break;

                    case ")":           // Force trailing spaces
                    case ",":
                        if (result.Right(1) == " ") result.Length--;    // = Result.Left(-1);
                        ch = ch + " ";
                        break;

                    case "=":           // Whitespace around operators
                    case "+":
                    case "-":
                    case "<":
                    case ">":
                        if (index < str.Length - 2 && ch != "<" | str.Substring(index + 1, 1) != ">")
                            if (!result.Right(1).In(" ><")) ch = " " + ch + " ";
                        break;
                }
                result.Append(ch);
                index++;
            }

            // Force comments and literals to be recognized as discrete tokens
            result = result.Replace("--", " --");
            result = result.Replace("/*", " /*");

            return result.ToString();
        }

        internal string Format(string sql,string options = null)
        {
            try
            {
                return _format_sql_code(sql, options);
            }catch(Exception ex)
            {
                this.Success = false;
            }
            return sql;
        }

        /// <summary>
        /// A simple SQL formatter
        /// </summary>
        /// <remarks>
        /// On failure, sets the Success property to false and the LastResult property to an informational message.
        /// This allows the calling code to consume or ignore the result appropriately and use LastResult in an error message.
        /// </remarks>
        /// <param name="sql"></param>
        /// <param name="options">
        ///     LeadingCommas, Boolean = false
        ///     LeadingJoins, Boolean = true
        ///     RemoveComments, Boolean = false
        /// </param>
        /// <returns>
        /// The formatted statement
        /// </returns>
        internal string _format_sql_code(string sql, string options = null)
        {
            string token = null;                                        // A syntactic element extracted from the statement
            int stmtIndex = 0;                                          // Position in the statement being parsed
            int tknIndex = 0;                                           // Position in a single token being parsed
            int tmpIndex = 0;
            string previousToken = "";                                  // Track multi-part tokens
            int currentParens = -1;                                     // Current depth of parentheses nesting
            int cte = -1;
            List<string> currentKeyword = new List<string>() { "" };    // The SQL keyword being parsed at each level
            DateTime startTime = DateTime.Now;
            var args = new KVP.List(options);
            bool startsWithCreate = false;

            // Force title case for common SQL functions

            string[] sqlFunctions = SQL.SQL_FUNCTIONS;
                //{ "Min", "Max", "Sum", "Count",
                //"CharIndex", "Upper", "Lower", "Replace", "Len", "Left", "Right", "RTrim", "LTrim", "Substring",
                //"GetDate", "DateAdd", "DateDiff", "DatePart", "Year", "Month", "Day", "Hour", "Minute", "Second",
                //"IsNull", "Coalesce", "Cast", "Convert", "Avg", "Abs","Power", "Round" };
                    
            for(int i=0; i < sqlFunctions.Length; i++)
            {
                sqlFunctions[i] = sqlFunctions[i].ToUpper();
            }
            // Setup
            Success = false;
            stmt = sql;
            result = new StringBuilder("");

            // Remove escaped apostrophes
            sql = sql.Replace("''", ASCII.SUB.ToString());

            // Remove formatting
            try { sql = UnFormat(sql); }
            catch (Exception ex)
            { return Fail(ex.Message); }

            if (sql.Length > 10 && sql.Substring(0, 8).Trim().ToLower().StartsWith("create"))
            {
                startsWithCreate = true;
            }
            // Parse the statement 
            while (stmtIndex < sql.Length)
            {
                
                //  Skip leading spaces
                while (stmtIndex < sql.Length && sql.Substring(stmtIndex, 1) == " ")
                    stmtIndex++;

                // Grab the next token, space delimited
                if (sql.IndexOf(" ", stmtIndex) > -1)
                    token = sql.Substring(stmtIndex, sql.IndexOf(" ", stmtIndex) - stmtIndex);
                else
                    token = sql.Substring(stmtIndex, sql.Length - stmtIndex);

                if (startsWithCreate && token.EndsWith(","))
                {
                    token += "\n";
                }

                if (token.StartsWith("--"))
                {
                    tknIndex = sql.IndexOf("\r\n", stmtIndex) + 2;
                    if (tknIndex < stmtIndex)
                        tknIndex = sql.Length;
                    if (!args.GetBoolean("RemoveComments", false))
                        result.Append(sql.Substring(stmtIndex, tknIndex - stmtIndex));
                    stmtIndex = tknIndex;
                    continue;
                }

                if (token.StartsWith("/*"))
                {
                    tknIndex = sql.IndexOf("*/", stmtIndex) + 2;
                    if (!args.GetBoolean("RemoveComments", false))
                        result.Append(sql.Substring(stmtIndex, tknIndex - stmtIndex));
                    stmtIndex = tknIndex;
                    continue;
                }

                if (NetDelims(token, "'", "'") != 0)
                {
                    tmpIndex = stmtIndex + token.Length;
                    tknIndex = sql.IndexOf("'", tmpIndex) + 1;
                    token += sql.Substring(tmpIndex, tknIndex - tmpIndex);
                }

                if (NetDelims(token, "\"", "\"") != 0)
                {
                    tmpIndex = stmtIndex + token.Length;
                    tknIndex = sql.IndexOf("\"", tmpIndex) + 1;
                    token += sql.Substring(tmpIndex, tknIndex - tmpIndex);
                }

                if (NetDelims(token, "[", "]") != 0)
                {
                    tmpIndex = stmtIndex + token.Length;
                    tknIndex = sql.IndexOf("]", tmpIndex) + 1;
                    token += sql.Substring(tmpIndex, tknIndex - tmpIndex);
                }

                // Comma whitespace
                if (token.Left(1) == ",") token = ",";

                // Build up multi-part keywords
                token = previousToken + token;
                stmtIndex -= previousToken.Length;
                previousToken = "";

                // Pull the case keyword out for special handling
                if (token.Right(5).Equals("(case", Str.IgnoreCase))
                    token = token.Left(-4);

                // Manage paren nesting
                if (token.Contains("(") || token.Contains(")"))
                {
                    parenLevel += NetParens(token);
                    if (parenLevel < 0)
                        return Fail("Unexpected closing parenthesis.");
                }

                // SQL functions
                foreach (string Func in sqlFunctions)
                    token = token.Replace(Func + "(", Func + "(", Str.IgnoreCase);

                // An error of this type will cause an infinite loop if not thrown
                if (token == "")
                {
                    if (stmtIndex < sql.Length)
                        return Fail("Parsed element collapsed to empty string.");
                    else
                        break;
                }

                stmtIndex = stmtIndex + token.Length;
                // Multi-part keywords
                switch (token.ToLower())
                {
                    case "order":
                    case "group":
                    case "outer":
                    case "inner":
                    case "left":
                    case "right":
                    case "cross":
                    case "left outer":
                    case "right outer":
                        previousToken = token.ToLower() + " ";
                        continue;

                    case "union":
                        if (sql.Substring(stmtIndex + 1, 3).Equals("all", Str.IgnoreCase))
                        {
                            previousToken = token.ToLower() + " ";
                            continue;
                        }
                        break;

                    case "insert":
                        if (sql.Substring(stmtIndex + 1, 4).Equals("into", Str.IgnoreCase))
                        {
                            previousToken = token.ToLower() + " ";
                            continue;
                        }
                        break;
                }
                // Keywords
                switch (token.ToLower())
                {
                    case "select":
                        // Begin a select statement
                        // Pushes occur below, see tabLevel
                        if (cte == tabLevel)
                        {
                            // Keep together--prevent the default vertical whitespace
                            token = Tabs(true) + token.ToLower();
                            cte = -1;
                        }
                        else if (currentKeyword[tabLevel] == "")
                            // New statement
                            token = Tabs() + token.ToLower();
                        else if (currentKeyword[tabLevel] == "if")
                            // SQL conditional
                            token = Tabs(true) + "\t" + token.ToLower();
                        else if (!currentKeyword[tabLevel].In(new string[] { "select", "insert", "insert into", "if" }))
                            // Force vertical whitespace
                            token = (result.gtr("") & result.Right(4) != Str.Repeat(Str.NewLine, 2) ? Str.NewLine : "") + Tabs(true, 1) + token.ToLower();
                        else
                            // Newline only
                            token = Tabs(true) + token.ToLower();

                        currentKeyword[tabLevel] = "select";
                        currentParens = parenLevel;
                        break;

                    case "from":
                    case "where":
                    case "order by":
                    case "group by":
                    case "having":
                    case "with":
                    case "with;":
                    case "for":
                    case "into":
                    case "over":
                        // CTE
                        if (token.ToLower() == "with")
                            cte = tabLevel;

                        // Newlines
                        currentKeyword[tabLevel] = token.ToLower();
                        token = Tabs(true) + token.ToLower();
                        break;

                    case "create":
                        token += "\n";
                        break;
                    case "insert":
                    case "insert into":
                    case "update":
                    case "delete":
                    case "drop":
                        // Vertical whitespace
                        string Buffer = currentKeyword[tabLevel];
                        currentKeyword[tabLevel] = token.ToLower();
                        if (Buffer != "if")
                            token = (result.gtr("") & !Buffer.In(new string[] { "select", "if" }) & result.Right(2) != Str.NewLine ? Str.NewLine : "") + Tabs(true, 2) + token.ToLower();
                        else
                            token = Tabs(true) + "\t" + token.ToLower();
                        break;

                    case "and":
                    case "or":
                        // Wrap where clause and join conditions
                        if (args.GetBoolean("LeadingCommas", false))
                        {
                            if (currentKeyword[tabLevel] == "where")
                                token = token.ToLower() + Tabs(true) + "\t";
                            else
                                token = token.ToLower();
                        }
                        else
                        {
                            if (currentKeyword[tabLevel] == "where")
                                token = Tabs(true) + "\t" + token.ToLower();
                            else
                                token = token.ToLower();
                        }
                        break;

                    case "case":
                        // Push case statement
                        token = (currentKeyword[tabLevel] == "func" ? Tabs(true) + "\t" : "") + token.ToLower();
                        caseLevel++;
                        break;

                    case "when":
                        // Wrap case statements
                        if (caseLevel == 0)
                        {
                            return Fail("Unexpected when without case.");
                        }
                        token = Tabs(true) + "\t\t" + token.ToLower();
                        break;

                    case "not":
                    case "exists":
                    case "top":
                    case "as":
                    case "in":
                    case "on":
                    case "unique":
                    case "distinct":
                    case "within":
                    case "group":
                    case "all":
                    case "percent":
                    case "asc":
                    case "desc":
                    case "with ties":
                    case "partition":
                    case "by":
                    case "is":
                    case "index":
                    case "table":
                        // SQL keywords lowercase
                        token = token.ToLower();
                        break;

                    case "union":
                    case "union all":
                    case "except":
                    case "intersect":
                        // Vertical whitespace before and after
                        token = Str.NewLine + Tabs(true) + token.ToLower() + Str.NewLine + Str.NewLine;
                        break;

                    case "set":
                        // T-SQL vs. SQL
                        if (sql.Substring(stmtIndex + 1, 1) == "@")
                            // T-SQL set statement
                            token = Tabs(true) + token.ToUpper();
                        else
                        {
                            // SQL update statement
                            currentKeyword[tabLevel] = token.ToLower();
                            token = Tabs(true) + token.ToLower();
                        }
                        break;

                    case "else":
                        // SQL vs. T-SQL
                        if (caseLevel > 0) // (Case_Statement.Count > 0)
                        {
                            // SQL case else
                            token = Tabs(true) + "\t\t" + token.ToLower();
                        }
                        else
                        {
                            // T-SQL hanging indent
                            procLevel--;
                            token = Tabs(true) + token.ToUpper() + Str.NewLine;
                            procLevel++;
                        }
                        break;

                    case "then":
                        if (caseLevel > 0)
                            token = token.ToLower();
                        else
                            token = token.ToUpper();
                        break;

                    case "end":
                    case "end)":
                    case "end,":
                    case "end),":
                        // SQL vs. T-SQL
                        if (caseLevel > 0)
                        {
                            // Pop case statement
                            token = Tabs(true) + "\t" + token.ToLower();
                            caseLevel--;
                        }
                        else
                        {
                            // Pop proc level
                            procLevel--;
                            token = Tabs(true) + token.ToUpper() + Str.NewLine;
                            if (procLevel < 0)
                                return Fail("Unexpected T-SQL END.");
                        }
                        break;

                    case "cursor":
                    case "option":
                        // T-SQL keywords uppercase
                        token = token.ToUpper();
                        break;

                    case "declare":
                        if (currentKeyword[tabLevel].gtr(""))
                        {
                            token = Str.NewLine + Tabs(true) + token.ToUpper();
                            currentKeyword[tabLevel] = "";
                        }
                        else
                            token = Tabs(true) + token.ToUpper();
                        break;

                    case "use":
                    case "if":
                    case "exec":
                    case "dbcc":
                    case "open":
                    case "close":
                    case "fetch":
                    case "deallocate":
                        // T-SQL vertical whitespace 
                        currentKeyword[tabLevel] = token.ToLower();
                        token = (result.Right(4) != Str.NewLine + Str.NewLine ? Str.NewLine : "") + Tabs(true) + token.ToUpper();
                        break;

                    case "begin":
                        // Push proc level
                        token = (currentKeyword[tabLevel] != "if" ? Str.NewLine : "") + Tabs(true) + token.ToUpper() + Str.NewLine;
                        procLevel++;
                        currentKeyword[tabLevel] = "";
                        break;

                    case "return":
                        // Vertical whitespace before and after
                        token = Str.NewLine + Tabs(true) + token.ToUpper() + Str.NewLine + Str.NewLine;
                        break;

                    case "join":
                    case "inner join":
                    case "outer join":
                    case "left join":
                    case "right join":
                    case "left outer join":
                    case "right outer join":
                    case "cross join":
                    case "cross apply":
                    case "outer apply":
                        // New, indented line
                        if (args.GetBoolean("LeadingJoins", true))
                            token = Tabs(true) + "\t" + token.ToLower();
                        else
                            token = token.ToLower() + Tabs(true) + "\t";
                        break;

                    case "values":
                        token = Str.NewLine + token.ToLower() + Tabs(true) + "\t";
                        break;

                    case "null":
                        // Force uppercase
                        token = token.ToUpper();
                        break;

                    default:
                        if(stmtIndex < sql.Length)
                        {
                            var s = currentKeyword[tabLevel];
                            var ss = sql[stmtIndex];
                            if (currentKeyword[tabLevel] == "insert into"
                                && token.Left(1) != "(" & token.Right(1) != ")"
                                && sql[stmtIndex] != '.'
                                && sql[stmtIndex] != '['
                                && sql[stmtIndex] != ']')
                                token = token + Tabs(true) + "\t";
                        }
                        break;
                }

                // Increase tab level -- select
                if (token.Equals("(select", Str.IgnoreCase))
                {
                    tabLevel++;
                    token = (result.Right(1) != "\t" ? Tabs(true) : "") + "(" + Str.NewLine + Tabs() + "select";
                    currentKeyword.Add("select");
                    currentParens = parenLevel;
                }

                // Increase tab level -- partition
                if (token.Equals("(partition", Str.IgnoreCase))
                {
                    tabLevel++;
                    token = (result.Right(1) != "\t" ? Tabs(true) : "") + "(" + Str.NewLine + Tabs() + "partition";
                    currentKeyword.Add("partition");
                    currentParens = parenLevel;
                }

                // Increase tab level -- others
                while (parenLevel > tabLevel)
                {
                    tabLevel++;
                    currentKeyword.Add("func");
                }

                // Decrease tab level
                tknIndex = 0;
                int intBuffer = token.IndexOf("(");
                tknIndex = token.IndexOf(")", tknIndex);
                while (parenLevel < tabLevel)
                {
                    // Step over functions contained within this token
                    while (intBuffer > 0 & intBuffer <= tknIndex)
                    {
                        intBuffer = token.IndexOf("(", intBuffer + 1);
                        tknIndex = token.IndexOf(")", tknIndex + 1);
                    }
                    // (pop select)
                    if (currentKeyword[tabLevel] != "func")
                    {
                        token = token.Left(tknIndex) + Str.NewLine + Tabs() + token.Right(token.Length - tknIndex);
                    }
                    currentKeyword.RemoveAt(tabLevel);
                    tabLevel--;
                    tknIndex = token.IndexOf(")", tknIndex + 1);
                }

                // Wrap select and set clauses
                if (currentKeyword[tabLevel].In(new string[] { "select", "set" }, Str.IgnoreCase) & parenLevel == tabLevel & token.Right(1) == ",")
                {
                    if (args.GetBoolean("LeadingCommas", false))
                    {
                        token = token.Left(-1);
                        token += Str.NewLine + Tabs() + "\t,";
                    }
                    else
                        token += Str.NewLine + Tabs() + "\t";
                }

                // Collapse whitespace
                if (token.Right(2) != Str.NewLine
                    & token.Right(1) != "\t"
                    & token.Right(1) != "("
                    & token.Right(1) != ";"
                    & token.Right(1) != "."
                    & sql.Substring(System.Math.Min(stmtIndex + 1, sql.Length - 1), 1) != ","
                    & sql.Substring(System.Math.Min(stmtIndex + 1, sql.Length - 1), 1) != ")")
                    token += " ";
                if (token.Left(1).In(new string[] { ".", ",", ")", "]" }) & result.Right(1) == " ")
                    result.Length--;
                // Newline "with" queries in CTEs
                if (token.Left(1) == "(" & result.Right(4) == " as ")
                    token = Tabs(true) + token;

                // SQL end-of-statement
                if (token == ";")
                {
                    if (result.Right(1) == " ")
                        result.Length--;
                    token = token + Str.NewLine;
                }

                //Debug.Print(token);
                result.Append(token);
            }

            // Restore escaped apostrophes
            result = result.Replace(ASCII.SUB.ToString(), "''");

            if (tabLevel != 0) return Fail("Unbalanced indentation.");
            if (parenLevel != 0) return Fail("Unbalanced parentheses.");
            if (procLevel != 0) return Fail("Unbalanced statement blocks.");
            if (caseLevel != 0) return Fail("Unclosed case statement.");

            // Oy, comments
            result = result.Replace("/*", "\r\n/*");
            result = result.Replace("\r\n\r\n/*", "\r\n/*");

            Success = true;
            LastResult = result.Trim();
            return LastResult;
        }

        #endregion

        #region Helpers

        /// <summary>
        /// ABEND
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private string Fail(string message)
        {
            LastResult = $"Formatting terminated on error: {message}\r\n\r\n{Str.Elipses(stmt, 50, 50)}";
            Success = false;
            return $"/*\r\nFormatting terminated on error: {message}\r\n*/\r\n\r\n{stmt}";
        }

        /// <summary>
        /// Check for unbalanced delimiters within a string
        /// </summary>
        /// <param name="S"></param>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        private int NetDelims(string S, string t1, string t2)
        {
            int Index = 0;
            int Result = 0;
            string literal = null;
            string chr = null;
            string str = null;

            // Bail if nothing to do
            if (!S.Contains(new string[] { t1, t2 }))
                return 0;

            for (Index = 0; Index < S.Length; Index++)
            {
                chr = S.Substring(Index, 1);
                str = Index < S.Length - 2 ? S.Substring(Index, 2) : null;

                if (chr.In("'\""))
                {
                    if (literal == null)
                    {
                        if (chr.In(t1 + t2))
                            Result++;
                        literal = chr;
                    }
                    else if (chr == literal)
                    {
                        if (chr.In(t1 + t2))
                            Result--;
                        literal = null;
                    }
                }

                if (chr == "[" && literal == null)
                {
                    if (chr == t1)
                        Result++;
                    literal = chr;
                }
                if (chr == "]" && literal == "[")
                {
                    if (chr == t2)
                        Result--;
                    literal = null;
                }

                if (str == null)
                    continue;

                if (str.In("--/*") && literal == null)
                {
                    if (str == t1)
                        Result++;
                    literal = str;
                }
                if (str == "\r\n" && literal.In("--/*"))
                {
                    if (chr == t2)
                        Result--;
                    literal = null;
                }
            }

            return Result;
        }

        /// <summary>
        /// Check for balanced paretheses within a string
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        private int NetParens(string S)
        {
            int Index = 0;
            int Result = 0;
            string literal = null;

            for (Index = 0; Index < S.Length; Index++)
            {
                switch (literal)
                {
                    case null:
                        if (Index < S.Length - 1 && S.Substring(Index, 1).In("'\"["))
                            literal = S.Substring(Index, 1);
                        if (Index < S.Length - 2 && S.Substring(Index, 2).In("--/*"))
                            literal = S.Substring(Index, 2);
                        break;

                    case "'":
                        if (S.Substring(Index, 1) == "'")
                            literal = null;
                        break;
                    case "\"":
                        if (S.Substring(Index, 1) == "\"")
                            literal = null;
                        break;
                    case "[":
                        if (S.Substring(Index, 1) == "]")
                            literal = null;
                        break;
                    case "--":
                        if (S.Substring(Index, 2) == "\r\n")
                            literal = null;
                        break;
                    case "/*":
                        if (S.Substring(Index, 2) == "*/")
                            literal = null;
                        break;
                }

                if (literal == null)
                {
                    if (S.Substring(Index, 1) == "(") Result++;
                    if (S.Substring(Index, 1) == ")") Result--;
                }
            }

            return Result;
        }

        /// <summary>
        /// Return horizontal whitespace to provide the appropriate level of indentation 
        /// </summary>
        /// <remarks>
        /// Also manages leading newlines
        /// </remarks>
        /// <param name="newline"></param>
        /// <returns></returns>
        private string Tabs(bool newline = false, int maxnewlines = 2)
        {
            int Indent = tabLevel + procLevel + caseLevel;

            return (newline & result.gtr("") & result.Right(maxnewlines * 2) != Str.Repeat(Str.NewLine, maxnewlines) ? Str.NewLine : "") + Str.Repeat("\t", Indent);
        }

        #endregion
    }
}
