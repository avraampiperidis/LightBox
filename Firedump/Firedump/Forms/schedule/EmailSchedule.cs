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
    public partial class EmailSchedule : Form
    {
        private firedumpdbDataSetTableAdapters.schedulesTableAdapter scheduleAdapter = new firedumpdbDataSetTableAdapters.schedulesTableAdapter();
        
        public EmailSchedule()
        {
            InitializeComponent();
            firedumpdbDataSet.schedulesDataTable scheduletable = new firedumpdbDataSet.schedulesDataTable();
            scheduleAdapter.FillOrderByDate(scheduletable);
            dataGridView1.DataSource = scheduletable;
        }


    }
}
