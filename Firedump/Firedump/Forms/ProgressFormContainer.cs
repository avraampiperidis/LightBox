using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms
{
    public partial class ProgressFormContainer : Form
    {
        public ProgressFormContainer()
        {
            InitializeComponent();           
        }


        public void addProgress(object tag)
        {
            progressContainer.add(tag);
        }

        public void updateProgress(int progress,string location)
        {
            progressContainer.updateProgress(progress,location);
        }

        private void bclose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Hide();
        }
    }
}
