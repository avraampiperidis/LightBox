using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.utils
{
    public class StringUtils
    {

        /// <summary>
        /// Works for both paths with \ and /
        /// </summary>
        /// <param name="path"></param>
        /// <returns>String array of size 2 where 0 is the path and 1 is the filename</returns>
        internal static string[] splitPath(string path)
        {
            string[] splitpath = new string[2];
            char splitchar = '\\';
            if (path.Contains('/'))
            {
                splitchar = '/';
            }
            string[] temp = path.Split(splitchar);
            splitpath[1] = temp[temp.Length - 1];
            splitpath[0] = "";
            for (int i = 0; i < temp.Length - 1; i++)
            {
                splitpath[0] += temp[i] + splitchar;
            }
            return splitpath;
        }


        /// <summary>
        /// The file can have many dots in the filename but it must have an extension or this is redundunt
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>The extension of the file with . (.sql)</returns>
        internal static string getExtension(string filename)
        {
            string[] temp = filename.Split('.');
            return "." + temp[temp.Length - 1];
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="path"></param>
        /// <returns> 
        /// returns the last / name
        /// eg.in /home/staff/folderOrFile
        /// out  folderOrFile
        /// </returns>
        internal static string getLastPathName(string path)
        {
            return path.Substring(path.LastIndexOf(path.Contains('/') ? '/' : '\\'));
        }


        /// <summary>
        /// example input path = /home/stuff/folderOrFile
        /// return = /home/stuff
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static string getPathExceptLast(string path)
        {
            char splitchar = path.Contains('/') ? '/' : '\\';
            return (path.Split(splitchar).Length > 2) ? path.Substring(0, path.LastIndexOf(splitchar)) : "/";
        }

        /// <summary>
        /// Counts the occurances of a char within a string
        /// </summary>
        /// <param name="thestring">The string</param>
        /// <param name="thechar">The char to search for</param>
        /// <returns></returns>
        internal static int countOccurances(string thestring, char thechar)
        {
            int occurances = 0; 
            foreach (char c in thestring)
            {
                if (c == thechar) occurances++;
            }
            return occurances;
        }

        /// <summary>
        /// Counts the occurances of a string within a string
        /// </summary>
        /// <param name="thestring">The string</param>
        /// <param name="searchstring">The string to search for within the first param</param>
        /// <returns></returns>
        internal static int countOccurances(string thestring, string searchstring)
        {
            return (thestring.Length - thestring.Replace(searchstring, "").Length) / searchstring.Length;
        }


        internal static List<string> extractTableListFromString(string tablestring)
        {
            if (String.IsNullOrEmpty(tablestring))
            {
                return new List<string>();
            }
            string[] arr = tablestring.Split('-');
            List<string> tablelist = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!String.IsNullOrEmpty(arr[i]))
                {
                    tablelist.Add(arr[i]);
                }
            }
            return tablelist;
        }



    }
}
