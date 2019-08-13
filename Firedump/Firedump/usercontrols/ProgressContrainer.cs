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
    public partial class ProgressContrainer : UserControl
    {
        int heigth = 0;
        int pos = 0;

        public ProgressContrainer()
        {
            InitializeComponent();
        }

        public void add(object tag)
        {
           
                firedumpdbDataSet.backup_locationsRow row = (firedumpdbDataSet.backup_locationsRow)tag;
                ProgressItemLoc progItemloc = new ProgressItemLoc();
                progItemloc.Tag = tag;
                progItemloc.initProgressBar();
                progItemloc.setLabelText(row.name);
                progItemloc.Pos = pos;
                progItemloc.Location = new Point(0, heigth);
                heigth += 30;
                pos++;
                panel1.Controls.Add(progItemloc);
                  
        }

        public void updateProgress(int progress,string locationName)
        {
            for(int i =0; i < panel1.Controls.Count; i++)
            {
                if(panel1.Controls[i] is ProgressItemLoc)
                {
                    ProgressItemLoc loc = (ProgressItemLoc)panel1.Controls[i];
                    firedumpdbDataSet.backup_locationsRow row = (firedumpdbDataSet.backup_locationsRow)loc.Tag;
                    if(row.name == locationName)
                    {
                        ((ProgressItemLoc)panel1.Controls[i]).updateProgress(progress);
                    }
                }
            }
        }
    }
}
