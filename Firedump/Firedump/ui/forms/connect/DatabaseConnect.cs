using Firedump.models.events;
using Firedump.core;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firedump.core.db;

namespace Firedump.Forms.mysql.connect
{
    public partial class DatabaseConnect : Form
    {
        private firedumpdbDataSet.sql_serversDataTable serverData;
        private firedumpdbDataSetTableAdapters.sql_serversTableAdapter mysql_serversAdapter;

        public event EventHandler<ConnectionEventArgs> onConnect;
        void OnConnectionChanged(object t, ConnectionEventArgs e)
        {
            onConnect?.Invoke(t, e);
        }

        public DatabaseConnect()
        {
            InitializeComponent();
            this.InitDataFormData(this,null);
        }

        private void InitDataFormData(object sender, EventArgs e)
        {
            mysql_serversAdapter = new firedumpdbDataSetTableAdapters.sql_serversTableAdapter();
            serverData = new firedumpdbDataSet.sql_serversDataTable();
            mysql_serversAdapter.Fill(serverData);
            comboBox1.DataSource = serverData;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            if(serverData.Count > 0)
            {
                var server = DbUtils.getSqlServerFromTable(serverData, comboBox1);
                if (server != null)
                {
                    if (DB.TestConnection(server).wasSuccessful)
                    {
                        var con = DB.connect(server);
                        this.OnConnectionChanged(this, new ConnectionEventArgs(con, server));
                    }
                }
                Close();
            } else
            {
                WarnNoServersSaved();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (serverData.Count > 0)
            {
                var server = DbUtils.getSqlServerFromTable(serverData, comboBox1);
                if (server != null)
                {
                    //test connection
                    ConnectionResultSet result = DB.TestConnection(server);
                    if (result.wasSuccessful)
                    {
                        this.UseWaitCursor = false;
                        MessageBox.Show("Connection Successful", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.UseWaitCursor = false;
                        MessageBox.Show("Connection failed: \n" + result.errorMessage, "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                WarnNoServersSaved();
            }
        }

        private void WarnNoServersSaved()
        {
            MessageBox.Show("No saved servers. Go to Database->Add New Server","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
