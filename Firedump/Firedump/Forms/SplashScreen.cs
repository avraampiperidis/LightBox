using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Firedump.Forms
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            this.CenterToScreen();
            init();      
        }

        private void init()
        {

            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            Task task = new Task(increaseProgressBar);
            task.Start();
        }

        async void increaseProgressBar()
        {
            string basestatus = "Initializing...";
            for (int i = 0; i <= progressBar1.Maximum; i++)
            {               
                this.Invoke((MethodInvoker)delegate ()
                {
                    if (i == 0)
                        lstatus.Text = basestatus;
                    if (i == 25)
                        lstatus.Text = basestatus + "Loading configuration settings...";
                    if (i == 75)
                        lstatus.Text = basestatus + "Loading UI Control...";

                    progressBar1.Value = i;
                });
                Thread.Sleep(25);
            }

            lstatus.Invoke((MethodInvoker)delegate ()
            {
                lstatus.Text = basestatus + "Done! Launching Home Form";
            });

            Thread.Sleep(100);
            //hide the splashscreen
            this.Invoke((MethodInvoker)delegate ()
            {
                this.Hide();
            });
            
            //when home closes , dispose all
            this.Invoke((MethodInvoker)delegate ()
            {
                this.Dispose();
            });            
        }


       
    }
}
