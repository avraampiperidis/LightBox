using FastColoredTextBoxNS;
using Firedump.models;
using Firedump.usercontrols;
using Firedump.utils.editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.control.editor
{
    // Builder Design Pattern
    public sealed class TabBuilder<C,S> where C : Control where S : UserControlReference
    {
        private C Control;
        private ImageList imageList;

        private TabBuilder()
        {
        }

        private TabBuilder(C c):this()
        {
            this.Control = c;
        }

        public  static TabBuilder<C,S> With(C control)
        {
            return new TabBuilder<C, S>(control);
        }

        public TabBuilder<C,S> And(ImageList imageList)
        {
            this.imageList = imageList;
            return this;
        }

        public TabPageHolder createQueryTab(List<AutocompleteItem> menuItems,string sql = "  ")
        {
            return build(createPanel(createFastColoredTextBox(sql)),menuItems);
        }

        private TabPageHolder build(Panel panel, List<AutocompleteItem> menuItems)
        {
            return new TabPageHolder(panel, imageList,menuItems)
            {
                Name = "tabPageQuery" + (this.Control.Controls.Count + 1),
                Text = "Tab" + (this.Control.Controls.Count + 1),
                UseVisualStyleBackColor = true,
                TabIndex = this.Control.Controls.Count,
                Location = new System.Drawing.Point(4, 22)
            }; 
        }

        private Panel createPanel(FastColoredTextBox editor)
        {
            var panel = new Panel() { Dock = DockStyle.Fill,Location = new System.Drawing.Point(3,3),
                TabIndex = this.Control.Controls.Count,Name = "panel" + (this.Control.Controls.Count + 1)
            };
            panel.Controls.Add(editor);
            return panel;
        }

        private FastColoredTextBox createFastColoredTextBox(string sql = "    ")
        {
            var fastColoredTextBox1 = new FastColoredTextBox() { BackBrush = null, CharHeight = 14, CharWidth = 8, Cursor = Cursors.IBeam,
                Dock = DockStyle.Fill, IsReplaceMode = false, Name = "fastColoredTextBox" + (this.Control.Controls.Count + 1),
                Paddings = new Padding(0), Location = new System.Drawing.Point(0, 0), Text = "    ",
                Zoom = 100,AutoScrollMinSize = new System.Drawing.Size(179, 14),TabIndex = this.Control.Controls.Count,
                DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180))))),
                SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))))
            };
            this.SetSqlOptions(fastColoredTextBox1);
            if(EditorConfig.isAutoFormatConfigOn())
            {
                sql = EditorUtils.FormatSql(sql);
            }
            fastColoredTextBox1.Text = sql;
            return fastColoredTextBox1;
        }


        public void SetSqlOptions(FastColoredTextBox fastColoredTextBox1)
        {
            fastColoredTextBox1.Language = Language.SQL;
            fastColoredTextBox1.AutoIndent = true;
        }


  

    }
}
