using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace Firedump.core.parsers
{
    unsafe public struct pair
    {
        public long start;
        public long end;
        public pair(long start, long end)
        {
            this.start = start;
            this.end = end;
        }
    }

    class SqlStatementParser
    {
        private string originalSql;
        public SqlStatementParser(string originalSqlRef)
        {
            originalSql = originalSqlRef;
        }

        
        unsafe static private bool isLineBreak(char* head, char* line_break)
        {
            if (*line_break == '\0')
                return false;


            while (*head != '\0' && *line_break != '\0' && *head == *line_break)
            {
                head++;
                line_break++;
            }
            return *line_break == '\0';
        }

        unsafe static private char* skip_leading_whitespace(char* head, char* tail)
        {
            while (head < tail && *head <= ' ')
                head++;
            return head;
        }

        // checks if its only one char(usually happens with multi semicolons)
        unsafe private bool includeInRange(long start,long end)
        {
            return (originalSql.Substring((int)start,(int)end).Trim().Length > 1);
        }

        // Sometime in future convert it to fully managed safe c# code, and run tests
        unsafe public void determineStatementRanges(char* sql, int length, string initial_delimiter,List<pair> ranges, string line_break)
        {
            bool _stop = false;
            string delimiter = string.IsNullOrEmpty(initial_delimiter) ? ";" : initial_delimiter;
            IntPtr p = Marshal.StringToHGlobalAnsi(delimiter);
            char* delimiter_head = (char*)(p.ToPointer());
            char* start = (char*)(sql);
            char* keyword = (char*)Marshal.StringToHGlobalAnsi("delimiter").ToPointer();
            char* head = sql;
            char* tail = head;
            char* end = head + length;
            p = Marshal.StringToHGlobalAnsi(line_break);
            char* new_line = (char*)(p.ToPointer());
            bool have_content = false; // Set when anything else but comments were found for the current statement.
            int statementStart = 0;
            int currentLine = 0;
            p = Marshal.StringToHGlobalAnsi(line_break);
            char* newLine = (char*)(p.ToPointer());
            while (!_stop && tail < end)
            {
                switch (*tail)
                {
                    case '/': // Possible multi line comment or hidden (conditional) command.
                        if (*(tail + 1) == '*')
                        {
                            tail += 2;
                            bool is_hidden_command = (*tail == '!');
                            while (true)
                            {
                                while (tail < end && *tail != '*')
                                    tail++;
                                if (tail == end) // Unfinished comment.
                                    break;
                                else
                                {
                                    if (*++tail == '/')
                                    {
                                        tail++; // Skip the slash too.
                                        break;
                                    }
                                }
                            }

                            if (!is_hidden_command && !have_content)
                                head = tail; // Skip over the comment.
                        }
                        else
                            tail++;

                        break;

                    case '-': // Possible single line comment.
                        {
                            char* end_char = tail + 2;
                            if (*(tail + 1) == '-' && (*end_char == ' ' || *end_char == '\t' || isLineBreak(end_char, new_line)))
                            {
                                // Skip everything until the end of the line.
                                tail += 2;
                                while (tail < end && !isLineBreak(tail, new_line))
                                    tail++;
                                if (!have_content)
                                    head = tail;
                            }
                            else
                                tail++;

                            break;
                        }

                    case '#': // MySQL single line comment.
                        while (tail < end && !isLineBreak(tail, new_line))
                            tail++;
                        if (!have_content)
                            head = tail;
                        break;

                    case '"':
                    case '\'':
                    case '`': // Quoted string/id. Skip this in a local loop.
                        {
                            have_content = true;
                            char quote = *tail++;
                            while (tail < end && *tail != quote)
                            {
                                // Skip any escaped character too.
                                if (*tail == '\\')
                                    tail++;
                                tail++;
                            }
                            if (*tail == quote)
                                tail++; // Skip trailing quote char to if one was there.

                            break;
                        }
                    case 'd':
                    case 'D':
                        {
                            have_content = true;
                            // Possible start of the keyword DELIMITER. Must be at the start of the text or a character,
                            // which is not part of a regular MySQL identifier (0-9, A-Z, a-z, _, $, \u0080-\uffff).
                            //long previous = tail > start ? *(tail - 1) : 0;
                            char previous = tail > start ? (char)(*tail - 1) : (char)0;
                            bool is_identifier_char = previous >= 0x80 || (previous >= '0' && previous <= '9') ||
                                                      ((previous | 0x20) >= 'a' && (previous | 0x20) <= 'z') || previous == '$' ||
                                                      previous == '_';
                            if (tail == start || !is_identifier_char)
                            {
                                char* run = tail + 1;
                                char* kw = keyword;
                                int count = 9;
                                while (count-- > 1 && (*run++ | 0x20) == *kw++)
                                    ;
                                if (count == 0 && *run == ' ')
                                {
                                    // Delimiter keyword found. Get the new delimiter (everything until the end of the line).
                                    tail = run++;
                                    while (run < end && !isLineBreak(run, newLine))
                                        ++run;

                                    delimiter = "DELIMITER";//trim(tail, run - tail);
                                    delimiter_head = (char*)Marshal.StringToHGlobalAnsi(delimiter).ToPointer();
                                    // Skip over the delimiter statement and any following line breaks.
                                    while (isLineBreak(run, newLine))
                                    {
                                        ++currentLine;
                                        ++run;
                                    }
                                    tail = run;
                                    head = tail;
                                    statementStart = currentLine;
                                }
                                else
                                    ++tail;
                            }
                            else
                                ++tail;

                            break;
                        }
                    default:
                        if (isLineBreak(tail, newLine))
                        {
                            ++currentLine;
                            if (!have_content)
                                ++statementStart;
                        }
                        if (*tail > ' ')
                            have_content = true;
                        tail++;
                        break;
                }

                if (*tail == *delimiter_head)
                {
                    // Found possible start of the delimiter. Check if it really is.
                    int count = delimiter.Length;
                    if (count == 1)
                    {
                        // Most common case. Trim the statement and check if it is not empty before adding the range.
                        head = skip_leading_whitespace(head, tail);
                        if (head < tail)
                        {
                            long startT = head - (char*)sql;
                            long endT = tail - head;
                            if (includeInRange(startT, endT))
                            {
                                ranges.Add(new pair(startT, endT));
                            }
                        }
                            
                        head = ++tail;
                        have_content = false;
                    }
                    else
                    {
                        char* run = tail + 1;
                        char* del = delimiter_head + 1;
                        while (count-- > 1 && (*run++ == *del++))
                            ;

                        if (count == 0)
                        {
                            // Multi char delimiter is complete. Tail still points to the start of the delimiter.
                            // Run points to the first character after the delimiter.
                            head = skip_leading_whitespace(head, tail);
                            if (head < tail)
                            {
                                long startT = head - (char*)sql;
                                long endT = tail - head;
                                if (includeInRange(startT, endT))
                                {
                                    ranges.Add(new pair(startT, endT));
                                }
                            }
                            tail = run;
                            head = run;
                            have_content = false;
                        }
                    }
                }
            }

            // Add remaining text to the range list.
            head = skip_leading_whitespace(head, tail);
            if (head < tail)
            {
                long startT = head - (char*)sql;
                long endT = tail - head;
                if(includeInRange(startT, endT))
                {
                    ranges.Add(new pair(startT, endT));
                }   
            }
        }

       
    }
}
