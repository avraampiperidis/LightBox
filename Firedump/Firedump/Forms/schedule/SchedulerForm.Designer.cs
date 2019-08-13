namespace Firedump.Forms.schedule
{
    partial class SchedulerForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewlocs = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.bnewjob = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.activated = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bapplychanges = new System.Windows.Forms.Button();
            this.schedulesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.firedumpdbDataSet = new Firedump.firedumpdbDataSet();
            this.schedulesTableAdapter = new Firedump.firedumpdbDataSetTableAdapters.schedulesTableAdapter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.emailScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceManager1 = new Firedump.usercontrols.ServiceManager();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewlocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firedumpdbDataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.serviceManager1);
            this.groupBox1.Location = new System.Drawing.Point(479, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 240);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service Manager";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewlocs);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.bnewjob);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 510);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Schedules-Jobs";
            // 
            // dataGridViewlocs
            // 
            this.dataGridViewlocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewlocs.Location = new System.Drawing.Point(6, 395);
            this.dataGridViewlocs.Name = "dataGridViewlocs";
            this.dataGridViewlocs.Size = new System.Drawing.Size(449, 109);
            this.dataGridViewlocs.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "New MySqlServer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.newmysqlserver_click);
            // 
            // bnewjob
            // 
            this.bnewjob.Location = new System.Drawing.Point(6, 23);
            this.bnewjob.Name = "bnewjob";
            this.bnewjob.Size = new System.Drawing.Size(75, 23);
            this.bnewjob.TabIndex = 6;
            this.bnewjob.Text = "Add Job";
            this.bnewjob.UseVisualStyleBackColor = true;
            this.bnewjob.Click += new System.EventHandler(this.newJobClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.activated,
            this.delete});
            this.dataGridView1.Location = new System.Drawing.Point(6, 52);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(449, 337);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // activated
            // 
            this.activated.HeaderText = "activated";
            this.activated.Name = "activated";
            // 
            // delete
            // 
            this.delete.HeaderText = "delete";
            this.delete.Name = "delete";
            this.delete.Text = "delete";
            // 
            // bapplychanges
            // 
            this.bapplychanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bapplychanges.Location = new System.Drawing.Point(479, 500);
            this.bapplychanges.Name = "bapplychanges";
            this.bapplychanges.Size = new System.Drawing.Size(109, 37);
            this.bapplychanges.TabIndex = 3;
            this.bapplychanges.Text = "Apply Changes";
            this.bapplychanges.UseVisualStyleBackColor = true;
            this.bapplychanges.Click += new System.EventHandler(this.applychangesClick);
            // 
            // schedulesBindingSource
            // 
            this.schedulesBindingSource.DataMember = "schedules";
            this.schedulesBindingSource.DataSource = this.firedumpdbDataSet;
            // 
            // firedumpdbDataSet
            // 
            this.firedumpdbDataSet.DataSetName = "firedumpdbDataSet";
            this.firedumpdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // schedulesTableAdapter
            // 
            this.schedulesTableAdapter.ClearBeforeFill = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailScheduleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(847, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // emailScheduleToolStripMenuItem
            // 
            this.emailScheduleToolStripMenuItem.Name = "emailScheduleToolStripMenuItem";
            this.emailScheduleToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.emailScheduleToolStripMenuItem.Text = "Email Schedule";
            this.emailScheduleToolStripMenuItem.Click += new System.EventHandler(this.emailScheduleToolStripMenuItem_Click);
            // 
            // serviceManager1
            // 
            this.serviceManager1.Location = new System.Drawing.Point(6, 19);
            this.serviceManager1.Name = "serviceManager1";
            this.serviceManager1.Size = new System.Drawing.Size(356, 197);
            this.serviceManager1.TabIndex = 0;
            // 
            // SchedulerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 549);
            this.Controls.Add(this.bapplychanges);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SchedulerForm";
            this.Text = "SchedulerForm";
            this.Load += new System.EventHandler(this.SchedulerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewlocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firedumpdbDataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private usercontrols.ServiceManager serviceManager1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bapplychanges;
        private System.Windows.Forms.DataGridView dataGridView1;
        private firedumpdbDataSet firedumpdbDataSet;
        private System.Windows.Forms.BindingSource schedulesBindingSource;
        private firedumpdbDataSetTableAdapters.schedulesTableAdapter schedulesTableAdapter;
        private System.Windows.Forms.Button bnewjob;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activated;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem emailScheduleToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewlocs;
    }
}