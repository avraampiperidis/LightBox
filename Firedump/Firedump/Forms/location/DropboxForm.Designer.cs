namespace Firedump.Forms.location
{
    partial class DropboxForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.bsaveconnect = new System.Windows.Forms.Button();
            this.tbtoken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstatus = new System.Windows.Forms.Label();
            this.linfo = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.listView1 = new System.Windows.Forms.ListView();
            this.fileCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizecol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lfilename = new System.Windows.Forms.Label();
            this.tbfilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btback = new System.Windows.Forms.Button();
            this.btnsavelocation = new System.Windows.Forms.Button();
            this.tbsavename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.bsaveconnect);
            this.groupBox1.Controls.Add(this.tbtoken);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dropbox user  Credentials";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(339, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "And create Full Dropbox App!";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(501, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Visit to get the token:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(117, 16);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(216, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://www.dropbox.com/developers/apps";
            this.linkLabel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.linkLabel1_MouseClick);
            // 
            // bsaveconnect
            // 
            this.bsaveconnect.Location = new System.Drawing.Point(521, 41);
            this.bsaveconnect.Name = "bsaveconnect";
            this.bsaveconnect.Size = new System.Drawing.Size(111, 23);
            this.bsaveconnect.TabIndex = 6;
            this.bsaveconnect.Text = "Save and Connect";
            this.bsaveconnect.UseVisualStyleBackColor = true;
            this.bsaveconnect.Click += new System.EventHandler(this.bsaveconnect_Click);
            // 
            // tbtoken
            // 
            this.tbtoken.Location = new System.Drawing.Point(53, 38);
            this.tbtoken.Name = "tbtoken";
            this.tbtoken.Size = new System.Drawing.Size(442, 20);
            this.tbtoken.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Token:";
            // 
            // lstatus
            // 
            this.lstatus.AutoSize = true;
            this.lstatus.Location = new System.Drawing.Point(16, 91);
            this.lstatus.Name = "lstatus";
            this.lstatus.Size = new System.Drawing.Size(40, 13);
            this.lstatus.TabIndex = 1;
            this.lstatus.Text = "Status:";
            // 
            // linfo
            // 
            this.linfo.AutoSize = true;
            this.linfo.Location = new System.Drawing.Point(62, 91);
            this.linfo.Name = "linfo";
            this.linfo.Size = new System.Drawing.Size(25, 13);
            this.linfo.TabIndex = 2;
            this.linfo.Text = "Info";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileCol,
            this.sizecol});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 139);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(679, 363);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // fileCol
            // 
            this.fileCol.Text = "Name";
            this.fileCol.Width = 150;
            // 
            // sizecol
            // 
            this.sizecol.Text = "Size KB";
            // 
            // lfilename
            // 
            this.lfilename.AutoSize = true;
            this.lfilename.Location = new System.Drawing.Point(103, 115);
            this.lfilename.Name = "lfilename";
            this.lfilename.Size = new System.Drawing.Size(52, 13);
            this.lfilename.TabIndex = 5;
            this.lfilename.Text = "Filename:";
            // 
            // tbfilename
            // 
            this.tbfilename.Location = new System.Drawing.Point(155, 112);
            this.tbfilename.Name = "tbfilename";
            this.tbfilename.Size = new System.Drawing.Size(115, 20);
            this.tbfilename.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(276, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "*";
            // 
            // btback
            // 
            this.btback.Location = new System.Drawing.Point(13, 110);
            this.btback.Name = "btback";
            this.btback.Size = new System.Drawing.Size(84, 23);
            this.btback.TabIndex = 12;
            this.btback.Text = "home";
            this.btback.UseVisualStyleBackColor = true;
            this.btback.Click += new System.EventHandler(this.btback_Click);
            // 
            // btnsavelocation
            // 
            this.btnsavelocation.Location = new System.Drawing.Point(534, 110);
            this.btnsavelocation.Name = "btnsavelocation";
            this.btnsavelocation.Size = new System.Drawing.Size(110, 23);
            this.btnsavelocation.TabIndex = 13;
            this.btnsavelocation.Text = "Save Location";
            this.btnsavelocation.UseVisualStyleBackColor = true;
            this.btnsavelocation.Click += new System.EventHandler(this.btnsavelocation_Click);
            // 
            // tbsavename
            // 
            this.tbsavename.Location = new System.Drawing.Point(427, 112);
            this.tbsavename.Name = "tbsavename";
            this.tbsavename.Size = new System.Drawing.Size(100, 20);
            this.tbsavename.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "SaveName:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Firedump.Properties.Resources.dropboxicon;
            this.pictureBox1.Location = new System.Drawing.Point(656, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // DropboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 511);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbsavename);
            this.Controls.Add(this.btnsavelocation);
            this.Controls.Add(this.btback);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbfilename);
            this.Controls.Add(this.lfilename);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.linfo);
            this.Controls.Add(this.lstatus);
            this.Controls.Add(this.groupBox1);
            this.Name = "DropboxForm";
            this.Text = "DropboxForm";
            this.Load += new System.EventHandler(this.DropboxForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbtoken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bsaveconnect;
        private System.Windows.Forms.Label lstatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label linfo;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader fileCol;
        private System.Windows.Forms.Label lfilename;
        private System.Windows.Forms.TextBox tbfilename;
        private System.Windows.Forms.ColumnHeader sizecol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btback;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnsavelocation;
        private System.Windows.Forms.TextBox tbsavename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}