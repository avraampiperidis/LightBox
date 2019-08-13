using Firedump.models.databaseUtils;
using Firedump.models.db;
using Firedump.models.email;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Firedump.Forms.email
{
    public partial class email : Form
    {
        
        public email()
        {
            InitializeComponent();
        }

        private void email_Load(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(emailform.from))
            {
                textBox1.Text = emailform.from;
            }

            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
               groupBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form1 = new emailconfig ();
            form1.Show();
        }

    }
}
