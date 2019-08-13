namespace Firedump.Forms.location
{
    partial class FTPLocation
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
            this.label5 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.bTestConnection = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbProtocol = new System.Windows.Forms.ComboBox();
            this.cbPrivateKey = new System.Windows.Forms.CheckBox();
            this.tbPrivateKey = new System.Windows.Forms.TextBox();
            this.lbPrivateKey = new System.Windows.Forms.Label();
            this.bPrivateKeyPath = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbChooseAPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bPathOnServer = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Name:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(106, 36);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(191, 20);
            this.tbName.TabIndex = 21;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(358, 62);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(75, 20);
            this.tbPort.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Port:";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("News706 BT", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbPassword.Location = new System.Drawing.Point(106, 115);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(327, 21);
            this.tbPassword.TabIndex = 18;
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbUsername.Location = new System.Drawing.Point(106, 88);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(327, 20);
            this.tbUsername.TabIndex = 17;
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(106, 62);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(191, 20);
            this.tbHost.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Hostname:";
            // 
            // bSave
            // 
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bSave.Image = global::Firedump.Properties.Resources.save_image1;
            this.bSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSave.Location = new System.Drawing.Point(12, 362);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(162, 51);
            this.bSave.TabIndex = 25;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(464, 362);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(104, 51);
            this.bCancel.TabIndex = 24;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bTestConnection
            // 
            this.bTestConnection.Location = new System.Drawing.Point(12, 216);
            this.bTestConnection.Name = "bTestConnection";
            this.bTestConnection.Size = new System.Drawing.Size(162, 23);
            this.bTestConnection.TabIndex = 23;
            this.bTestConnection.Text = "Test Connection";
            this.bTestConnection.UseVisualStyleBackColor = true;
            this.bTestConnection.Click += new System.EventHandler(this.bTestConnection_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(303, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Protocol:";
            // 
            // cmbProtocol
            // 
            this.cmbProtocol.FormattingEnabled = true;
            this.cmbProtocol.Location = new System.Drawing.Point(358, 35);
            this.cmbProtocol.Name = "cmbProtocol";
            this.cmbProtocol.Size = new System.Drawing.Size(75, 21);
            this.cmbProtocol.TabIndex = 27;
            this.cmbProtocol.SelectedIndexChanged += new System.EventHandler(this.cmbProtocol_SelectedIndexChanged);
            // 
            // cbPrivateKey
            // 
            this.cbPrivateKey.AutoSize = true;
            this.cbPrivateKey.Location = new System.Drawing.Point(439, 146);
            this.cbPrivateKey.Name = "cbPrivateKey";
            this.cbPrivateKey.Size = new System.Drawing.Size(100, 17);
            this.cbPrivateKey.TabIndex = 28;
            this.cbPrivateKey.Text = "Use private key";
            this.cbPrivateKey.UseVisualStyleBackColor = true;
            this.cbPrivateKey.CheckedChanged += new System.EventHandler(this.cbPrivateKey_CheckedChanged);
            // 
            // tbPrivateKey
            // 
            this.tbPrivateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrivateKey.Location = new System.Drawing.Point(106, 142);
            this.tbPrivateKey.Name = "tbPrivateKey";
            this.tbPrivateKey.ReadOnly = true;
            this.tbPrivateKey.Size = new System.Drawing.Size(284, 20);
            this.tbPrivateKey.TabIndex = 29;
            // 
            // lbPrivateKey
            // 
            this.lbPrivateKey.AutoSize = true;
            this.lbPrivateKey.Location = new System.Drawing.Point(10, 145);
            this.lbPrivateKey.Name = "lbPrivateKey";
            this.lbPrivateKey.Size = new System.Drawing.Size(87, 13);
            this.lbPrivateKey.TabIndex = 30;
            this.lbPrivateKey.Text = "Private key path:";
            // 
            // bPrivateKeyPath
            // 
            this.bPrivateKeyPath.Location = new System.Drawing.Point(396, 142);
            this.bPrivateKeyPath.Name = "bPrivateKeyPath";
            this.bPrivateKeyPath.Size = new System.Drawing.Size(37, 23);
            this.bPrivateKeyPath.TabIndex = 31;
            this.bPrivateKeyPath.Text = "...";
            this.bPrivateKeyPath.UseVisualStyleBackColor = true;
            this.bPrivateKeyPath.Click += new System.EventHandler(this.bPrivateKeyPath_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbUsername);
            this.groupBox1.Controls.Add(this.bPrivateKeyPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbPrivateKey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbPrivateKey);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbPrivateKey);
            this.groupBox1.Controls.Add(this.tbHost);
            this.groupBox1.Controls.Add(this.cmbProtocol);
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbPort);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 189);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection credentials";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bPathOnServer);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbChooseAPath);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbFilename);
            this.groupBox2.Location = new System.Drawing.Point(12, 258);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(556, 98);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File path";
            // 
            // tbFilename
            // 
            this.tbFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilename.Location = new System.Drawing.Point(106, 28);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.Size = new System.Drawing.Size(327, 20);
            this.tbFilename.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Filename:";
            // 
            // tbChooseAPath
            // 
            this.tbChooseAPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChooseAPath.Location = new System.Drawing.Point(106, 55);
            this.tbChooseAPath.Name = "tbChooseAPath";
            this.tbChooseAPath.ReadOnly = true;
            this.tbChooseAPath.Size = new System.Drawing.Size(327, 20);
            this.tbChooseAPath.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Choose a path:";
            // 
            // bPathOnServer
            // 
            this.bPathOnServer.Location = new System.Drawing.Point(439, 53);
            this.bPathOnServer.Name = "bPathOnServer";
            this.bPathOnServer.Size = new System.Drawing.Size(37, 23);
            this.bPathOnServer.TabIndex = 32;
            this.bPathOnServer.Text = "...";
            this.bPathOnServer.UseVisualStyleBackColor = true;
            this.bPathOnServer.Click += new System.EventHandler(this.bPathOnServer_Click);
            // 
            // FTPLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 428);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bTestConnection);
            this.Name = "FTPLocation";
            this.Text = "FTPLocation";
            this.Load += new System.EventHandler(this.FTPLocation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bTestConnection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbProtocol;
        private System.Windows.Forms.CheckBox cbPrivateKey;
        private System.Windows.Forms.TextBox tbPrivateKey;
        private System.Windows.Forms.Label lbPrivateKey;
        private System.Windows.Forms.Button bPrivateKeyPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bPathOnServer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbChooseAPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbFilename;
    }
}