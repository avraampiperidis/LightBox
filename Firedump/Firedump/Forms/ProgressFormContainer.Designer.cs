namespace Firedump.Forms
{
    partial class ProgressFormContainer
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
            this.bclose = new System.Windows.Forms.Button();
            this.progressContainer = new Firedump.usercontrols.ProgressContrainer();
            this.SuspendLayout();
            // 
            // bclose
            // 
            this.bclose.Location = new System.Drawing.Point(12, 409);
            this.bclose.Name = "bclose";
            this.bclose.Size = new System.Drawing.Size(423, 23);
            this.bclose.TabIndex = 1;
            this.bclose.Text = "Close";
            this.bclose.UseVisualStyleBackColor = true;
            this.bclose.Click += new System.EventHandler(this.bclose_Click);
            // 
            // progressContainer
            // 
            this.progressContainer.Location = new System.Drawing.Point(12, 12);
            this.progressContainer.Name = "progressContainer";
            this.progressContainer.Size = new System.Drawing.Size(423, 391);
            this.progressContainer.TabIndex = 0;
            // 
            // ProgressFormContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 442);
            this.Controls.Add(this.bclose);
            this.Controls.Add(this.progressContainer);
            this.Name = "ProgressFormContainer";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private usercontrols.ProgressContrainer progressContainer;
        private System.Windows.Forms.Button bclose;
    }
}