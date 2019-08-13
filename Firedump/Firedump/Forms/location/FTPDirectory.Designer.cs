namespace Firedump.Forms.location
{
    partial class FTPDirectory
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.btusepath = new System.Windows.Forms.Button();
            this.tbpath = new System.Windows.Forms.TextBox();
            this.bgoBack = new System.Windows.Forms.Button();
            this.cbhiden = new System.Windows.Forms.CheckBox();
            this.fileCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.permissionsCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileCol,
            this.userCol,
            this.groupCol,
            this.permissionsCol});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(2, 74);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(722, 367);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // btusepath
            // 
            this.btusepath.Location = new System.Drawing.Point(12, 45);
            this.btusepath.Name = "btusepath";
            this.btusepath.Size = new System.Drawing.Size(85, 23);
            this.btusepath.TabIndex = 4;
            this.btusepath.Text = "Use this path";
            this.btusepath.UseVisualStyleBackColor = true;
            this.btusepath.Click += new System.EventHandler(this.btusepath_Click);
            // 
            // tbpath
            // 
            this.tbpath.Location = new System.Drawing.Point(103, 18);
            this.tbpath.Name = "tbpath";
            this.tbpath.Size = new System.Drawing.Size(621, 20);
            this.tbpath.TabIndex = 6;
            // 
            // bgoBack
            // 
            this.bgoBack.Location = new System.Drawing.Point(12, 16);
            this.bgoBack.Name = "bgoBack";
            this.bgoBack.Size = new System.Drawing.Size(85, 23);
            this.bgoBack.TabIndex = 7;
            this.bgoBack.Text = "Go back";
            this.bgoBack.UseVisualStyleBackColor = true;
            this.bgoBack.Click += new System.EventHandler(this.bgoBack_Click);
            // 
            // cbhiden
            // 
            this.cbhiden.AutoSize = true;
            this.cbhiden.Location = new System.Drawing.Point(104, 51);
            this.cbhiden.Name = "cbhiden";
            this.cbhiden.Size = new System.Drawing.Size(103, 17);
            this.cbhiden.TabIndex = 8;
            this.cbhiden.Text = "Show hiden files";
            this.cbhiden.UseVisualStyleBackColor = true;
            this.cbhiden.CheckedChanged += new System.EventHandler(this.cbhiden_CheckedChanged);
            // 
            // fileCol
            // 
            this.fileCol.Text = "Name";
            this.fileCol.Width = 150;
            // 
            // userCol
            // 
            this.userCol.Text = "Owner";
            // 
            // permissionsCol
            // 
            this.permissionsCol.Text = "Permissions";
            this.permissionsCol.Width = 100;
            // 
            // groupCol
            // 
            this.groupCol.Text = "Group";
            // 
            // FTPDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 445);
            this.Controls.Add(this.cbhiden);
            this.Controls.Add(this.bgoBack);
            this.Controls.Add(this.tbpath);
            this.Controls.Add(this.btusepath);
            this.Controls.Add(this.listView1);
            this.Name = "FTPDirectory";
            this.Text = "FTP File Browser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FTPDirectory_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btusepath;
        private System.Windows.Forms.TextBox tbpath;
        private System.Windows.Forms.Button bgoBack;
        private System.Windows.Forms.CheckBox cbhiden;
        private System.Windows.Forms.ColumnHeader fileCol;
        private System.Windows.Forms.ColumnHeader userCol;
        private System.Windows.Forms.ColumnHeader permissionsCol;
        private System.Windows.Forms.ColumnHeader groupCol;
    }
}