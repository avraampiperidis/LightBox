using Firedump.Forms.mysql;
using Firedump.Forms.mysql.connect;
using Firedump.models;
using Firedump.models.db;
using Firedump.models.dbUtils;
using Firedump.models.events;
using Firedump.usercontrols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace Firedump
{
    public sealed partial class MainHome : Form , IParentRef
    {
        private DbConnection con;
        private sqlservers server;
        private bool showSystemDatabases = false;

        // read only
        public List<UserControlReference> ChildControls { get; }

        public MainHome()
        {
            InitializeComponent();
            Text = "LightHouse Editor";
            ChildControls = new List<UserControlReference>();
            ChildControls.AddRange(new UserControlReference[]{dataView1,editor1,tableView1,tabView1});
            this.InitControlEvents();
            this.InitHomeEvents();
            this.openDatabaseWindow();
        }

        private void InitHomeEvents()
        {
            this.FormClosed += (sender,e) =>
            {
                // Disconnect/close connection when app closes
                try
                {
                    if (this.con != null)
                        if (isConnected(con))
                            DB.Rollback(con);
                    this.con.Close();
                }
                catch (Exception ex) { }
            };
            this.FormClosing += (sender, e) =>
            {
                // Inform user for lost un committed data if app closes
                // To improve this we can ask "Would you like to commit and close?" and we do the work(commit) and close
                if (this.isConnected(this.con) && e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = MessageBox.Show(@"Close App? Any UnCommitted changes will be lost!",
                                       Application.ProductName,
                                       MessageBoxButtons.YesNo) == DialogResult.No;
                };
            };
            this.ResizeBegin += (sender, e) => this.SuspendLayout();
            this.ResizeEnd += (sender, e) => this.ResumeLayout();
        }


        private void InitControlEvents()
        {
            foreach(UserControlReference uc in ChildControls)
            {
                uc.Disconnected += new EventHandler(onDisconnected);
                uc.ConnectionChanged += new EventHandler<ConChangedEventArgs>((sender,e) => {
                    this.con = e.con;
                    SetAutoCommit(con);
                    this.pushConnection();
                    this.setHomeConnectionStatus();
                });
                uc.Send += new EventHandler<object>((sender,e) =>
                    this.DispatchEvent((ITriplet<UserControlReference, UserControlReference, object>)
                    ((IGenericEventArgs<ITriplet<UserControlReference, UserControlReference, object>>)e).GetObject())
                );
            }
        }


        private void DataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Home().Show();
        }


        private void ManageServersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Home().ShowDialog();
        }

        private void AddNewServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSqlServer newMysqlServer = new NewSqlServer();
            newMysqlServer.ReloadServerData += (id) => { };
            newMysqlServer.ShowDialog();
        }

        private void ConnectToDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openDatabaseWindow();
        }

        private void ConnectToDbClick(object sender, EventArgs e)
        {
            if(this.server != null && !this.isConnected(this.con))
            {
                this.con = DB.connect(this.server);
                DB.SetAutoCommit(this.con, true);
                this.pushConnection();
                this.EnableDisable(true);
            } else if(!this.isConnected(this.con))
            {
                openDatabaseWindow();
            }
        }

        private void openDatabaseWindow()
        {
            var databaseConnector = new DatabaseConnect();
            databaseConnector.TopMost = true;
            databaseConnector.Show();
            this.EnableDisable(false);
            databaseConnector.onConnect += (sender,e)=>
            {
                this.con = e.con;
                SetAutoCommit(con);
                this.server = e.server;
                this.setConnectionAndServerToUserControls();
                this.setHomeConnectionStatus();
            };
            databaseConnector.FormClosed += (sender,e) => this.EnableDisable(true);
        }



        private void setHomeConnectionStatus()
        {
            this.connectionStatusStripTextbox.Text = this.server.username+"@"+ this.server.host + ":" + this.server.port+":"+this.con.Database;
        }


        private void setConnectionAndServerToUserControls()
        {
            this.pushConnection();
            this.tabView1.setServerDataToComboBox(DbUtils.removeSystemDatabases(DbUtils.getDatabases(this.server, this.con),this.showSystemDatabases));
        }

        private void pushConnection()
        {
            // notify.
            foreach (UserControlReference f in ChildControls)
            {
                f.onConnected();
            }
        }

        // Called/Event fired from child/composit components/userControls when mysqlconnection is disconnected
        private void onDisconnected(object sender, EventArgs e)
        {
            this.con = null;
            foreach (UserControlReference f in ChildControls)
            {
                f.onDisconnect();
            }
        }


        private void ShowHideSystemDbEventClick(object sender, EventArgs e)
        {
            if(this.isConnected(this.con))
            {
                this.tabView1.setServerDataToComboBox(DbUtils.removeSystemDatabases(DbUtils
                .getDatabases(this.server, this.con), this.showSystemDatabases = !this.showSystemDatabases));
            }
        }


        private void EnableDisable(bool enable)
        {
            if(enable && (isConnected(con)))
            {
                setConstrolEnableStatus(enable);
            } else if(!enable)
            {
                setConstrolEnableStatus(enable);
            }
        }

        private void setConstrolEnableStatus(bool enable)
        {
            foreach (var comp in this.ChildControls)
            {
                comp.Enabled = enable;
            }
        }

        private void SetAutoCommit(DbConnection con)
        {
            if(isConnected(con))
            {
                DB.SetAutoCommit(con,false);
            }
        }

        private bool isConnected(DbConnection c)
        {
            return  c != null && c.State == ConnectionState.Open;
        }

        private void disconnectEventClick(object sender, EventArgs e)
        {
            if(isConnected(this.con))
            {
                this.con.Close();
                onDisconnected(null,null);
                setConstrolEnableStatus(false);
            }
        }


        private void DispatchEvent(ITriplet<UserControlReference, UserControlReference, object> triplet)
        {
            foreach (UserControlReference c in ChildControls)
            {
                if (c.GetType() == triplet.TargetType())
                {                 
                    c.dataReceived(triplet);
                    break;
                }
            }
        }

        public DbConnection GetConnection()
        {
            return this.con;
        }

        public sqlservers GetServer()
        {
            return this.server;
        }
    }
}
