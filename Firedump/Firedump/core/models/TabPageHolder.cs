using FastColoredTextBoxNS;
using Firedump.core.parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.models
{
    public sealed class TabPageHolder : TabPage
    {
        private readonly AutocompleteMenu menu;

        public TabPageHolder(Panel panel,ImageList imageList, List<AutocompleteItem> menuItems) :base()
        {
            this.Controls.Add(panel);
            this.menu = EditorUtils.CreateAutoCompleteMenu(this.GetFastColoredTextBox(), imageList);
            this.menu.Items.SetAutocompleteItems(menuItems);
            this.menu.Items.MaximumSize = new System.Drawing.Size(300, 400);
            this.menu.AutoSize = true;
            this.menu.Items.AutoSize = true;
            this.menu.Items.Width = 300;
        }

        public FastColoredTextBox GetFastColoredTextBox()
        {
            return (FastColoredTextBox)this.Controls[0].Controls[0];
        }

        public AutocompleteMenu GetAutocompleteMenu()
        {
            return menu;
        }

    }
}
