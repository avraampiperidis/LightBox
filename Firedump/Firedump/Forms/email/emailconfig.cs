using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firedump.models.email;

namespace Firedump.Forms.email
{
    public partial class emailconfig : Form
    {
        public emailconfig()
        {
            InitializeComponent();
        }

        private void customchecked(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked )
            {
                emailform.server = "smtp.live.com";
                emailform.pass = textBox3.Text;
                emailform.from = textBox1.Text;
                emailform.port = 25;
                Close();
            }
            else 
                if(radioButton2.Checked )
            {
                emailform.from = textBox1.Text;
                emailform.server = textBox2.Text ;                
                emailform.port = Convert.ToInt16(numericUpDown1.Value);
                emailform.pass = textBox3.Text;
                Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox2.Text = "";
                groupBox3.Enabled = false;
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false ;
                groupBox3.Enabled = true;
            }


            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                
                groupBox2.Enabled = false;
                groupBox3.Enabled = true;
            }
            else
            {
                textBox2.Text = "smtp.live.com";
                groupBox2.Enabled = true;
                groupBox3.Enabled = false;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                groupBox3.Enabled = true;
              
            }
            else
            {
                groupBox3.Enabled = false;
            }
            
        }

        private void emailconfig_Load(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                textBox2.Text = "smtp.live.com";
            }
        }
    }
}
