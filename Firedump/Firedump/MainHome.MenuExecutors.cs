using Firedump.models.db;
using Firedump.usercontrols;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump
{
    // This Partial Class Consists most of the menu click events.
    // And the purpose its just to clear down the boilerplate code form MainHome class
    public partial class MainHome
    {
        private bool findTextBoxInputChange = false;

        private Editor GetEditor()
        {
            foreach (UserControlReference c in ChildControls)
                if (c is Editor)
                    return (c as Editor);
            return null;
        }


        private void reconnectEventClick(object sender, EventArgs e)
        {
            if (this.server != null)
            {
                if (this.con != null)
                {
                    this.con.Close();
                }
                onDisconnected(null, null);
                setConstrolEnableStatus(false);
                this.ConnectToDbClick(null, null);
            }
        }

        private void Undo(object sender, EventArgs e)
        {
            GetEditor().Undo();
        }

        private void Redo(object sender, EventArgs e)
        {
            GetEditor().Redo();
        }

        private void PrettifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetEditor().formatSelectedTab();
        }

        private void CommitBtnEventClick(object sender, EventArgs e)
        {
            if (this.isConnected(this.con))
            {
                DB.Commit(this.con);
            }
        }

        private void RollbackBtnEventClick(object sender, EventArgs e)
        {
            if (isConnected(this.con))
            {
                DB.Rollback(this.con);
            }
        }

        private void addNewQueryTab(object sender, EventArgs e)
        {
            GetEditor().AddQueryTab();
        }

       

        // Closes selected open tab
        private void closeTabClick(object sender, EventArgs e)
        {
            GetEditor().CloseSelectedTab();
        }

        private void OnSearchBoxEnterKey(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == '\r')
            {
                this.handleFindClickEvent(this.toolStripTextBoxSearch.Text, this.findTextBoxInputChange, true);
                this.findTextBoxInputChange = false;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else
            {
                this.findTextBoxInputChange = true;
            }
        }

        private void FindNextClick(object sender, EventArgs e)
        {
            this.handleFindClickEvent(this.toolStripTextBoxSearch.Text, this.findTextBoxInputChange, true);
            this.findTextBoxInputChange = false;
        }

        private void FindPrevClick(object sender, EventArgs e)
        {
            this.handleFindClickEvent(this.toolStripTextBoxSearch.Text, this.findTextBoxInputChange, false);
            this.findTextBoxInputChange = false;
        }

        private void OnSearchClick(object sender, EventArgs e)
        {
            GetEditor().ShowFindDialog();
        }

        private void OnGoToLineClick(object sender, EventArgs e)
        {
            GetEditor().ShowGoToLineDialog();
        }

        private void OnReplaceClick(object sender, EventArgs e)
        {
            GetEditor().ShowReplaceDialog();
        }

        private void handleFindClickEvent(string text, bool hasChanged, bool isNext)
        {
            GetEditor().FindText(text, hasChanged, isNext);
        }

        private void ToUpperClick(object sender,EventArgs e)
        {
            GetEditor().ToUpper();
        }

        private void ToLowerClick(object sender, EventArgs e)
        {
            GetEditor().ToLower();
        }

        private void ExportHtmlClick(object sender, EventArgs e)
        {
            GetEditor().ExportHtml();
        }

        private void PrintSelected(object sender, EventArgs e)
        {
            GetEditor().PrintSelected();
        }

        private void ExecuteScript(object sender,EventArgs e)
        {
            GetEditor().ExecuteScript();
        }
    }
}
