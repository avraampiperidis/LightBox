namespace Firedump.usercontrols
{
    partial class TableView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableView));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeViewTables = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "table-icon.png");
            this.imageList1.Images.SetKeyName(1, "fieldicon.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeViewTables);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 497);
            this.panel1.TabIndex = 0;
            // 
            // treeViewTables
            // 
            this.treeViewTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTables.ImageIndex = 0;
            this.treeViewTables.ImageList = this.imageList1;
            this.treeViewTables.Location = new System.Drawing.Point(0, 20);
            this.treeViewTables.Name = "treeViewTables";
            this.treeViewTables.SelectedImageIndex = 0;
            this.treeViewTables.Size = new System.Drawing.Size(298, 477);
            this.treeViewTables.TabIndex = 2;
            this.treeViewTables.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeViewTables_BeforeExpand);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(298, 20);
            this.textBox1.TabIndex = 1;
            // 
            // TableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "TableView";
            this.Size = new System.Drawing.Size(298, 497);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeViewTables;
        private System.Windows.Forms.TextBox textBox1;
    }
}
