using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Firedump.utils.editor
{
    // https://github.com/mitchavines/SQL_Formatter
    public static class ASCII
    {
        public static readonly char NUL = "\x00"[0];   // Null
        public static readonly char SOH = "\x01"[0];   // Start of heading
        public static readonly char STX = "\x02"[0];   // Start of text
        public static readonly char ETX = "\x03"[0];   // End of text
        public static readonly char EOT = "\x04"[0];   // End of transmission
        public static readonly char ENQ = "\x05"[0];   // Enquiry
        public static readonly char ACK = "\x06"[0];   // Acknowledgement
        public static readonly char BEL = "\x07"[0];   // Bell
        public static readonly char BS = "\x08"[0];    // Backspace
        public static readonly char TAB = "\x09"[0];   // Tab
        public static readonly char LF = "\x0A"[0];    // Line feed
        public static readonly char VT = "\x0B"[0];    // Vertical tab
        public static readonly char FF = "\x0C"[0];    // Form feed
        public static readonly char CR = "\x0D"[0];    // Carriage return
        public static readonly char SO = "\x0E"[0];    // Shift out
        public static readonly char SI = "\x0F"[0];    // Shift in
        public static readonly char DLE = "\x10"[0];   // Data link escape
        public static readonly char DC1 = "\x11"[0];   // Device control 1
        public static readonly char DC2 = "\x12"[0];   // Device control 2
        public static readonly char DC3 = "\x13"[0];   // Device control 3
        public static readonly char DC4 = "\x14"[0];   // Device control 4
        public static readonly char NAK = "\x15"[0];   // Negative acknowledgement
        public static readonly char SYN = "\x16"[0];   // Synchronous idle
        public static readonly char ETB = "\x17"[0];   // End of transmission block
        public static readonly char CAN = "\x18"[0];   // Cancel
        public static readonly char EM = "\x19"[0];    // End of medium
        public static readonly char SUB = "\x1A"[0];   // Substitute
        public static readonly char ESC = "\x1B"[0];   // Escape
        public static readonly char FS = "\x1C"[0];    // File separator
        public static readonly char GS = "\x1D"[0];    // Group separator
        public static readonly char RS = "\x1E"[0];    // Record separator
        public static readonly char US = "\x1F"[0];    // Unit separator
        public static readonly char DEL = "\x7F"[0];   // Delete
    } // ASCII

    public static class Str
    {
        public static string NewLine = Environment.NewLine;
        public const StringComparison IgnoreCase = StringComparison.CurrentCultureIgnoreCase;
        public const StringComparison UseCase = StringComparison.CurrentCulture;

        /// <summary>
        /// Supports propagation of case-sensitivity from string methods to RegEx implementations
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        internal static RegexOptions ToRegEx(this StringComparison option)
        {
            switch (option)
            {
                case StringComparison.CurrentCultureIgnoreCase:
                case StringComparison.InvariantCultureIgnoreCase:
                case StringComparison.OrdinalIgnoreCase:
                    return RegexOptions.IgnoreCase;

                default:
                    return RegexOptions.None;
            }
        }

        /// <summary>
        /// Greater than
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Value"></param>
        /// <param name="comparisonType"></param>
        /// <returns></returns>
        internal static bool gtr(this string str, string Value, StringComparison comparisonType = UseCase)
        {
            if (str != null & Value != null)
                return comparisonType == UseCase ? str.CompareTo(Value) > 0 : str.ToLower().CompareTo(Value.ToLower()) > 0;
            return false;
        }

        /// <summary>
        /// Returns a string consisting a substring repeated multiple times
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        internal static string Repeat(string str, int Length)
        {
            string Result = "";

            for (int Counter = 0; Counter < Length; Counter++)
            { Result += str; }
            return Result;
        }
        /// <summary>
        /// Returns a string consisting a character repeated multiple times
        /// </summary>
        /// <param name="chr"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        internal static string Repeat(char chr, int Length)
        { return new string(chr, Length); }


        #region String Extensions

        /// <summary>
        /// Returns a value indicating whether a specified values occurs within this string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Value">Substring to search for</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static bool Contains(this string str, string Value, StringComparison comparisonType = UseCase)
        {
            return Regex.IsMatch(str, Regex.Escape(Value), comparisonType.ToRegEx());
        }
        /// <summary>
        /// Returns a value indicating whether any of the specified values occurs within this string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Values">List of substrings to search for</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static bool Contains(this string str, IEnumerable<string> Values, StringComparison comparisonType = UseCase)
        {
            foreach (string Entry in Values)
            {
                if (str.Contains(Entry, comparisonType))
                    return true;
            }
            return false;
        }

        public static bool StartsWith(this string str, IEnumerable<string> Values, StringComparison comparisonType = UseCase)
        {
            foreach (string Entry in Values)
            {
                if (str.StartsWith(Entry, comparisonType))
                    return true;
            }
            return false;
        }
        public static bool EndsWith(this string str, IEnumerable<string> Values, StringComparison comparisonType = UseCase)
        {
            foreach (string Entry in Values)
            {
                if (str.EndsWith(Entry, comparisonType))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the number of times a substring is found
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Value"></param>
        /// <param name="comparisonType"></param>
        /// <returns></returns>
        public static int Count(this string str, string Value, StringComparison comparisonType = UseCase)
        {
            int Index = 0;
            int Result = 0;

            Index = str.IndexOf(Value, Index, comparisonType);
            while (Index > -1)
            {
                Result++;
                Index = str.IndexOf(Value, Index + 1, comparisonType);
            }
            return Result;
        }

        /// <summary>
        /// Truncates a string adding elipses if required
        /// </summary>
        /// <remarks>
        /// Examples:
        /// string S = "The quick brown fox jumps over the lazy dog."
        /// S.Elipses(25) == "The quick brown fox ju..."
        /// S.Elipses(25, 5) == "The quick brown f... dog."
        /// S.Elipses(25, 25) == "...mps over the lazy dog."
        /// </remarks>
        /// <param name="str"></param>
        /// <param name="Length">Maximum length of the string to be returned</param>
        /// <param name="Tail">Original characters to preserve at the end of the string</param>
        /// <returns></returns>
        public static string Elipses(this string str, int Length, int Tail = 0)
        {
            string Result = "";

            if (str.Length <= Length)
            {
                // String is short enough, do nothing
                Result = str;
            }
            else if (Length < 4)
            {
                // Nothing to do
                Result = "...";
            }
            else if (Tail == 0)
            {
                // No tail, append elipses
                Result = Left(str, Length - 3) + "...";
            }
            else if (Tail < (Length - 3))
            {
                // Insert elipses
                Result = Left(str, Length - (Tail + 3)) + "..." + Right(str, Tail);
            }
            else
            {
                // Prepend elipses
                Result = "..." + Right(str, Length - 3);
            }
            return Result;
        }

        /// <summary>
        /// Checks that a string is included in a list of values
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Values">The list of values</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static bool In(this string str, IEnumerable<string> Values, StringComparison comparisonType = UseCase)
        {
            foreach (string Entry in Values)
            {
                if (Entry.Equals(str, comparisonType))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Checks if this string is a substring of another
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Value"></param>
        /// <param name="comparisonType"></param>
        /// <returns></returns>
        public static bool In(this string str, string Value, StringComparison comparisonType = UseCase)
        {
            return Value.IndexOf(str) != -1;
        }

        /// <summary>
        /// Reports the index of the first occurrence of any of the strings specified
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Values">List of strings to search for</param>
        /// <param name="startIndex">Starting position for the search</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static int IndexOf(this string str, IEnumerable<string> Values, int startIndex = 0, StringComparison comparisonType = UseCase)
        {
            string Buffer = null;
            return IndexOf(str, Values, startIndex, comparisonType, out Buffer);
        }
        public static int IndexOf(this string str, IEnumerable<string> Values, int startIndex, StringComparison comparisonType, out string foundValue)
        {
            int Result = str.Length;
            int Index = -1;

            foundValue = null;

            foreach (string Entry in Values)
            {
                Index = str.IndexOf(Entry, startIndex, comparisonType);
                if (Index > -1 & Index < Result)
                {
                    Result = Index;
                    foundValue = Entry;
                }
            }
            return Result < str.Length ? Result : -1;
        }

        /// <summary>
        /// Reports the index of the last occurrence of any of the strings specified
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Values">List of strings to search for</param>
        /// <param name="startIndex">Starting position for the search</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static int LastIndexOf(this string str, IEnumerable<string> Values, int startIndex = -1, StringComparison comparisonType = UseCase)
        {
            string Buffer = null;
            return LastIndexOf(str, Values, startIndex, comparisonType, out Buffer);
        }
        private static int LastIndexOf(this string str, IEnumerable<string> Values, int startIndex, StringComparison comparisonType, out string foundValue)
        {
            int Result = -1;
            int Index = -1;

            //if (Values == null) throw new BadCallException();
            foundValue = null;
            if (startIndex == -1) startIndex = str.Length;

            foreach (string Entry in Values)
            {
                Index = Entry != "" ? str.LastIndexOf(Entry, startIndex, comparisonType) : str.Length;
                if (Index > Result)
                {
                    Result = Index;
                    foundValue = Entry;
                }
            }
            return Result;
        }

        /// <summary>
        /// Checks if a string matches pattern
        /// </summary>
        /// <param name="str"></param>
        /// <param name="patternValue">The pattern to compare: *=any characters, ?=a character, #=a digit, etc.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static bool Like(this string str, string patternValue, StringComparison comparisonType = UseCase)
        {
            int Index = 0;
            string Ch = "";
            string regexPattern = "";

            // Escape parens
            patternValue = patternValue.Replace("(", @"\(");
            patternValue = patternValue.Replace(")", @"\)");

            // Convert Pattern from a like operand to a regular expression
            while (Index < patternValue.Length)
            {
                Ch = patternValue.Substring(Index, 1);

                // Ignore escaped literals
                if (Ch == "[")
                {
                    while (Ch != "]" & Index <= patternValue.Length)
                    {
                        regexPattern += Ch;
                        Index += 1;
                        Ch = patternValue.Substring(Index, 1);
                    }
                }

                // Convert wildcards
                switch (Ch)
                {
                    case "*":
                    case "%":
                        regexPattern += "(.|\n)*";
                        break;
                    case "?":
                    case "_":
                        regexPattern += ".{1}";
                        break;
                    case "#":
                        regexPattern += "[\\d]+";
                        break;
                    default:
                        regexPattern += Ch;
                        break;
                }
                Index += 1;
            }

            // Convert character exclusion syntax
            regexPattern = regexPattern.Replace("[!", "[^");
            if (comparisonType.ToRegEx() == RegexOptions.IgnoreCase) regexPattern = "(?i)" + regexPattern;

            MatchCollection Matches = Regex.Matches(str, regexPattern, RegexOptions.Multiline & comparisonType.ToRegEx());
            if (Matches.Count > 0)
            {
                return (Matches[0].Value.Equals(str, comparisonType));
            }
            return false;
        }
        /// <summary>
        /// Checks if a string matches any of a list of patterns
        /// </summary>
        /// <param name="str"></param>
        /// <param name="patternValues">The list of patterns to check</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static bool Like(this string str, IEnumerable<string> patternValues, StringComparison comparisonType = UseCase)
        {
            foreach (string Entry in patternValues)
            {
                if (str.Like(Entry, comparisonType))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a new string with all occurrences of a specified substring replaced 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="oldValue">The string to be replaced</param>
        /// <param name="newValue">The string to replace all occurances of oldValue</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static string Replace(this string str, string oldValue, string newValue, StringComparison comparisonType = UseCase)
        {
            if (oldValue.In(new string[] { "\\" })) return str.Replace(oldValue, newValue);
            return Regex.Replace(str, Regex.Escape(oldValue), newValue, comparisonType.ToRegEx());
        }

        /// <summary>
        /// Returns a string array of substrings of this instance that are delimited by any of the specified strings
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Values"></param>
        /// <param name="comparisonType"></param>
        /// <returns></returns>
        public static string[] Split(this string str, IEnumerable<string> Values, StringComparison comparisonType = UseCase)
        {
            string foundSeparator = null;
            int startIndex = -1;
            int endIndex = -1;
            List<string> Result = new List<string>();

            startIndex = IndexOf(str, Values, 0, comparisonType, out foundSeparator);
            if (startIndex > -1)
            {
                Result.Add(str.Substring(0, startIndex));

                startIndex += foundSeparator.Length;
                endIndex = IndexOf(str, Values, startIndex, comparisonType);
                while (endIndex > -1)
                {
                    Result.Add(str.Substring(startIndex, endIndex - startIndex));

                    startIndex = IndexOf(str, Values, startIndex, comparisonType, out foundSeparator);
                    startIndex += foundSeparator.Length;
                    endIndex = IndexOf(str, Values, startIndex, comparisonType);
                }
                Result.Add(str.Substring(startIndex, str.Length - startIndex));
            }
            else
            {
                Result.Add(str);
            }
            return Result.ToArray();
        }

        /// <summary>
        /// Retrieves a substring of this instance starting at the first occurrence of the specified value.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <example>
        /// "|A|B(C)|D(E(F))".Substring("(", ")") == "C)|D(E(F)"
        /// </example>
        /// <param name="str"></param>
        /// <param name="Value">The substring to search for</param>
        /// <param name="Length">Length of the substring returned</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static string Substring(this string str, string Value, int Length = -1, StringComparison comparisonType = UseCase)
        {
            return Substring(str, new string[] { Value }, Length, comparisonType);
        }
        /// <summary>
        /// Retrieves a substring of this instance starting at the first occurrence of any of the specified values.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Values">The list of substrings to search for</param>
        /// <param name="Length">Length of the substring returned</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static string Substring(this string str, IEnumerable<string> Values, int Length = -1, StringComparison comparisonType = UseCase)
        {
            string Value = null;
            int Index = IndexOf(str, Values, 0, comparisonType, out Value);

            if (Index == -1) return null;

            return str.Substring(Index, Length != -1 ? Length : str.Length - Index);
        }

        #region Left / Right / Mid()

        /// <summary>
        /// Returns a substring from the left of this instance; supports negative indexing: "ABC".Left(-1) == "AB"
        /// </summary>
        /// <remarks>
        /// Support
        ///     Negative indexing
        ///     Implicit IndexOf()
        ///         with case-insensitivity
        ///         with multiple values
        ///     
        /// Examples:
        /// S = "ABCDEFGHIJ"
        /// S.Left(3) == "ABC"
        /// S.Left(-3) == "ABCDEFG" 
        /// S.Left("G") == "ABCDEF"
        /// S.Left(new[] { "G", "E", "C" }) == "AB"
        /// </remarks>
        /// <param name="str"></param>
        /// <param name="Length">Length of substring returned, or removed from the string if negative</param>
        /// <returns></returns>
        public static string Left(this string str, int Length)
        {
            // Nothing to return?
            if (str.Length == 0 | Length == 0)
            {
                return "";
            }
            // Negative length?
            if (Length < 0 & (str.Length + Length >= 0))
            {
                return str.Substring(0, str.Length + Length);
            }
            // Native implementation
            if (Length > 0)
            {
                return str.Substring(0, Length <= str.Length ? Length : str.Length);
            }
            return str;
        }
        /// <summary>
        /// Returns a substring from the left of this instance up to the specified substring
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Value">The substring to search for</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static string Left(this string str, string Value, StringComparison comparisonType = UseCase)
        {
            int Index = str.IndexOf(Value, comparisonType);
            return Index > -1 ? str.Left(Index) : null;
        }
        /// <summary>
        /// Returns a substring from the left of this instance up to the first occurrence of any of the specified substrings
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Values">The list of substrings to search for</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static string Left(this string str, IEnumerable<string> Values, StringComparison comparisonType = UseCase)
        {
            int Index = str.IndexOf(Values, 0, comparisonType);
            return Index > -1 ? str.Left(Index) : null;
        }

        /// <summary>
        /// Returns a substring from the right of this instance; supports negative indexing: "ABC".Right(-1) == "BC"
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Length">Length of substring returned, or removed from the string if negative</param>
        /// <returns></returns>
        public static string Right(this string str, int Length)
        {
            if (str.Length == 0)
            {
                return "";
            }
            if (Length < 0 & (str.Length + Length >= 0))
            {
                return str.Substring(Math.Abs(Length));
            }
            if (Length > 0)
            {
                return str.Substring(str.Length - (Length <= str.Length ? Length : str.Length));
            }
            return str;
        }
        /// <summary>
        /// Returns a substring from the right of this instance up to the last occurrence specified substring
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Value">The substring to search for</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static string Right(this string str, string Value, StringComparison comparisonType = UseCase)
        {
            int Index = str.LastIndexOf(Value, comparisonType);
            return Index > -1 ? str.Right((Index + Value.Length) * -1) : null;
        }
        /// <summary>
        /// Returns a substring from the right of this instance up to the last occurrence of any of the specified substrings
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Values">The list of substrings to search for</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static string Right(this string str, IEnumerable<string> Values, StringComparison comparisonType = UseCase)
        {
            string Value = null;
            int Index = LastIndexOf(str, Values, str.Length, comparisonType, out Value);

            return Index > -1 ? str.Right((Index + Value.Length) * -1) : null;
        }

        /// <summary>
        /// Returns a substring of this instance; supports negative indexing: "ABC".Mid(+1, -1) == "B"
        /// </summary>
        /// <remarks>
        /// Returns null rather than throwing an error when indexing out of bounds
        /// </remarks>
        /// <param name="str"></param>
        /// <param name="startIndex">Starting position of the substring, from the right if negative</param>
        /// <param name="endIndex">Length of substring returned to the right of startIndex, or to the left if negative</param>
        /// <returns></returns>
        public static string Mid(this string str, int startIndex, int endIndex)
        {
            if (startIndex < 0) startIndex += str.Length;
            if (endIndex < 0) endIndex = str.Length + endIndex;
            if (endIndex > str.Length) endIndex = str.Length;

            if (startIndex == endIndex | startIndex == str.Length) return "";
            if (startIndex > endIndex | startIndex > str.Length) return null;

            //if (endIndex < 0)
            //{
            //    startIndex += endIndex;
            //    endIndex = Math.Abs(endIndex);
            //}
            //if (startIndex + endIndex > str.Length) endIndex = str.Length - startIndex;

            return str.Substring(startIndex, endIndex - startIndex);
        }
        /// <summary>
        /// Returns a substring from this instance starting at the first occurrence of startValue and ending at the last occurrence of endValue
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startValue">The left-bounding substring to search for</param>
        /// <param name="endValue">The right-bounding substring to search for</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static string Mid(this string str, string startValue, string endValue = null, StringComparison comparisonType = UseCase)
        {
            return Mid(str, new string[] { startValue }, endValue != null ? new string[] { endValue } : null, comparisonType);
        }
        /// <summary>
        /// Returns a substring from this instance starting at the first occurrence of any startValue and ending at the last occurrence of any endValue
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startValue">The left-bounding substrings to search for</param>
        /// <param name="endValue">The right-bounding substrings to search for</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
        /// <returns></returns>
        public static string Mid(this string str, IEnumerable<string> startValues, IEnumerable<string> endValues = null, StringComparison comparisonType = UseCase)
        {
            string startValue = null;
            string endValue = null;
            int startIndex = IndexOf(str, startValues, 0, comparisonType, out startValue);
            endValues = endValues ?? startValues;
            int endIndex = LastIndexOf(str, endValues, str.Length, comparisonType, out endValue);

            if (endValues == null) endIndex = str.Length;

            if (startIndex == -1 || endIndex == -1) return null;

            startIndex += startValue.Length;
            return Mid(str, startIndex, endIndex);
        }

        #endregion

        #endregion Extensions

        #region StringBuilder Extensions

        public static bool Contains(this StringBuilder sb, string str, StringComparison comparisonType = UseCase)
        { return sb.ToString().Contains(str, UseCase); }

        public static string Left(this StringBuilder sb, int value)
        { return sb.ToString().Left(value); }

        public static string Right(this StringBuilder sb, int value)
        { return sb.ToString().Right(value); }

        public static bool StartsWith(this StringBuilder sb, string value)
        { return sb.ToString().StartsWith(value); }

        public static bool EndsWith(this StringBuilder sb, string value)
        { return sb.ToString().EndsWith(value); }

        public static bool gtr(this StringBuilder sb, string value)
        { return sb.ToString().gtr(value); }

        public static string Trim(this StringBuilder sb)
        { return sb.ToString().Trim(); }

        #endregion

    } // Str

    public static class Time
    {
        public enum ElapsedUnit 
        {
            Year,
            Week,
            Day,
            Hour,
            Minute,
            Second,
            Millisecond
        }

        /// <summary>
        /// Returns an elapsed time interval in natural English
        /// </summary>
        /// <param name="unit">One of the enumeration values that specifies the granularity of the result</param>
        /// <param name="elapsedMilliseconds">The elapsed time in seconds</param>
        /// <returns></returns>
        public static string Elapsed(ElapsedUnit unit, TimeSpan timespan)
        {
            string Result = "";
            ulong Buffer;
            ulong elapsedSeconds = (ulong)timespan.TotalMilliseconds / 1000;
            ulong elapsedMilliseconds = (ulong)timespan.TotalMilliseconds % 1000;

            // Year
            if (elapsedSeconds >= (52 * 7 * 24 * 60 * 60) | unit == ElapsedUnit.Year)
            {
                Buffer = (ulong)Math.Truncate((double)(elapsedSeconds / (52 * 7 * 24 * 60 * 60)));
                Result += Buffer + " year" + (Buffer != 1 ? "s " : " ");
                elapsedSeconds = elapsedSeconds % (52 * 7 * 24 * 60 * 60);
            }
            if (unit == ElapsedUnit.Year)
                return Result.Trim();

            // Week
            if (elapsedSeconds >= (7 * 24 * 60 * 60) | unit == ElapsedUnit.Week)
            {
                Buffer = (ulong)Math.Truncate((double)(elapsedSeconds / (7 * 24 * 60 * 60)));
                Result += Buffer + " week" + (Buffer != 1 ? "s " : " ");
                elapsedSeconds = elapsedSeconds % (7 * 24 * 60 * 60);
            }
            if (unit == ElapsedUnit.Week)
                return Result.Trim();

            // Day
            if (elapsedSeconds >= (24 * 60 * 60) | unit == ElapsedUnit.Day)
            {
                Buffer = (ulong)Math.Truncate((double)(elapsedSeconds / (24 * 60 * 60)));
                Result += Buffer + " day" + (Buffer != 1 ? "s " : " ");
                elapsedSeconds = elapsedSeconds % (24 * 60 * 60);
            }
            if (unit == ElapsedUnit.Day)
                return Result.Trim();

            // Hour
            if (elapsedSeconds >= (60 * 60) | unit == ElapsedUnit.Hour)
            {
                Buffer = (UInt64)Math.Truncate((double)(elapsedSeconds / (60 * 60)));
                Result += Buffer + " hour" + (Buffer != 1 ? "s " : " ");
                elapsedSeconds = elapsedSeconds % (60 * 60);
            }
            if (unit == ElapsedUnit.Hour)
                return Result.Trim();

            // Minute
            if (elapsedSeconds >= 60 | unit == ElapsedUnit.Minute)
            {
                Buffer = (ulong)Math.Truncate((double)(elapsedSeconds / 60));
                Result += Buffer + " minute" + (Buffer != 1 ? "s " : " ");
                elapsedSeconds = elapsedSeconds % 60;
            }
            if (unit == ElapsedUnit.Minute)
                return Result.Trim();

            // Second
            if (elapsedSeconds > 0 | unit == ElapsedUnit.Second)
                Result += elapsedSeconds + " second" + (elapsedSeconds != 1 ? "s " : " ");
            if (unit == ElapsedUnit.Second)
                return Result.Trim();

            // Millisecond
            Result = Result += elapsedMilliseconds + " millisecond" + (elapsedSeconds != 1 ? "s" : "");

            return Result;
        }

    } // Time

    public static class KVP
    {
        public class List
        {
            private readonly string list = null;

            internal List(string value)
            {
                list = (value ?? "").ToLower();
                while (list.Contains(new string[] { " =", "= " }))
                    list = list.Replace(" =", "=").Replace("= ", "=");
            }

            internal bool GetBoolean(string value, Boolean? defaultValue = null)
            {
                value = value.ToLower();
                if (list.Contains(value))
                    return list.Contains($"{value}=true");
                else
                    return defaultValue ?? false;
            }
        }
    } // KVP
}
