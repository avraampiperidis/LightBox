using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.location
{
    public partial class FTPFileBrowser : Form
    {
        public string path { set; get; }
        private bool isFolderPicker;
        private FTPFileBrowser()
        {
            InitializeComponent();
        }
        public FTPFileBrowser(bool isFolderPicker)
        {
            InitializeComponent();
            this.isFolderPicker = isFolderPicker;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            path = tbPath.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

    }
}
