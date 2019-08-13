using FastColoredTextBoxNS;
using Firedump.utils.editor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.usercontrols
{
    // common events comming from menu bar buttons like undo, redo, copy,...
    // editor events and functionality that is very simple
    public partial class Editor
    {
        internal void ToLower()
        {
            var tb = GetSelectedTabEditor();
            if (tb != null)
            {
                tb.LowerCase();
            }
        }

        internal void ToUpper()
        {
            var tb = GetSelectedTabEditor();
            if (tb != null)
            {
                tb.UpperCase();
            }
        }

        internal void ShowFindDialog()
        {
            var tb = GetSelectedTabEditor();
            if (tb != null)
            {
                tb.ShowFindDialog();
            }
        }

        internal void ShowGoToLineDialog()
        {
            var tb = GetSelectedTabEditor();
            if (tb != null)
            {
                tb.ShowGoToDialog();
            }
        }

        internal void ShowReplaceDialog()
        {
            var tb = GetSelectedTabEditor();
            if (tb != null)
            {
                tb.ShowReplaceDialog();
            }
        }

        internal void PrintSelected()
        {
            var tb = GetSelectedTabEditor();
            if (tb != null)
            {
                tb.Print(new PrintDialogSettings() { ShowPrintPreviewDialog = true });
            }
        }

        internal void ExportHtml()
        {
            var tb = GetSelectedTabEditor();
            if (tb != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "HTML with <PRE> tag|*.html|HTML without <PRE> tag|*.html";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string html = "";

                    if (sfd.FilterIndex == 1)
                    {
                        html = tb.Html;
                    }
                    if (sfd.FilterIndex == 2)
                    {

                        ExportToHTML export = new ExportToHTML();
                        export.UseBr = true;
                        export.UseStyleTag = true;
                        html = export.GetHtml(tb);
                    }
                    File.WriteAllText(sfd.FileName, html);
                }
            }
        }

        internal void formatSelectedTab()
        {
            var editor = GetSelectedTabEditor();
            if (editor != null)
            {
                editor.Text = EditorUtils.FormatSql(editor.Text);
            }
        }


        internal void FindText(string text, bool hasChanged, bool isNext = true)
        {
            var tb = GetSelectedTabEditor();
            if (tb != null)
            {
                Range r = hasChanged ? tb.Range.Clone() : tb.Selection.Clone();
                r.End = new Place(tb[tb.LinesCount - 1].Count, tb.LinesCount - 1);
                var pattern = Regex.Escape(text);
                foreach (var found in r.GetRanges(pattern))
                {
                    found.Inverse();
                    tb.Selection = found;
                    tb.DoSelectionVisible();
                    return;
                }
            }
        }

        internal void CloseSelectedTab()
        {
            if (tabControl1.TabPages.Count != 1 && tabControl1.SelectedTab != null)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        internal void Undo()
        {
            var tb = GetSelectedTabEditor();
            if(tb != null)
            {
                tb.Undo();
            }
        }

        internal void Redo()
        {
            var tb = GetSelectedTabEditor();
            if(tb != null)
            {
                tb.Redo();
            }
        }
    }
}
