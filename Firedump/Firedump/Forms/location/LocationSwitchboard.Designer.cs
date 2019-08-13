namespace Firedump.Forms.location
{
    partial class LocationSwitchboard
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
            this.bFileSystem = new System.Windows.Forms.Button();
            this.bFTP = new System.Windows.Forms.Button();
            this.bDropbox = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bGoogleDrive = new System.Windows.Forms.Button();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.backuplocationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.firedumpdbDataSet = new Firedump.firedumpdbDataSet();
            this.bAdd = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.lPath = new System.Windows.Forms.Label();
            this.bDelete = new System.Windows.Forms.Button();
            this.backup_locationsTableAdapter = new Firedump.firedumpdbDataSetTableAdapters.backup_locationsTableAdapter();
            this.bEdit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backuplocationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firedumpdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bFileSystem
            // 
            this.bFileSystem.Location = new System.Drawing.Point(70, 39);
            this.bFileSystem.Name = "bFileSystem";
            this.bFileSystem.Size = new System.Drawing.Size(149, 52);
            this.bFileSystem.TabIndex = 0;
            this.bFileSystem.Text = "File System";
            this.bFileSystem.UseVisualStyleBackColor = true;
            this.bFileSystem.Click += new System.EventHandler(this.bFileSystem_Click);
            // 
            // bFTP
            // 
            this.bFTP.Location = new System.Drawing.Point(70, 116);
            this.bFTP.Name = "bFTP";
            this.bFTP.Size = new System.Drawing.Size(149, 52);
            this.bFTP.TabIndex = 1;
            this.bFTP.Text = "FTP";
            this.bFTP.UseVisualStyleBackColor = true;
            this.bFTP.Click += new System.EventHandler(this.bFTP_Click);
            // 
            // bDropbox
            // 
            this.bDropbox.Location = new System.Drawing.Point(327, 39);
            this.bDropbox.Name = "bDropbox";
            this.bDropbox.Size = new System.Drawing.Size(150, 52);
            this.bDropbox.TabIndex = 2;
            this.bDropbox.Text = "Dropbox";
            this.bDropbox.UseVisualStyleBackColor = true;
            this.bDropbox.Click += new System.EventHandler(this.bDropbox_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.bGoogleDrive);
            this.groupBox1.Controls.Add(this.bFileSystem);
            this.groupBox1.Controls.Add(this.bDropbox);
            this.groupBox1.Controls.Add(this.bFTP);
            this.groupBox1.Location = new System.Drawing.Point(12, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 203);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Save Location";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Firedump.Properties.Resources.ftpicon;
            this.pictureBox5.Location = new System.Drawing.Point(21, 116);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(52, 52);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 15;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Firedump.Properties.Resources.mycomputericon;
            this.pictureBox4.Location = new System.Drawing.Point(21, 39);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(52, 52);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Firedump.Properties.Resources.googeldriveicon;
            this.pictureBox3.Location = new System.Drawing.Point(279, 116);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(52, 52);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Firedump.Properties.Resources.dropboxicon;
            this.pictureBox2.Location = new System.Drawing.Point(279, 39);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // bGoogleDrive
            // 
            this.bGoogleDrive.Location = new System.Drawing.Point(327, 116);
            this.bGoogleDrive.Name = "bGoogleDrive";
            this.bGoogleDrive.Size = new System.Drawing.Size(150, 52);
            this.bGoogleDrive.TabIndex = 3;
            this.bGoogleDrive.Text = "Google Drive";
            this.bGoogleDrive.UseVisualStyleBackColor = true;
            this.bGoogleDrive.Click += new System.EventHandler(this.bGoogleDrive_Click);
            // 
            // cmbName
            // 
            this.cmbName.DataSource = this.backuplocationsBindingSource;
            this.cmbName.DisplayMember = "name";
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(59, 82);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(315, 21);
            this.cmbName.TabIndex = 4;
            this.cmbName.ValueMember = "id";
            this.cmbName.SelectedIndexChanged += new System.EventHandler(this.cmbName_SelectedIndexChanged);
            // 
            // backuplocationsBindingSource
            // 
            this.backuplocationsBindingSource.DataMember = "backup_locations";
            this.backuplocationsBindingSource.DataSource = this.firedumpdbDataSet;
            // 
            // firedumpdbDataSet
            // 
            this.firedumpdbDataSet.DataSetName = "firedumpdbDataSet";
            this.firedumpdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(398, 80);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(75, 23);
            this.bAdd.TabIndex = 5;
            this.bAdd.Text = "Add ";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(59, 140);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(315, 20);
            this.tbPath.TabIndex = 6;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(12, 85);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(38, 13);
            this.lName.TabIndex = 7;
            this.lName.Text = "Name:";
            // 
            // lPath
            // 
            this.lPath.AutoSize = true;
            this.lPath.Location = new System.Drawing.Point(12, 143);
            this.lPath.Name = "lPath";
            this.lPath.Size = new System.Drawing.Size(32, 13);
            this.lPath.TabIndex = 8;
            this.lPath.Text = "Path:";
            // 
            // bDelete
            // 
            this.bDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bDelete.Location = new System.Drawing.Point(59, 191);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(140, 23);
            this.bDelete.TabIndex = 9;
            this.bDelete.Text = "Delete Save Location";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // backup_locationsTableAdapter
            // 
            this.backup_locationsTableAdapter.ClearBeforeFill = true;
            // 
            // bEdit
            // 
            this.bEdit.Location = new System.Drawing.Point(275, 191);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(140, 23);
            this.bEdit.TabIndex = 10;
            this.bEdit.Text = "Edit Save Location";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Firedump.Properties.Resources.delete_icon;
            this.pictureBox1.Location = new System.Drawing.Point(33, 191);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // LocationSwitchboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 466);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.lPath);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.cmbName);
            this.Controls.Add(this.groupBox1);
            this.Name = "LocationSwitchboard";
            this.Text = "Add Location";
            this.Load += new System.EventHandler(this.LocationSwitchboard_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backuplocationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firedumpdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bFileSystem;
        private System.Windows.Forms.Button bFTP;
        private System.Windows.Forms.Button bDropbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bGoogleDrive;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lPath;
        private System.Windows.Forms.Button bDelete;
        private firedumpdbDataSet firedumpdbDataSet;
        private System.Windows.Forms.BindingSource backuplocationsBindingSource;
        private firedumpdbDataSetTableAdapters.backup_locationsTableAdapter backup_locationsTableAdapter;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}