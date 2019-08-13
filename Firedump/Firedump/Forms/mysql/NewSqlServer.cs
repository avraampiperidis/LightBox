using Firedump.models.databaseUtils;
using Firedump.models.db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.mysql
{
    public partial class NewSqlServer : Form
    {
        public delegate void reloadserverdata(int id);
        public event reloadserverdata ReloadServerData;
        private void onReloadServerData(int id)
        {
            ReloadServerData?.Invoke(id);
        }

        //private DbConnection con = new DbConnection();
        private bool isUpdate = false;
        private firedumpdbDataSet.sql_serversRow mysqlserver; 

        public NewSqlServer()
        {
            InitializeComponent();           
        }

        public NewSqlServer(bool update,firedumpdbDataSet.sql_serversRow server)
        {
            InitializeComponent();
            bSave.Text = "Update";
            this.isUpdate = update;
            this.mysqlserver = server;
            tbName.Text = server.name;
            tbHost.Text = server.host;
            if (server.port != 0)
                tbPort.Text = server.port.ToString();
            tbUsername.Text = server.username;
            tbPassword.Text = server.password;
            tbDatabase.Text = server.database;

        }

        

        private void bTestConnection_Click(object sender, EventArgs e)
        {           
            if (!performChecks())
            {
                return;
            }
            this.UseWaitCursor = true;
            //test connection
            ConnectionResultSet result = DB.TestConnection(createMySqlServerInfoCreds(), tbDatabase.Text);
            if (result.wasSuccessful)
            {
                this.UseWaitCursor = false;
                MessageBox.Show("Connection Successful", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.UseWaitCursor = false;
                MessageBox.Show("Connection failed: \n"+result.errorMessage, "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private sqlservers createMySqlServerInfoCreds()
        {
            if (!this.performChecks()) return null;
            sqlservers s = new sqlservers();
            s.port = int.Parse(tbPort.Text);
            s.host = tbHost.Text;
            s.username = tbUsername.Text;
            s.password = tbPassword.Text;
            return s;
        }

        private Boolean performChecks()
        {
            //port
            if (!string.IsNullOrEmpty(tbPort.Text))
            {
                try
                {
                    int port = int.Parse(tbPort.Text);
                    if (port < 1 || port > 65535)
                    {
                        MessageBox.Show(tbPort.Text + " is not a valid port number", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    //con.port = port;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(tbPort.Text + " is not a valid port number", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            //host
            if (!string.IsNullOrEmpty(tbHost.Text))
            {
                //con.Host = tbHost.Text;
            }
            else
            {
                MessageBox.Show("Hostname is empty.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //username
            if (!string.IsNullOrEmpty(tbUsername.Text))
            {
                //con.username = tbUsername.Text;
            }
            else
            {
                MessageBox.Show("Username is empty.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //password
            if (!string.IsNullOrEmpty(tbPassword.Text))
            {
                //con.password = tbPassword.Text;
            }
            //database
            if (!string.IsNullOrEmpty(tbDatabase.Text))
            {
                //con.database = tbDatabase.Text;
            }

            return true;
        }
        

        private void bSave_Click(object sender, EventArgs e)
        {
            firedumpdbDataSetTableAdapters.sql_serversTableAdapter adapter = new firedumpdbDataSetTableAdapters.sql_serversTableAdapter();
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Type a name for the new server", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((Int64)adapter.numberOfOccurances(tbName.Text) == 0 || isUpdate)
            {
                if(!performChecks())
                {
                    return;
                }
                sqlservers server = createMySqlServerInfoCreds();
                if (isUpdate)
                    adapter.UpdateMySqlServerById(tbName.Text, server.port, server.host, server.username, server.password, tbDatabase.Text, mysqlserver.id);
                else
                    adapter.InsertQuery(tbName.Text, server.port, server.host, server.username, server.password, tbDatabase.Text,0); //prepei na bei kai 
                //adapter.Insert(tbName.Text, server.port, server.host, server.username, server.password, tbDatabase.Text); //prepei na bei kai database
                int id = Convert.ToInt32((Int64)adapter.GetIdByName(tbName.Text));
                onReloadServerData(id);
                this.Close();
                return;
            }


            MessageBox.Show("Name "+tbName.Text+ " already exists", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            tbUsername.Text = "";
            tbPassword.Text = "";
            tbHost.Text = "";
            tbName.Text = "";
            tbDatabase.Text = "";
            isUpdate = false;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
