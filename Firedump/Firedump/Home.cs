using Firedump.models.databaseUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Firedump.Forms.mysql;
using Firedump.models.db;
using Firedump.models.dbUtils;
using MySql.Data.MySqlClient;

namespace Firedump
{
    public partial class Home : Form
    {


        private firedumpdbDataSet.sql_serversDataTable serverData;
        private firedumpdbDataSetTableAdapters.sql_serversTableAdapter sql_server_adapter;
        private List<firedumpdbDataSet.backup_locationsRow> backuplocations;
        private bool hideSystemDatabases = true;
        
        public Home()
        {
            InitializeComponent();       
            sql_server_adapter = new firedumpdbDataSetTableAdapters.sql_serversTableAdapter();
        }


        private void bAddServer_Click(object sender, EventArgs e)
        {
            NewSqlServer newMysqlServer = new NewSqlServer();
            newMysqlServer.ReloadServerData += reloadserverData;
            newMysqlServer.ShowDialog();
        }

        private void loadServerData()
        {
            serverData = new firedumpdbDataSet.sql_serversDataTable();
            sql_server_adapter.Fill(serverData);
            cmbServers.DataSource = serverData;           
            cmbServers.DisplayMember = "name";
            cmbServers.ValueMember = "id";
            if(cmbServers.Items.Count > 0)
            {
                cmbServers.SelectedIndex = 0;
            }
        }

        private void fillTreeView()
        {
           
            if (cmbServers.Items.Count == 0) { return; } //ama den iparxei kanenas server den to kanei
            sqlservers server = null;
            this.Invoke((MethodInvoker)delegate ()
            {
                server = DbUtils.getSqlServerFromTable(serverData,cmbServers);
            });

            //edw prepei na bei to database kai mia if then else apo katw analoga ama kanei OldMySqlConnect se server i se database
            ConnectionResultSet result = DB.TestConnection(server);
            if (result.wasSuccessful)
            {
                MySqlConnection con = (MySqlConnection)DB.connect(server);
                List<string> databases = DbUtils.getDatabases(server, con);//con.getDatabases();
                if (hideSystemDatabases)
                {
                    databases = DbUtils.removeSystemDatabases(databases);
                }              
                foreach (string database in databases)
                {
                    this.Invoke((MethodInvoker)delegate () {
                        TreeNode node = new TreeNode(database);
                        node.ImageIndex = 0;
                        List<string> tables = DbUtils.getTables(server, database,con);
                        foreach (string table in tables)
                        {
                            TreeNode tablenode = new TreeNode(table);
                            tablenode.ImageIndex = 1;
                            node.Nodes.Add(tablenode);
                        }
                        tvDatabases.Nodes.Add(node);
                    });                   
                }
                DB.close(con);
            }
            else
            {
                this.Invoke((MethodInvoker)delegate () {
                    MessageBox.Show("Connection failed: \n" + result.errorMessage, "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
        }


       

        private void Home_Load(object sender, EventArgs e)
        {
            loadServerData();

            ImageList imagelist = new ImageList();
            imagelist.Images.Add(Bitmap.FromFile("resources\\icons\\databaseimage.bmp"));
            imagelist.Images.Add(Bitmap.FromFile("resources\\icons\\tableimage.bmp"));
            tvDatabases.ImageList = imagelist;

            imagelist = new ImageList();
            imagelist.Images.Add(Bitmap.FromFile("resources\\icons\\thispc.bmp"));
            imagelist.Images.Add(Bitmap.FromFile("resources\\icons\\ftpimage.bmp"));
            imagelist.Images.Add(Bitmap.FromFile("resources\\icons\\dropboximage.bmp"));
            imagelist.Images.Add(Bitmap.FromFile("resources\\icons\\googledriveicon.bmp"));
            
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += treeview_work;
            backgroundWorker1.RunWorkerAsync();           
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (cmbServers.Items.Count == 0)
            {
                MessageBox.Show("There are no servers to delete","Server Delete",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to delete server: " + ((DataRowView)cmbServers.Items[cmbServers.SelectedIndex])["name"], "Server Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                serverData.Rows[cmbServers.SelectedIndex].Delete();
                sql_server_adapter.Update(serverData); //fernei to table sto database stin katastasi tou datatable
                cmbServers_SelectionChangeCommitted(null,null);
            }
        }


        private void tvDatabases_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //an kapio child ginei checked na ginei kai o parent
            //an ginei unchecked kai to telefteo pedi na ginei unchecked kai o parent
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Parent != null)
                {
                    if (!e.Node.Checked)
                    {
                        bool found = false;
                        foreach (TreeNode n in e.Node.Parent.Nodes)
                        {
                            if (n.Checked)
                            {
                                e.Node.Parent.Checked = true;
                                found = true;
                                break;
                            }                           
                        }
                        if (!found)
                            e.Node.Parent.Checked = false;
                    }
                    else
                    {
                        e.Node.Parent.Checked = true;
                    }
                }
                else
                {                   
                    if(e.Node.Checked)
                    {
                        this.checkAllChildNodes(true, e.Node);
                    } else
                    {
                        this.checkAllChildNodes(false, e.Node);
                    }                   
                }
            }
               
        }

        /// <summary>
        /// Recursively checks or unchecks all child nodes of a node
        /// </summary>
        /// <param name="nodeChecked">True to check nodes or false to uncheck</param>
        /// <param name="treeNode">the starting node</param>
        private void checkAllChildNodes(bool nodeChecked, TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
            }
        }

        private void cmbServers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //edw prepei na bei elenxos ean trexei eidh to filltreeview thread kai an trexei na ginei interrupt kai destroy
            tvDatabases.Nodes.Clear();
            if(!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            
        }

        private void treeview_work(object sender, DoWorkEventArgs e)
        {
            fillTreeView();
        }


        private void btEditServer_Click(object sender, EventArgs e)
        {
            if (cmbServers.Items.Count > 0 && cmbServers.SelectedIndex >= 0)
            {
                firedumpdbDataSet.sql_serversRow server = ((firedumpdbDataSet.sql_serversDataTable)cmbServers.DataSource).ElementAt(cmbServers.SelectedIndex);
                NewSqlServer newServer = new NewSqlServer(true, server);
                newServer.ReloadServerData += reloadserverData;
                newServer.Show();
               
            }
        }

        private void reloadserverData(int id)
        {            
            sql_server_adapter.Fill(serverData);
            for(int i=0; i < serverData.Count;i++)
            {
                if(serverData[i].id == id)
                {
                    cmbServers.SelectedIndex = i;
                    cmbServers_SelectionChangeCommitted(null, null);
                    break;
                }
            }
        }


        private void cbShowSysDB_CheckedChanged(object sender, EventArgs e)
        {
            hideSystemDatabases = !cbShowSysDB.Checked;
            cmbServers_SelectionChangeCommitted(null, null); //ksanakalei to fillTreeView
        }

        private void onSaveErrorHandler(string message)
        {
            this.UseWaitCursor = false;
            MessageBox.Show("Save to locations failed:\n"+message,"Locations Save",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

    }
}
