namespace Firedump.Forms.configuration
{
    partial class MoreSQLOptions
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
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.cbXml = new System.Windows.Forms.CheckBox();
            this.cbNoAutocommit = new System.Windows.Forms.CheckBox();
            this.cmbCharacterSet = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbIncreasedComp = new System.Windows.Forms.CheckBox();
            this.tbCustomComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbLockTables = new System.Windows.Forms.RadioButton();
            this.rbSingleTransaction = new System.Windows.Forms.RadioButton();
            this.cbEnableDataPreservation = new System.Windows.Forms.CheckBox();
            this.cbForeignKey = new System.Windows.Forms.CheckBox();
            this.cbAddComments = new System.Windows.Forms.CheckBox();
            this.gbStructure = new System.Windows.Forms.GroupBox();
            this.cbEncloseBackquotes = new System.Windows.Forms.CheckBox();
            this.cbAddDateComment = new System.Windows.Forms.CheckBox();
            this.cbAddLocks = new System.Windows.Forms.CheckBox();
            this.cbAddDropTable = new System.Windows.Forms.CheckBox();
            this.cbAddCreateDatabase = new System.Windows.Forms.CheckBox();
            this.cbAddDropDatabase = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudMaxPacketSize = new System.Windows.Forms.NumericUpDown();
            this.cmbExportType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbUseHexadecimal = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbUseIgnoreInserts = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudMaxLength = new System.Windows.Forms.NumericUpDown();
            this.cbUseExtendedInserts = new System.Windows.Forms.CheckBox();
            this.cbUseCompleteInserts = new System.Windows.Forms.CheckBox();
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.gbGeneral.SuspendLayout();
            this.gbStructure.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPacketSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxLength)).BeginInit();
            this.SuspendLayout();
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.cbXml);
            this.gbGeneral.Controls.Add(this.cbNoAutocommit);
            this.gbGeneral.Controls.Add(this.cmbCharacterSet);
            this.gbGeneral.Controls.Add(this.label2);
            this.gbGeneral.Controls.Add(this.cbIncreasedComp);
            this.gbGeneral.Controls.Add(this.tbCustomComment);
            this.gbGeneral.Controls.Add(this.label1);
            this.gbGeneral.Controls.Add(this.rbLockTables);
            this.gbGeneral.Controls.Add(this.rbSingleTransaction);
            this.gbGeneral.Controls.Add(this.cbEnableDataPreservation);
            this.gbGeneral.Controls.Add(this.cbForeignKey);
            this.gbGeneral.Controls.Add(this.cbAddComments);
            this.gbGeneral.Location = new System.Drawing.Point(25, 28);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(832, 191);
            this.gbGeneral.TabIndex = 0;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "General";
            // 
            // cbXml
            // 
            this.cbXml.AutoSize = true;
            this.cbXml.Location = new System.Drawing.Point(448, 147);
            this.cbXml.Name = "cbXml";
            this.cbXml.Size = new System.Drawing.Size(96, 17);
            this.cbXml.TabIndex = 11;
            this.cbXml.Text = "XML export file";
            this.cbXml.UseVisualStyleBackColor = true;
            // 
            // cbNoAutocommit
            // 
            this.cbNoAutocommit.AutoSize = true;
            this.cbNoAutocommit.Location = new System.Drawing.Point(18, 147);
            this.cbNoAutocommit.Name = "cbNoAutocommit";
            this.cbNoAutocommit.Size = new System.Drawing.Size(97, 17);
            this.cbNoAutocommit.TabIndex = 10;
            this.cbNoAutocommit.Text = "No autocommit";
            this.cbNoAutocommit.UseVisualStyleBackColor = true;
            // 
            // cmbCharacterSet
            // 
            this.cmbCharacterSet.FormattingEnabled = true;
            this.cmbCharacterSet.Location = new System.Drawing.Point(641, 111);
            this.cmbCharacterSet.Name = "cmbCharacterSet";
            this.cmbCharacterSet.Size = new System.Drawing.Size(134, 21);
            this.cmbCharacterSet.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Character set of the dump file:";
            // 
            // cbIncreasedComp
            // 
            this.cbIncreasedComp.AutoSize = true;
            this.cbIncreasedComp.Location = new System.Drawing.Point(448, 78);
            this.cbIncreasedComp.Name = "cbIncreasedComp";
            this.cbIncreasedComp.Size = new System.Drawing.Size(162, 17);
            this.cbIncreasedComp.TabIndex = 7;
            this.cbIncreasedComp.Text = "Increased compatibility mode";
            this.cbIncreasedComp.UseVisualStyleBackColor = true;
            // 
            // tbCustomComment
            // 
            this.tbCustomComment.Location = new System.Drawing.Point(448, 36);
            this.tbCustomComment.Name = "tbCustomComment";
            this.tbCustomComment.Size = new System.Drawing.Size(281, 20);
            this.tbCustomComment.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(445, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Add custom comment into header:";
            // 
            // rbLockTables
            // 
            this.rbLockTables.AutoSize = true;
            this.rbLockTables.Location = new System.Drawing.Point(48, 124);
            this.rbLockTables.Name = "rbLockTables";
            this.rbLockTables.Size = new System.Drawing.Size(93, 17);
            this.rbLockTables.TabIndex = 4;
            this.rbLockTables.TabStop = true;
            this.rbLockTables.Text = "Lock all tables";
            this.rbLockTables.UseVisualStyleBackColor = true;
            // 
            // rbSingleTransaction
            // 
            this.rbSingleTransaction.AutoSize = true;
            this.rbSingleTransaction.Location = new System.Drawing.Point(48, 101);
            this.rbSingleTransaction.Name = "rbSingleTransaction";
            this.rbSingleTransaction.Size = new System.Drawing.Size(109, 17);
            this.rbSingleTransaction.TabIndex = 3;
            this.rbSingleTransaction.TabStop = true;
            this.rbSingleTransaction.Text = "Single transaction";
            this.rbSingleTransaction.UseVisualStyleBackColor = true;
            // 
            // cbEnableDataPreservation
            // 
            this.cbEnableDataPreservation.AutoSize = true;
            this.cbEnableDataPreservation.Location = new System.Drawing.Point(18, 78);
            this.cbEnableDataPreservation.Name = "cbEnableDataPreservation";
            this.cbEnableDataPreservation.Size = new System.Drawing.Size(144, 17);
            this.cbEnableDataPreservation.TabIndex = 2;
            this.cbEnableDataPreservation.Text = "Enable data preservation";
            this.cbEnableDataPreservation.UseVisualStyleBackColor = true;
            this.cbEnableDataPreservation.CheckedChanged += new System.EventHandler(this.cbEnableDataPreservation_CheckedChanged);
            // 
            // cbForeignKey
            // 
            this.cbForeignKey.AutoSize = true;
            this.cbForeignKey.Location = new System.Drawing.Point(18, 55);
            this.cbForeignKey.Name = "cbForeignKey";
            this.cbForeignKey.Size = new System.Drawing.Size(154, 17);
            this.cbForeignKey.TabIndex = 1;
            this.cbForeignKey.Text = "Disable foreign key checks";
            this.cbForeignKey.UseVisualStyleBackColor = true;
            // 
            // cbAddComments
            // 
            this.cbAddComments.AutoSize = true;
            this.cbAddComments.Location = new System.Drawing.Point(18, 32);
            this.cbAddComments.Name = "cbAddComments";
            this.cbAddComments.Size = new System.Drawing.Size(96, 17);
            this.cbAddComments.TabIndex = 0;
            this.cbAddComments.Text = "Add comments";
            this.cbAddComments.UseVisualStyleBackColor = true;
            // 
            // gbStructure
            // 
            this.gbStructure.Controls.Add(this.cbEncloseBackquotes);
            this.gbStructure.Controls.Add(this.cbAddDateComment);
            this.gbStructure.Controls.Add(this.cbAddLocks);
            this.gbStructure.Controls.Add(this.cbAddDropTable);
            this.gbStructure.Controls.Add(this.cbAddCreateDatabase);
            this.gbStructure.Controls.Add(this.cbAddDropDatabase);
            this.gbStructure.Location = new System.Drawing.Point(25, 235);
            this.gbStructure.Name = "gbStructure";
            this.gbStructure.Size = new System.Drawing.Size(385, 230);
            this.gbStructure.TabIndex = 1;
            this.gbStructure.TabStop = false;
            this.gbStructure.Text = "Structure";
            // 
            // cbEncloseBackquotes
            // 
            this.cbEncloseBackquotes.AutoSize = true;
            this.cbEncloseBackquotes.Location = new System.Drawing.Point(18, 150);
            this.cbEncloseBackquotes.Name = "cbEncloseBackquotes";
            this.cbEncloseBackquotes.Size = new System.Drawing.Size(179, 17);
            this.cbEncloseBackquotes.TabIndex = 6;
            this.cbEncloseBackquotes.Text = "Enclose names with backquotes";
            this.cbEncloseBackquotes.UseVisualStyleBackColor = true;
            // 
            // cbAddDateComment
            // 
            this.cbAddDateComment.AutoSize = true;
            this.cbAddDateComment.Location = new System.Drawing.Point(18, 127);
            this.cbAddDateComment.Name = "cbAddDateComment";
            this.cbAddDateComment.Size = new System.Drawing.Size(115, 17);
            this.cbAddDateComment.TabIndex = 5;
            this.cbAddDateComment.Text = "Add date comment";
            this.cbAddDateComment.UseVisualStyleBackColor = true;
            // 
            // cbAddLocks
            // 
            this.cbAddLocks.AutoSize = true;
            this.cbAddLocks.Location = new System.Drawing.Point(18, 104);
            this.cbAddLocks.Name = "cbAddLocks";
            this.cbAddLocks.Size = new System.Drawing.Size(73, 17);
            this.cbAddLocks.TabIndex = 3;
            this.cbAddLocks.Text = "Add locks";
            this.cbAddLocks.UseVisualStyleBackColor = true;
            // 
            // cbAddDropTable
            // 
            this.cbAddDropTable.AutoSize = true;
            this.cbAddDropTable.Location = new System.Drawing.Point(18, 80);
            this.cbAddDropTable.Name = "cbAddDropTable";
            this.cbAddDropTable.Size = new System.Drawing.Size(116, 17);
            this.cbAddDropTable.TabIndex = 2;
            this.cbAddDropTable.Text = "Add DROP TABLE";
            this.cbAddDropTable.UseVisualStyleBackColor = true;
            // 
            // cbAddCreateDatabase
            // 
            this.cbAddCreateDatabase.AutoSize = true;
            this.cbAddCreateDatabase.Location = new System.Drawing.Point(18, 56);
            this.cbAddCreateDatabase.Name = "cbAddCreateDatabase";
            this.cbAddCreateDatabase.Size = new System.Drawing.Size(151, 17);
            this.cbAddCreateDatabase.TabIndex = 1;
            this.cbAddCreateDatabase.Text = "Add CREATE DATABASE";
            this.cbAddCreateDatabase.UseVisualStyleBackColor = true;
            // 
            // cbAddDropDatabase
            // 
            this.cbAddDropDatabase.AutoSize = true;
            this.cbAddDropDatabase.Location = new System.Drawing.Point(18, 32);
            this.cbAddDropDatabase.Name = "cbAddDropDatabase";
            this.cbAddDropDatabase.Size = new System.Drawing.Size(139, 17);
            this.cbAddDropDatabase.TabIndex = 0;
            this.cbAddDropDatabase.Text = "Add DROP DATABASE";
            this.cbAddDropDatabase.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudMaxPacketSize);
            this.groupBox2.Controls.Add(this.cmbExportType);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbUseHexadecimal);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbUseIgnoreInserts);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nudMaxLength);
            this.groupBox2.Controls.Add(this.cbUseExtendedInserts);
            this.groupBox2.Controls.Add(this.cbUseCompleteInserts);
            this.groupBox2.Location = new System.Drawing.Point(457, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 230);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // nudMaxPacketSize
            // 
            this.nudMaxPacketSize.Location = new System.Drawing.Point(209, 150);
            this.nudMaxPacketSize.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudMaxPacketSize.Name = "nudMaxPacketSize";
            this.nudMaxPacketSize.Size = new System.Drawing.Size(134, 20);
            this.nudMaxPacketSize.TabIndex = 10;
            // 
            // cmbExportType
            // 
            this.cmbExportType.FormattingEnabled = true;
            this.cmbExportType.Location = new System.Drawing.Point(209, 176);
            this.cmbExportType.Name = "cmbExportType";
            this.cmbExportType.Size = new System.Drawing.Size(134, 21);
            this.cmbExportType.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Export type:";
            // 
            // cbUseHexadecimal
            // 
            this.cbUseHexadecimal.AutoSize = true;
            this.cbUseHexadecimal.Location = new System.Drawing.Point(16, 104);
            this.cbUseHexadecimal.Name = "cbUseHexadecimal";
            this.cbUseHexadecimal.Size = new System.Drawing.Size(153, 17);
            this.cbUseHexadecimal.TabIndex = 7;
            this.cbUseHexadecimal.Text = "Use hexadecimal for binary";
            this.cbUseHexadecimal.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Maximum allowed packet size (in MB):";
            // 
            // cbUseIgnoreInserts
            // 
            this.cbUseIgnoreInserts.AutoSize = true;
            this.cbUseIgnoreInserts.Location = new System.Drawing.Point(16, 80);
            this.cbUseIgnoreInserts.Name = "cbUseIgnoreInserts";
            this.cbUseIgnoreInserts.Size = new System.Drawing.Size(110, 17);
            this.cbUseIgnoreInserts.TabIndex = 6;
            this.cbUseIgnoreInserts.Text = "Use ingore inserts";
            this.cbUseIgnoreInserts.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Maximum length of created query:";
            // 
            // nudMaxLength
            // 
            this.nudMaxLength.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudMaxLength.Location = new System.Drawing.Point(209, 123);
            this.nudMaxLength.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMaxLength.Name = "nudMaxLength";
            this.nudMaxLength.Size = new System.Drawing.Size(134, 20);
            this.nudMaxLength.TabIndex = 2;
            this.nudMaxLength.ThousandsSeparator = true;
            // 
            // cbUseExtendedInserts
            // 
            this.cbUseExtendedInserts.AutoSize = true;
            this.cbUseExtendedInserts.Location = new System.Drawing.Point(16, 56);
            this.cbUseExtendedInserts.Name = "cbUseExtendedInserts";
            this.cbUseExtendedInserts.Size = new System.Drawing.Size(125, 17);
            this.cbUseExtendedInserts.TabIndex = 1;
            this.cbUseExtendedInserts.Text = "Use extended inserts";
            this.cbUseExtendedInserts.UseVisualStyleBackColor = true;
            // 
            // cbUseCompleteInserts
            // 
            this.cbUseCompleteInserts.AutoSize = true;
            this.cbUseCompleteInserts.Location = new System.Drawing.Point(16, 32);
            this.cbUseCompleteInserts.Name = "cbUseCompleteInserts";
            this.cbUseCompleteInserts.Size = new System.Drawing.Size(124, 17);
            this.cbUseCompleteInserts.TabIndex = 0;
            this.cbUseCompleteInserts.Text = "Use complete inserts";
            this.cbUseCompleteInserts.UseVisualStyleBackColor = true;
            // 
            // bSave
            // 
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bSave.Image = global::Firedump.Properties.Resources.save_image1;
            this.bSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSave.Location = new System.Drawing.Point(25, 483);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(172, 37);
            this.bSave.TabIndex = 3;
            this.bSave.Text = "Save Options";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bCancel.Location = new System.Drawing.Point(762, 483);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(95, 37);
            this.bCancel.TabIndex = 4;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // MoreSQLOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 532);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbStructure);
            this.Controls.Add(this.gbGeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoreSQLOptions";
            this.Text = "MoreSQLOptions";
            this.Load += new System.EventHandler(this.MoreSQLOptions_Load);
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            this.gbStructure.ResumeLayout(false);
            this.gbStructure.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPacketSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.ComboBox cmbCharacterSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbIncreasedComp;
        private System.Windows.Forms.TextBox tbCustomComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbLockTables;
        private System.Windows.Forms.RadioButton rbSingleTransaction;
        private System.Windows.Forms.CheckBox cbEnableDataPreservation;
        private System.Windows.Forms.CheckBox cbForeignKey;
        private System.Windows.Forms.CheckBox cbAddComments;
        private System.Windows.Forms.GroupBox gbStructure;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbNoAutocommit;
        private System.Windows.Forms.CheckBox cbAddDropDatabase;
        private System.Windows.Forms.CheckBox cbAddCreateDatabase;
        private System.Windows.Forms.CheckBox cbAddDropTable;
        private System.Windows.Forms.CheckBox cbAddLocks;
        private System.Windows.Forms.CheckBox cbAddDateComment;
        private System.Windows.Forms.CheckBox cbEncloseBackquotes;
        private System.Windows.Forms.CheckBox cbXml;
        private System.Windows.Forms.ComboBox cmbExportType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbUseHexadecimal;
        private System.Windows.Forms.CheckBox cbUseIgnoreInserts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudMaxLength;
        private System.Windows.Forms.CheckBox cbUseExtendedInserts;
        private System.Windows.Forms.CheckBox cbUseCompleteInserts;
        private System.Windows.Forms.NumericUpDown nudMaxPacketSize;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
    }
}