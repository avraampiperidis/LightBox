using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.schedule
{
    public partial class Logs : Form
    {
        public Logs()
        {
            InitializeComponent();
        }

        private void logsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.logsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.firedumpdbDataSet);

        }

        private void Logs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'firedumpdbDataSet.logs' table. You can move, or remove it, as needed.
            this.logsTableAdapter.Fill(this.firedumpdbDataSet.logs);

        }
    }
}
