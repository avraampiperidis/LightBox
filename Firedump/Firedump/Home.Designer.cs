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
            this.bAddSaveLoc = new System.Windows.Forms.Button();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.btEditServer = new System.Windows.Forms.Button();
            this.cbShowSysDB = new System.Windows.Forms.CheckBox();
            this.tvDatabases = new System.Windows.Forms.TreeView();
            this.bDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbServers = new System.Windows.Forms.ComboBox();
            this.gbSaveLocations = new System.Windows.Forms.GroupBox();
            this.lbSaveLocations = new System.Windows.Forms.ListView();
            this.nameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pathCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bDeleteSaveLocation = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.emailscheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSQLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bStartDump = new System.Windows.Forms.Button();
            this.pbDumpExec = new System.Windows.Forms.ProgressBar();
            this.lStatusLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ltable = new System.Windows.Forms.Label();
            this.lStatus = new System.Windows.Forms.Label();
            this.bcancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bshowuploads = new System.Windows.Forms.Button();
            this.logsTableAdapter1 = new Firedump.firedumpdbDataSetTableAdapters.logsTableAdapter();
            this.gbConnection.SuspendLayout();
            this.gbSaveLocations.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // bAddSaveLoc
            // 
            this.bAddSaveLoc.Location = new System.Drawing.Point(6, 36);
            this.bAddSaveLoc.Name = "bAddSaveLoc";
            this.bAddSaveLoc.Size = new System.Drawing.Size(125, 23);
            this.bAddSaveLoc.TabIndex = 1;
            this.bAddSaveLoc.Text = "Add Save Location";
            this.bAddSaveLoc.UseVisualStyleBackColor = true;
            this.bAddSaveLoc.Click += new System.EventHandler(this.btAddDestClick);
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
            this.gbConnection.Location = new System.Drawing.Point(12, 37);
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
            this.tvDatabases.CheckBoxes = true;
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
            // gbSaveLocations
            // 
            this.gbSaveLocations.Controls.Add(this.lbSaveLocations);
            this.gbSaveLocations.Controls.Add(this.bDeleteSaveLocation);
            this.gbSaveLocations.Controls.Add(this.bAddSaveLoc);
            this.gbSaveLocations.Location = new System.Drawing.Point(327, 37);
            this.gbSaveLocations.Name = "gbSaveLocations";
            this.gbSaveLocations.Size = new System.Drawing.Size(319, 305);
            this.gbSaveLocations.TabIndex = 0;
            this.gbSaveLocations.TabStop = false;
            this.gbSaveLocations.Text = "Save Locations";
            // 
            // lbSaveLocations
            // 
            this.lbSaveLocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameCol,
            this.pathCol});
            this.lbSaveLocations.FullRowSelect = true;
            this.lbSaveLocations.GridLines = true;
            this.lbSaveLocations.Location = new System.Drawing.Point(6, 65);
            this.lbSaveLocations.Name = "lbSaveLocations";
            this.lbSaveLocations.Size = new System.Drawing.Size(307, 234);
            this.lbSaveLocations.TabIndex = 3;
            this.lbSaveLocations.UseCompatibleStateImageBehavior = false;
            this.lbSaveLocations.View = System.Windows.Forms.View.Details;
            // 
            // nameCol
            // 
            this.nameCol.Text = "Name";
            this.nameCol.Width = 120;
            // 
            // pathCol
            // 
            this.pathCol.Text = "Path";
            this.pathCol.Width = 180;
            // 
            // bDeleteSaveLocation
            // 
            this.bDeleteSaveLocation.Location = new System.Drawing.Point(173, 36);
            this.bDeleteSaveLocation.Name = "bDeleteSaveLocation";
            this.bDeleteSaveLocation.Size = new System.Drawing.Size(140, 23);
            this.bDeleteSaveLocation.TabIndex = 2;
            this.bDeleteSaveLocation.Text = "Remove Save Location(s)";
            this.bDeleteSaveLocation.UseVisualStyleBackColor = true;
            this.bDeleteSaveLocation.Click += new System.EventHandler(this.bDeleteSaveLocation_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.schedulerToolStripMenuItem,
            this.historyLogsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.newFormToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(681, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miConfiguration,
            this.emailscheduleToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // miConfiguration
            // 
            this.miConfiguration.Name = "miConfiguration";
            this.miConfiguration.Size = new System.Drawing.Size(157, 22);
            this.miConfiguration.Text = "Configuration...";
            this.miConfiguration.Click += new System.EventHandler(this.miConfiguration_Click);
            // 
            // emailscheduleToolStripMenuItem
            // 
            this.emailscheduleToolStripMenuItem.Name = "emailscheduleToolStripMenuItem";
            this.emailscheduleToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.emailscheduleToolStripMenuItem.Text = "email-schedule";
            this.emailscheduleToolStripMenuItem.Click += new System.EventHandler(this.emailsetupformclick);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importSQLFileToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // importSQLFileToolStripMenuItem
            // 
            this.importSQLFileToolStripMenuItem.Name = "importSQLFileToolStripMenuItem";
            this.importSQLFileToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.importSQLFileToolStripMenuItem.Text = "Import SQL file...";
            this.importSQLFileToolStripMenuItem.Click += new System.EventHandler(this.importSQLFileToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // schedulerToolStripMenuItem
            // 
            this.schedulerToolStripMenuItem.Name = "schedulerToolStripMenuItem";
            this.schedulerToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.schedulerToolStripMenuItem.Text = "Scheduler";
            this.schedulerToolStripMenuItem.Click += new System.EventHandler(this.schedulerToolStripMenuItem_Click);
            // 
            // historyLogsToolStripMenuItem
            // 
            this.historyLogsToolStripMenuItem.Name = "historyLogsToolStripMenuItem";
            this.historyLogsToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.historyLogsToolStripMenuItem.Text = "History-Logs";
            this.historyLogsToolStripMenuItem.Click += new System.EventHandler(this.show_logs_click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.about_form_click);
            // 
            // newFormToolStripMenuItem
            // 
            this.newFormToolStripMenuItem.Name = "newFormToolStripMenuItem";
            this.newFormToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.newFormToolStripMenuItem.Text = "NewHome";
            this.newFormToolStripMenuItem.Click += new System.EventHandler(this.NewFormToolStripMenuItem_Click);
            // 
            // bStartDump
            // 
            this.bStartDump.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bStartDump.Location = new System.Drawing.Point(303, 386);
            this.bStartDump.Name = "bStartDump";
            this.bStartDump.Size = new System.Drawing.Size(174, 53);
            this.bStartDump.TabIndex = 5;
            this.bStartDump.Text = "Start Dump";
            this.bStartDump.UseVisualStyleBackColor = true;
            this.bStartDump.Click += new System.EventHandler(this.bStartDump_Click);
            // 
            // pbDumpExec
            // 
            this.pbDumpExec.Location = new System.Drawing.Point(18, 470);
            this.pbDumpExec.Name = "pbDumpExec";
            this.pbDumpExec.Size = new System.Drawing.Size(628, 23);
            this.pbDumpExec.TabIndex = 6;
            // 
            // lStatusLabel
            // 
            this.lStatusLabel.AutoSize = true;
            this.lStatusLabel.Location = new System.Drawing.Point(20, 442);
            this.lStatusLabel.Name = "lStatusLabel";
            this.lStatusLabel.Size = new System.Drawing.Size(40, 13);
            this.lStatusLabel.TabIndex = 7;
            this.lStatusLabel.Text = "Status:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.treeview_work);
            // 
            // ltable
            // 
            this.ltable.AutoSize = true;
            this.ltable.Location = new System.Drawing.Point(303, 442);
            this.ltable.Name = "ltable";
            this.ltable.Size = new System.Drawing.Size(37, 13);
            this.ltable.TabIndex = 8;
            this.ltable.Text = "Table:";
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(63, 442);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(0, 13);
            this.lStatus.TabIndex = 9;
            // 
            // bcancel
            // 
            this.bcancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bcancel.ForeColor = System.Drawing.Color.Red;
            this.bcancel.Location = new System.Drawing.Point(571, 437);
            this.bcancel.Name = "bcancel";
            this.bcancel.Size = new System.Drawing.Size(75, 23);
            this.bcancel.TabIndex = 10;
            this.bcancel.Text = "Cancel";
            this.bcancel.UseVisualStyleBackColor = true;
            this.bcancel.Click += new System.EventHandler(this.cancelDumpClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "<-right click on database";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.location,
            this.progress,
            this.cancel});
            this.dataGridView1.Location = new System.Drawing.Point(652, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(350, 269);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // location
            // 
            this.location.HeaderText = "Location";
            this.location.Name = "location";
            // 
            // progress
            // 
            this.progress.HeaderText = "Progress";
            this.progress.Name = "progress";
            // 
            // cancel
            // 
            this.cancel.DataPropertyName = "Cancel";
            this.cancel.HeaderText = "Cancel";
            this.cancel.Name = "cancel";
            this.cancel.Text = "cancel";
            // 
            // bshowuploads
            // 
            this.bshowuploads.Location = new System.Drawing.Point(515, 345);
            this.bshowuploads.Name = "bshowuploads";
            this.bshowuploads.Size = new System.Drawing.Size(131, 23);
            this.bshowuploads.TabIndex = 13;
            this.bshowuploads.Text = "Show uploads status";
            this.bshowuploads.UseVisualStyleBackColor = true;
            this.bshowuploads.Click += new System.EventHandler(this.bshowuploads_Click);
            // 
            // logsTableAdapter1
            // 
            this.logsTableAdapter1.ClearBeforeFill = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 532);
            this.Controls.Add(this.bshowuploads);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bcancel);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.ltable);
            this.Controls.Add(this.lStatusLabel);
            this.Controls.Add(this.pbDumpExec);
            this.Controls.Add(this.bStartDump);
            this.Controls.Add(this.gbSaveLocations);
            this.Controls.Add(this.gbConnection);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "Firedump";
            this.Load += new System.EventHandler(this.Home_Load);
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.gbSaveLocations.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAddServer;
        private System.Windows.Forms.Button bAddSaveLoc;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.GroupBox gbSaveLocations;
        private System.Windows.Forms.ComboBox cmbServers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miConfiguration;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.TreeView tvDatabases;
        private System.Windows.Forms.Button bStartDump;
        private System.Windows.Forms.ProgressBar pbDumpExec;
        private System.Windows.Forms.Label lStatusLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label ltable;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Button bcancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbShowSysDB;
        private System.Windows.Forms.Button bDeleteSaveLocation;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSQLFileToolStripMenuItem;
        private System.Windows.Forms.Button btEditServer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn progress;
        private System.Windows.Forms.DataGridViewButtonColumn cancel;
        private System.Windows.Forms.ListView lbSaveLocations;
        private System.Windows.Forms.ColumnHeader nameCol;
        private System.Windows.Forms.ColumnHeader pathCol;
        private System.Windows.Forms.ToolStripMenuItem schedulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailscheduleToolStripMenuItem;
        private System.Windows.Forms.Button bshowuploads;
        private firedumpdbDataSetTableAdapters.logsTableAdapter logsTableAdapter1;
        private System.Windows.Forms.ToolStripMenuItem newFormToolStripMenuItem;
    }
}