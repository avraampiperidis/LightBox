using Firedump.models.configuration.jsonconfig;
using Firedump.models.configuration.jsonconfig.dto;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.configuration
{
    public partial class GeneralConfiguration : Form
    {
        public GeneralConfiguration()
        {
            InitializeComponent();
        }

        private void GeneralConfiguration_Load(object sender, EventArgs e)
        {
            setupFormComponents();
        }

        private void setupFormComponents()
        {
            SqlDumpDto mysqlSettings = ConfigurationManager.getInstance().getMySqlDumpSettings();
            CompressDto compSettings = ConfigurationManager.getInstance().getCompressSettings();

            //Folder Options
            tbTempFolder.Text = mysqlSettings.tempSavePath;
            tbLogFolder.Text = ""; //not implemented yet

            //SQL Dump Options
            cbCreateSchema.Checked = mysqlSettings.includeCreateSchema;
            cbDumpData.Checked = mysqlSettings.includeData;
            cbEvents.Checked = mysqlSettings.dumpEvents;
            cbTriggers.Checked = mysqlSettings.dumpTriggers;
            cbProcsFuncs.Checked = mysqlSettings.addCreateProcedureFunction;
            cbSingleFile.Checked = true; //not implemented yet

            //Compression settings
            cbEnableComp.Checked = compSettings.enableCompression;
            /// 0 - -t7z : file.7z
            /// 1 - -tgzip : file.gzip
            /// 2 - -tzip : file.zip
            /// 3 - -tbzip2 : file.bzip2
            /// 4 - -ttar : file.tar (UNIX and LINUX)
            /// 5 - -tiso : file.iso
            /// 6 - -tudf : file.udf
            cmbFileFormat.DataSource = new string[] { ".7z", ".gzip", ".zip", ".bzip2", ".tar", ".iso", ".udf" };
            cmbFileFormat.SelectedIndex = compSettings.fileType;
            /// 0 - -mx1 : Low compression faster proccess
            /// 1 - -mx3 : Fast compression mode
            /// 2 - -mx5 : Normal compression mode
            /// 3 - -mx7 : Maximum compression mode
            /// 4 - -mx9 : Ultra compression mode
            cmbCompressionLevel.DataSource = new string[] { "Fastest", "Fast", "Normal", "Maximum", "Ultra" };
            cmbCompressionLevel.SelectedIndex = compSettings.compressionLevel;
            cbUseMultithreading.Checked = compSettings.useMultithreading;
            cbEnablePasswordEncryption.Checked = compSettings.enablePasswordEncryption;
            cbEncryptHeader.Checked = compSettings.encryptHeader;
            tbPass.Text = compSettings.password;
            tbConfirmPass.Text = compSettings.password;
            if (!cbEnableComp.Checked)
            {
                disableORenableCompression(false);
            }
            if (!cbEnablePasswordEncryption.Checked)
            {
                disableORenableEnryption(false);
            }
        }

        private void disableORenableCompression(bool action)
        {
            lbFileFormat.Enabled = action;
            lbCompressionLevel.Enabled = action;
            cmbFileFormat.Enabled = action;
            cmbCompressionLevel.Enabled = action;
            cbUseMultithreading.Enabled = action;
            gbEncryption.Enabled = action;
        }

        private void disableORenableEnryption(bool action)
        {
            cbEncryptHeader.Enabled = action;
            lbPass.Enabled = action;
            lbConfirmPass.Enabled = action;
            tbPass.Enabled = action;
            tbConfirmPass.Enabled = action;
        }

        private void cbEnableComp_CheckedChanged(object sender, EventArgs e)
        {
            disableORenableCompression(cbEnableComp.Checked);
        }

        private void cbEnablePasswordEncryption_CheckedChanged(object sender, EventArgs e)
        {
            disableORenableEnryption(cbEnablePasswordEncryption.Checked);
            if (cbEnablePasswordEncryption.Checked)
            {
                if (tbPass.Text != tbConfirmPass.Text)
                {
                    lbPassHelp.Visible = true;
                }
                return;
            }
            lbPassHelp.Visible = false;
        }

        private void bTempFolder_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();
            cofd.IsFolderPicker = true;
            cofd.InitialDirectory = tbTempFolder.Text;  
            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                tbTempFolder.Text = cofd.FileName + "\\";
            }
        }

        private void bLogFolder_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();
            cofd.IsFolderPicker = true;
            cofd.InitialDirectory = tbLogFolder.Text;
            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                tbLogFolder.Text = cofd.FileName + "\\";
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SqlDumpDto mysqlSettings = ConfigurationManager.getInstance().getMySqlDumpSettings();
            CompressDto compSettings = ConfigurationManager.getInstance().getCompressSettings();
            if (cbEncryptHeader.Checked)
            {
                if (cmbFileFormat.SelectedIndex != 0)
                {
                    MessageBox.Show("Header encryption only works with .7z file format. Switch to .7z format or disable header encryption.",
                        "Header Encryption",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }

            if (cbEnableComp.Checked && cbEnablePasswordEncryption.Checked)
            {
                if (tbPass.Text!=tbConfirmPass.Text)
                {
                    MessageBox.Show("The two passwords do not match.",
                        "Passowrd Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                compSettings.password = tbPass.Text;
            }

            //folder locations
            mysqlSettings.tempSavePath = tbTempFolder.Text;
            //log folder path not implemented yet

            //SQL dump options
            mysqlSettings.includeCreateSchema = cbCreateSchema.Checked;
            mysqlSettings.includeData = cbDumpData.Checked;
            mysqlSettings.dumpEvents = cbEvents.Checked;
            mysqlSettings.dumpTriggers = cbTriggers.Checked;
            mysqlSettings.addCreateProcedureFunction = cbProcsFuncs.Checked;
            //single file selection not implemented yet

            //compression options
            compSettings.enableCompression = cbEnableComp.Checked;
            compSettings.fileType = cmbFileFormat.SelectedIndex;
            compSettings.compressionLevel = cmbCompressionLevel.SelectedIndex;
            compSettings.useMultithreading = cbUseMultithreading.Checked;

            //encryption
            compSettings.enablePasswordEncryption = cbEnablePasswordEncryption.Checked;
            compSettings.encryptHeader = cbEncryptHeader.Checked;

            ConfigurationManager.getInstance().mysqlDumpConfigInstance.setSettings(mysqlSettings);
            ConfigurationManager.getInstance().compressConfigInstance.setSettings(compSettings);
            ConfigurationManager.getInstance().mysqlDumpConfigInstance.saveConfig();
            ConfigurationManager.getInstance().compressConfigInstance.saveConfig();
            this.Close();
        }

        private void tbConfirmPass_Leave(object sender, EventArgs e)
        {
            if (tbPass.Text!=tbConfirmPass.Text)
            {
                lbPassHelp.Visible = true;
            }
            else
            {
                lbPassHelp.Visible = false;
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to reset the configuration to default values?","Configuration Reset",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                ConfigurationManager.getInstance().resetToDefaults();
                setupFormComponents();
            }
        }

        private void bMoreSQLOptions_Click(object sender, EventArgs e)
        {
            new MoreSQLOptions().ShowDialog();
        }
    }
}
