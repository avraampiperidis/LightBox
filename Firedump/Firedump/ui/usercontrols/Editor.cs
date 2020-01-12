using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using Firedump.models;
using Firedump.models.events;
using Firedump.core;
using Firedump.core.db;

namespace Firedump.usercontrols
{
    public partial class Editor : UserControlReference
    {
        // One readonly list, all tabs have reference to this list!
        private readonly List<AutocompleteItem> menuItems = new List<AutocompleteItem>();
        public Editor(IParentRef parent):base(parent)
        { 
            InitializeComponent();
        }


        internal sealed override void dataReceived(ITriplet<UserControlReference, UserControlReference, object> triplet)
        {
            if (triplet.SourceType() == typeof(TableView) && triplet.DataType() == typeof(List<string>))
            {
                this.UpdateEditor((List<string>)triplet.GetData(), DbUtils.getTablesInfo(this.GetServer(),this.GetSqlConnection()));
            }
        }

        internal sealed override void onConnected()
        {
            base.onConnected();
            if(!string.IsNullOrEmpty(GetSqlConnection().Database) && this.tabControl1.Controls.Count == 0)
            {
                this.AddQueryTab();
            }
        }


        internal void AddQueryTab(string sql = "  ")
        {
            this.SuspendLayout();
            TabPageHolder myQueryTab = TabBuilder<TabControl, Editor>.With(this.tabControl1)
               .And(imageList1)
               .createQueryTab(menuItems,sql);
            tabControl1.Controls.Add(myQueryTab);
            SetEditorEvents(myQueryTab);
            this.ResumeLayout();
        }

        private void fctb_KeyDown(object sender, KeyEventArgs e)
        {
            // cntrol and space show popup
            if ((e.KeyData == (Keys.Space | Keys.Control)) && tabControl1.SelectedTab != null)
            {
                // forced show (MinFragmentLength will be ignored)
                ((TabPageHolder)tabControl1.SelectedTab).GetAutocompleteMenu().Show(true);
                e.Handled = true;
            }
        }       

        private void SetEditorEvents(TabPage queryTab) 
        {
            queryTab.Controls[0].Controls[0].KeyDown += fctb_KeyDown;
        }

        private FastColoredTextBox GetSelectedTabEditor()
        {
            if(tabControl1.SelectedTab != null)
            {
               return (FastColoredTextBox)tabControl1.SelectedTab.Controls[0].Controls[0];
            }
            return null;
        }

        private void UpdateEditor(List<string> tableList,List<Table> fields)
        {
            this.SuspendLayout();
            this.menuItems.Clear();
            this.menuItems.AddRange(AutoMenuItemBuilder.CreateTableItems(tableList));
            this.menuItems.AddRange(AutoMenuItemBuilder.CreateFieldItems(fields));
            this.menuItems.AddRange(AutoMenuItemBuilder.GetAllDbCommands());
            this.ResumeLayout();
        }

        internal void ExecuteScript()
        {
            var tb = GetSelectedTabEditor();
            if(tb != null)
            {
                string sql = tb.Text;

            }
        }
    }
}
