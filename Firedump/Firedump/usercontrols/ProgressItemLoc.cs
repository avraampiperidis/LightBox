using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.usercontrols
{
    public partial class ProgressItemLoc : UserControl
    {

        public object Tag { get; set; }
        public int Pos { get; set; }

        public ProgressItemLoc()
        {
            InitializeComponent();
        }

        public void setLabelText(string val)
        {
            //label1.Invoke((MethodInvoker)delegate ()
            //{
                label1.Text = val;
           // });           
        }

        public void initProgressBar()
        {
           // progressBar1.Invoke((MethodInvoker)delegate ()
            //{
                progressBar1.Maximum = 100;
                progressBar1.Step = 1;
           // });
           
        }

        public void updateProgress(int progress)
        {
           // progressBar1.Invoke((MethodInvoker)delegate ()
           // {
                progressBar1.Value = progress;
           // });           
        }

    }
}
