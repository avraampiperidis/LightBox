using FastColoredTextBoxNS;
using Firedump.attributes;
using Firedump.control.editor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.utils.editor
{
    internal class EditorUtils
    {
        const string REGEX = @"[\w\:=!<>]";

        internal static AutocompleteMenu CreateAutoCompleteMenu(FastColoredTextBox editor,ImageList imageList)
        {
            return CreateAutoCompleteMenu(editor, imageList, REGEX);
        }

        internal static AutocompleteMenu CreateAutoCompleteMenu(FastColoredTextBox editor, ImageList imageList,string searchPattern)
        {
            return new AutocompleteMenu(editor) { ImageList = imageList,SearchPattern = searchPattern,AppearInterval = 10,
               MinFragmentLength = 3,ForeColor = Color.Blue};
        }

        [ForTest("test success and most importantly test fail and check for sql string imutability")]
        internal static string FormatSql(string sql)
        {
            try
            {
                var formatter = new Formatter();
                formatter.Format(sql);
                if (formatter.Success)
                {
                    return formatter.LastResult;
                }
            }
            catch (MyFormatterException ex)
            {
                // Do nothing.
            }
            //Return the orignal sql
            return sql;
        }

    }
}
