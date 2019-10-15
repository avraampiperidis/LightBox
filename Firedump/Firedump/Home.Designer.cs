namespace Firedump
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bAddServer = new System.Windows.Forms.Button();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.btEditServer = new System.Windows.Forms.Button();
            this.cbShowSysDB = new System.Windows.Forms.CheckBox();
            this.tvDatabases = new System.Windows.Forms.TreeView();
            this.bDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbServers = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.logsTableAdapter1 = new Firedump.firedumpdbDataSetTableAdapters.logsTableAdapter();
            this.gbConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // bAddServer
            // 
            this.bAddServer.Location = new System.Drawing.Point(6, 36);
            this.bAddServer.Name = "bAddServer";
            this.bAddServer.Size = new System.Drawing.Size(101, 23);
            this.bAddServer.TabIndex = 0;
            this.bAddServer.TabStop = false;
            this.bAddServer.Text = "Add New Server";
            this.bAddServer.UseVisualStyleBackColor = true;
            this.bAddServer.Click += new System.EventHandler(this.bAddServer_Click);
            // 
            // gbConnection
            // 
            this.gbConnection.Controls.Add(this.btEditServer);
            this.gbConnection.Controls.Add(this.cbShowSysDB);
            this.gbConnection.Controls.Add(this.tvDatabases);
            this.gbConnection.Controls.Add(this.bDelete);
            this.gbConnection.Controls.Add(this.label1);
            this.gbConnection.Controls.Add(this.cmbServers);
            this.gbConnection.Controls.Add(this.bAddServer);
            this.gbConnection.Location = new System.Drawing.Point(12, 12);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(285, 402);
            this.gbConnection.TabIndex = 2;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Connection";
            // 
            // btEditServer
            // 
            this.btEditServer.Location = new System.Drawing.Point(109, 36);
            this.btEditServer.Name = "btEditServer";
            this.btEditServer.Size = new System.Drawing.Size(75, 23);
            this.btEditServer.TabIndex = 6;
            this.btEditServer.Text = "Edit Server";
            this.btEditServer.UseVisualStyleBackColor = true;
            this.btEditServer.Click += new System.EventHandler(this.btEditServer_Click);
            // 
            // cbShowSysDB
            // 
            this.cbShowSysDB.AutoSize = true;
            this.cbShowSysDB.Location = new System.Drawing.Point(135, 13);
            this.cbShowSysDB.Name = "cbShowSysDB";
            this.cbShowSysDB.Size = new System.Drawing.Size(144, 17);
            this.cbShowSysDB.TabIndex = 5;
            this.cbShowSysDB.Text = "Show System Databases";
            this.cbShowSysDB.UseVisualStyleBackColor = true;
            this.cbShowSysDB.CheckedChanged += new System.EventHandler(this.cbShowSysDB_CheckedChanged);
            // 
            // tvDatabases
            // 
            this.tvDatabases.Location = new System.Drawing.Point(6, 92);
            this.tvDatabases.Name = "tvDatabases";
            this.tvDatabases.Size = new System.Drawing.Size(273, 299);
            this.tvDatabases.TabIndex = 4;
            this.tvDatabases.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvDatabases_AfterCheck);
            // 
            // bDelete
            // 
            this.bDelete.ForeColor = System.Drawing.Color.Red;
            this.bDelete.Location = new System.Drawing.Point(190, 36);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(89, 23);
            this.bDelete.TabIndex = 3;
            this.bDelete.Text = "Delete Server";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Not connected";
            // 
            // cmbServers
            // 
            this.cmbServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServers.FormattingEnabled = true;
            this.cmbServers.Location = new System.Drawing.Point(6, 65);
            this.cmbServers.Name = "cmbServers";
            this.cmbServers.Size = new System.Drawing.Size(273, 21);
            this.cmbServers.TabIndex = 1;
            this.cmbServers.SelectionChangeCommitted += new System.EventHandler(this.cmbServers_SelectionChangeCommitted);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.treeview_work);
            // 
            // logsTableAdapter1
            // 
            this.logsTableAdapter1.ClearBeforeFill = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 430);
            this.Controls.Add(this.gbConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Home";
            this.Text = "Firedump";
            this.Load += new System.EventHandler(this.Home_Load);
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bAddServer;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.ComboBox cmbServers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.TreeView tvDatabases;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox cbShowSysDB;
        private System.Windows.Forms.Button btEditServer;
        private firedumpdbDataSetTableAdapters.logsTableAdapter logsTableAdapter1;
    }
}