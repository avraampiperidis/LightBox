using MySql.Data.MySqlClient;

namespace Firedump.usercontrols
{
    partial class TabView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTables = new System.Windows.Forms.TabPage();
            this.dataGridViewTables = new System.Windows.Forms.DataGridView();
            this.textBoxTable = new System.Windows.Forms.TextBox();
            this.tabPagePKs = new System.Windows.Forms.TabPage();
            this.dataGridViewPKs = new System.Windows.Forms.DataGridView();
            this.searchPKbox = new System.Windows.Forms.TextBox();
            this.tabPageUKs = new System.Windows.Forms.TabPage();
            this.dataGridViewUnique = new System.Windows.Forms.DataGridView();
            this.textBoxUK = new System.Windows.Forms.TextBox();
            this.tabPageFKs = new System.Windows.Forms.TabPage();
            this.dataGridViewFKs = new System.Windows.Forms.DataGridView();
            this.textBoxFK = new System.Windows.Forms.TextBox();
            this.tabPageIndexes = new System.Windows.Forms.TabPage();
            this.dataGridViewIndexes = new System.Windows.Forms.DataGridView();
            this.textBoxIndex = new System.Windows.Forms.TextBox();
            this.tabPageTriggers = new System.Windows.Forms.TabPage();
            this.dataGridViewTrigger = new System.Windows.Forms.DataGridView();
            this.textBoxTrigger = new System.Windows.Forms.TextBox();
            this.tabPageProcedures = new System.Windows.Forms.TabPage();
            this.dataGridViewProcedures = new System.Windows.Forms.DataGridView();
            this.textBoxProcedure = new System.Windows.Forms.TextBox();
            this.tabPageFunctions = new System.Windows.Forms.TabPage();
            this.dataGridViewFunctions = new System.Windows.Forms.DataGridView();
            this.textBoxFunction = new System.Windows.Forms.TextBox();
            this.tabPageViews = new System.Windows.Forms.TabPage();
            this.dataGridViewView = new System.Windows.Forms.DataGridView();
            this.textBoxView = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comboBoxServers = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTables)).BeginInit();
            this.tabPagePKs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPKs)).BeginInit();
            this.tabPageUKs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUnique)).BeginInit();
            this.tabPageFKs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFKs)).BeginInit();
            this.tabPageIndexes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndexes)).BeginInit();
            this.tabPageTriggers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrigger)).BeginInit();
            this.tabPageProcedures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcedures)).BeginInit();
            this.tabPageFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFunctions)).BeginInit();
            this.tabPageViews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.comboBoxServers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 574);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 553);
            this.panel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTables);
            this.tabControl1.Controls.Add(this.tabPagePKs);
            this.tabControl1.Controls.Add(this.tabPageUKs);
            this.tabControl1.Controls.Add(this.tabPageFKs);
            this.tabControl1.Controls.Add(this.tabPageIndexes);
            this.tabControl1.Controls.Add(this.tabPageTriggers);
            this.tabControl1.Controls.Add(this.tabPageProcedures);
            this.tabControl1.Controls.Add(this.tabPageFunctions);
            this.tabControl1.Controls.Add(this.tabPageViews);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(271, 553);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabPageTables
            // 
            this.tabPageTables.Controls.Add(this.dataGridViewTables);
            this.tabPageTables.Controls.Add(this.textBoxTable);
            this.tabPageTables.ImageIndex = 5;
            this.tabPageTables.Location = new System.Drawing.Point(4, 61);
            this.tabPageTables.Name = "tabPageTables";
            this.tabPageTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTables.Size = new System.Drawing.Size(263, 488);
            this.tabPageTables.TabIndex = 5;
            this.tabPageTables.Text = "Tables";
            this.tabPageTables.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTables
            // 
            this.dataGridViewTables.AllowUserToAddRows = false;
            this.dataGridViewTables.AllowUserToDeleteRows = false;
            this.dataGridViewTables.AllowUserToOrderColumns = true;
            this.dataGridViewTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTables.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewTables.Name = "dataGridViewTables";
            this.dataGridViewTables.ReadOnly = true;
            this.dataGridViewTables.RowHeadersVisible = false;
            this.dataGridViewTables.Size = new System.Drawing.Size(257, 462);
            this.dataGridViewTables.TabIndex = 1;
            // 
            // textBoxTable
            // 
            this.textBoxTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxTable.Location = new System.Drawing.Point(3, 3);
            this.textBoxTable.Name = "textBoxTable";
            this.textBoxTable.Size = new System.Drawing.Size(257, 20);
            this.textBoxTable.TabIndex = 0;
            // 
            // tabPagePKs
            // 
            this.tabPagePKs.Controls.Add(this.dataGridViewPKs);
            this.tabPagePKs.Controls.Add(this.searchPKbox);
            this.tabPagePKs.ImageIndex = 6;
            this.tabPagePKs.Location = new System.Drawing.Point(4, 61);
            this.tabPagePKs.Name = "tabPagePKs";
            this.tabPagePKs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePKs.Size = new System.Drawing.Size(263, 488);
            this.tabPagePKs.TabIndex = 6;
            this.tabPagePKs.Text = "PKs";
            this.tabPagePKs.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPKs
            // 
            this.dataGridViewPKs.AllowUserToAddRows = false;
            this.dataGridViewPKs.AllowUserToDeleteRows = false;
            this.dataGridViewPKs.AllowUserToOrderColumns = true;
            this.dataGridViewPKs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPKs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPKs.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewPKs.Name = "dataGridViewPKs";
            this.dataGridViewPKs.ReadOnly = true;
            this.dataGridViewPKs.RowHeadersVisible = false;
            this.dataGridViewPKs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPKs.Size = new System.Drawing.Size(257, 462);
            this.dataGridViewPKs.TabIndex = 1;
            // 
            // searchPKbox
            // 
            this.searchPKbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPKbox.Location = new System.Drawing.Point(3, 3);
            this.searchPKbox.Name = "searchPKbox";
            this.searchPKbox.Size = new System.Drawing.Size(257, 20);
            this.searchPKbox.TabIndex = 0;
            // 
            // tabPageUKs
            // 
            this.tabPageUKs.Controls.Add(this.dataGridViewUnique);
            this.tabPageUKs.Controls.Add(this.textBoxUK);
            this.tabPageUKs.ImageIndex = 6;
            this.tabPageUKs.Location = new System.Drawing.Point(4, 61);
            this.tabPageUKs.Name = "tabPageUKs";
            this.tabPageUKs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUKs.Size = new System.Drawing.Size(263, 488);
            this.tabPageUKs.TabIndex = 7;
            this.tabPageUKs.Text = "UKs";
            this.tabPageUKs.UseVisualStyleBackColor = true;
            // 
            // dataGridViewUnique
            // 
            this.dataGridViewUnique.AllowUserToAddRows = false;
            this.dataGridViewUnique.AllowUserToDeleteRows = false;
            this.dataGridViewUnique.AllowUserToOrderColumns = true;
            this.dataGridViewUnique.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUnique.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUnique.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewUnique.Name = "dataGridViewUnique";
            this.dataGridViewUnique.ReadOnly = true;
            this.dataGridViewUnique.RowHeadersVisible = false;
            this.dataGridViewUnique.Size = new System.Drawing.Size(257, 462);
            this.dataGridViewUnique.TabIndex = 2;
            // 
            // textBoxUK
            // 
            this.textBoxUK.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxUK.Location = new System.Drawing.Point(3, 3);
            this.textBoxUK.Name = "textBoxUK";
            this.textBoxUK.Size = new System.Drawing.Size(257, 20);
            this.textBoxUK.TabIndex = 0;
            // 
            // tabPageFKs
            // 
            this.tabPageFKs.Controls.Add(this.dataGridViewFKs);
            this.tabPageFKs.Controls.Add(this.textBoxFK);
            this.tabPageFKs.ImageIndex = 6;
            this.tabPageFKs.Location = new System.Drawing.Point(4, 61);
            this.tabPageFKs.Name = "tabPageFKs";
            this.tabPageFKs.Size = new System.Drawing.Size(263, 488);
            this.tabPageFKs.TabIndex = 8;
            this.tabPageFKs.Text = "FKs";
            this.tabPageFKs.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFKs
            // 
            this.dataGridViewFKs.AllowUserToAddRows = false;
            this.dataGridViewFKs.AllowUserToDeleteRows = false;
            this.dataGridViewFKs.AllowUserToOrderColumns = true;
            this.dataGridViewFKs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFKs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFKs.Location = new System.Drawing.Point(0, 20);
            this.dataGridViewFKs.Name = "dataGridViewFKs";
            this.dataGridViewFKs.ReadOnly = true;
            this.dataGridViewFKs.RowHeadersVisible = false;
            this.dataGridViewFKs.Size = new System.Drawing.Size(263, 468);
            this.dataGridViewFKs.TabIndex = 3;
            // 
            // textBoxFK
            // 
            this.textBoxFK.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxFK.Location = new System.Drawing.Point(0, 0);
            this.textBoxFK.Name = "textBoxFK";
            this.textBoxFK.Size = new System.Drawing.Size(263, 20);
            this.textBoxFK.TabIndex = 0;
            // 
            // tabPageIndexes
            // 
            this.tabPageIndexes.Controls.Add(this.dataGridViewIndexes);
            this.tabPageIndexes.Controls.Add(this.textBoxIndex);
            this.tabPageIndexes.ImageIndex = 0;
            this.tabPageIndexes.Location = new System.Drawing.Point(4, 61);
            this.tabPageIndexes.Name = "tabPageIndexes";
            this.tabPageIndexes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIndexes.Size = new System.Drawing.Size(263, 488);
            this.tabPageIndexes.TabIndex = 0;
            this.tabPageIndexes.Text = "Indexes";
            this.tabPageIndexes.UseVisualStyleBackColor = true;
            // 
            // dataGridViewIndexes
            // 
            this.dataGridViewIndexes.AllowUserToAddRows = false;
            this.dataGridViewIndexes.AllowUserToDeleteRows = false;
            this.dataGridViewIndexes.AllowUserToOrderColumns = true;
            this.dataGridViewIndexes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIndexes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewIndexes.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewIndexes.Name = "dataGridViewIndexes";
            this.dataGridViewIndexes.ReadOnly = true;
            this.dataGridViewIndexes.RowHeadersVisible = false;
            this.dataGridViewIndexes.Size = new System.Drawing.Size(257, 462);
            this.dataGridViewIndexes.TabIndex = 2;
            // 
            // textBoxIndex
            // 
            this.textBoxIndex.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxIndex.Location = new System.Drawing.Point(3, 3);
            this.textBoxIndex.Name = "textBoxIndex";
            this.textBoxIndex.Size = new System.Drawing.Size(257, 20);
            this.textBoxIndex.TabIndex = 0;
            // 
            // tabPageTriggers
            // 
            this.tabPageTriggers.Controls.Add(this.dataGridViewTrigger);
            this.tabPageTriggers.Controls.Add(this.textBoxTrigger);
            this.tabPageTriggers.ImageIndex = 1;
            this.tabPageTriggers.Location = new System.Drawing.Point(4, 61);
            this.tabPageTriggers.Name = "tabPageTriggers";
            this.tabPageTriggers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTriggers.Size = new System.Drawing.Size(263, 488);
            this.tabPageTriggers.TabIndex = 1;
            this.tabPageTriggers.Text = "Triggers";
            this.tabPageTriggers.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTrigger
            // 
            this.dataGridViewTrigger.AllowUserToAddRows = false;
            this.dataGridViewTrigger.AllowUserToDeleteRows = false;
            this.dataGridViewTrigger.AllowUserToOrderColumns = true;
            this.dataGridViewTrigger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTrigger.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewTrigger.Name = "dataGridViewTrigger";
            this.dataGridViewTrigger.ReadOnly = true;
            this.dataGridViewTrigger.RowHeadersVisible = false;
            this.dataGridViewTrigger.Size = new System.Drawing.Size(257, 462);
            this.dataGridViewTrigger.TabIndex = 4;
            // 
            // textBoxTrigger
            // 
            this.textBoxTrigger.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxTrigger.Location = new System.Drawing.Point(3, 3);
            this.textBoxTrigger.Name = "textBoxTrigger";
            this.textBoxTrigger.Size = new System.Drawing.Size(257, 20);
            this.textBoxTrigger.TabIndex = 0;
            // 
            // tabPageProcedures
            // 
            this.tabPageProcedures.Controls.Add(this.dataGridViewProcedures);
            this.tabPageProcedures.Controls.Add(this.textBoxProcedure);
            this.tabPageProcedures.ImageIndex = 2;
            this.tabPageProcedures.Location = new System.Drawing.Point(4, 61);
            this.tabPageProcedures.Name = "tabPageProcedures";
            this.tabPageProcedures.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProcedures.Size = new System.Drawing.Size(263, 488);
            this.tabPageProcedures.TabIndex = 2;
            this.tabPageProcedures.Text = "Procedures";
            this.tabPageProcedures.UseVisualStyleBackColor = true;
            // 
            // dataGridViewProcedures
            // 
            this.dataGridViewProcedures.AllowUserToAddRows = false;
            this.dataGridViewProcedures.AllowUserToDeleteRows = false;
            this.dataGridViewProcedures.AllowUserToOrderColumns = true;
            this.dataGridViewProcedures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProcedures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProcedures.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewProcedures.Name = "dataGridViewProcedures";
            this.dataGridViewProcedures.ReadOnly = true;
            this.dataGridViewProcedures.RowHeadersVisible = false;
            this.dataGridViewProcedures.Size = new System.Drawing.Size(257, 462);
            this.dataGridViewProcedures.TabIndex = 4;
            // 
            // textBoxProcedure
            // 
            this.textBoxProcedure.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxProcedure.Location = new System.Drawing.Point(3, 3);
            this.textBoxProcedure.Name = "textBoxProcedure";
            this.textBoxProcedure.Size = new System.Drawing.Size(257, 20);
            this.textBoxProcedure.TabIndex = 0;
            // 
            // tabPageFunctions
            // 
            this.tabPageFunctions.Controls.Add(this.dataGridViewFunctions);
            this.tabPageFunctions.Controls.Add(this.textBoxFunction);
            this.tabPageFunctions.ImageIndex = 3;
            this.tabPageFunctions.Location = new System.Drawing.Point(4, 61);
            this.tabPageFunctions.Name = "tabPageFunctions";
            this.tabPageFunctions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFunctions.Size = new System.Drawing.Size(263, 488);
            this.tabPageFunctions.TabIndex = 3;
            this.tabPageFunctions.Text = "Functions";
            this.tabPageFunctions.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFunctions
            // 
            this.dataGridViewFunctions.AllowUserToAddRows = false;
            this.dataGridViewFunctions.AllowUserToDeleteRows = false;
            this.dataGridViewFunctions.AllowUserToOrderColumns = true;
            this.dataGridViewFunctions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFunctions.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewFunctions.Name = "dataGridViewFunctions";
            this.dataGridViewFunctions.ReadOnly = true;
            this.dataGridViewFunctions.RowHeadersVisible = false;
            this.dataGridViewFunctions.Size = new System.Drawing.Size(257, 462);
            this.dataGridViewFunctions.TabIndex = 5;
            // 
            // textBoxFunction
            // 
            this.textBoxFunction.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxFunction.Location = new System.Drawing.Point(3, 3);
            this.textBoxFunction.Name = "textBoxFunction";
            this.textBoxFunction.Size = new System.Drawing.Size(257, 20);
            this.textBoxFunction.TabIndex = 0;
            // 
            // tabPageViews
            // 
            this.tabPageViews.Controls.Add(this.dataGridViewView);
            this.tabPageViews.Controls.Add(this.textBoxView);
            this.tabPageViews.ImageIndex = 4;
            this.tabPageViews.Location = new System.Drawing.Point(4, 61);
            this.tabPageViews.Name = "tabPageViews";
            this.tabPageViews.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageViews.Size = new System.Drawing.Size(263, 488);
            this.tabPageViews.TabIndex = 4;
            this.tabPageViews.Text = "Views";
            this.tabPageViews.UseVisualStyleBackColor = true;
            // 
            // dataGridViewView
            // 
            this.dataGridViewView.AllowUserToAddRows = false;
            this.dataGridViewView.AllowUserToDeleteRows = false;
            this.dataGridViewView.AllowUserToOrderColumns = true;
            this.dataGridViewView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewView.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewView.Name = "dataGridViewView";
            this.dataGridViewView.ReadOnly = true;
            this.dataGridViewView.RowHeadersVisible = false;
            this.dataGridViewView.Size = new System.Drawing.Size(257, 462);
            this.dataGridViewView.TabIndex = 6;
            // 
            // textBoxView
            // 
            this.textBoxView.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxView.Location = new System.Drawing.Point(3, 3);
            this.textBoxView.Name = "textBoxView";
            this.textBoxView.Size = new System.Drawing.Size(257, 20);
            this.textBoxView.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "index-icon.png");
            this.imageList1.Images.SetKeyName(1, "trigger-icon.bmp");
            this.imageList1.Images.SetKeyName(2, "procedure-icon.png");
            this.imageList1.Images.SetKeyName(3, "function-icon.png");
            this.imageList1.Images.SetKeyName(4, "view-icon.png");
            this.imageList1.Images.SetKeyName(5, "table-icon.png");
            this.imageList1.Images.SetKeyName(6, "key-icon.png");
            // 
            // comboBoxServers
            // 
            this.comboBoxServers.DisplayMember = "host";
            this.comboBoxServers.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServers.FormattingEnabled = true;
            this.comboBoxServers.Location = new System.Drawing.Point(0, 0);
            this.comboBoxServers.Name = "comboBoxServers";
            this.comboBoxServers.Size = new System.Drawing.Size(271, 21);
            this.comboBoxServers.TabIndex = 0;
            this.comboBoxServers.ValueMember = "host";
            this.comboBoxServers.SelectedIndexChanged += new System.EventHandler(this.ComboBoxServers_SelectedIndexChanged);
            // 
            // TabView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "TabView";
            this.Size = new System.Drawing.Size(271, 574);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTables.ResumeLayout(false);
            this.tabPageTables.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTables)).EndInit();
            this.tabPagePKs.ResumeLayout(false);
            this.tabPagePKs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPKs)).EndInit();
            this.tabPageUKs.ResumeLayout(false);
            this.tabPageUKs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUnique)).EndInit();
            this.tabPageFKs.ResumeLayout(false);
            this.tabPageFKs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFKs)).EndInit();
            this.tabPageIndexes.ResumeLayout(false);
            this.tabPageIndexes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndexes)).EndInit();
            this.tabPageTriggers.ResumeLayout(false);
            this.tabPageTriggers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrigger)).EndInit();
            this.tabPageProcedures.ResumeLayout(false);
            this.tabPageProcedures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcedures)).EndInit();
            this.tabPageFunctions.ResumeLayout(false);
            this.tabPageFunctions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFunctions)).EndInit();
            this.tabPageViews.ResumeLayout(false);
            this.tabPageViews.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewView)).EndInit();
            this.ResumeLayout(false);

        }

    

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxServers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageIndexes;
        private System.Windows.Forms.TabPage tabPageTriggers;
        private System.Windows.Forms.TabPage tabPageProcedures;
        private System.Windows.Forms.TabPage tabPageFunctions;
        private System.Windows.Forms.TabPage tabPageViews;
        private System.Windows.Forms.TabPage tabPageTables;
        private System.Windows.Forms.TabPage tabPagePKs;
        private System.Windows.Forms.TabPage tabPageUKs;
        private System.Windows.Forms.TabPage tabPageFKs;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox textBoxTable;
        private System.Windows.Forms.TextBox searchPKbox;
        private System.Windows.Forms.TextBox textBoxUK;
        private System.Windows.Forms.TextBox textBoxIndex;
        private System.Windows.Forms.TextBox textBoxTrigger;
        private System.Windows.Forms.TextBox textBoxProcedure;
        private System.Windows.Forms.TextBox textBoxFunction;
        private System.Windows.Forms.TextBox textBoxView;
        private System.Windows.Forms.TextBox textBoxFK;
        private System.Windows.Forms.DataGridView dataGridViewTables;
        private System.Windows.Forms.DataGridView dataGridViewPKs;
        private System.Windows.Forms.DataGridView dataGridViewIndexes;
        private System.Windows.Forms.DataGridView dataGridViewUnique;
        private System.Windows.Forms.DataGridView dataGridViewFKs;
        private System.Windows.Forms.DataGridView dataGridViewTrigger;
        private System.Windows.Forms.DataGridView dataGridViewProcedures;
        private System.Windows.Forms.DataGridView dataGridViewFunctions;
        private System.Windows.Forms.DataGridView dataGridViewView;
    }
}
