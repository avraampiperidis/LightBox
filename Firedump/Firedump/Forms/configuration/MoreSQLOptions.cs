using Firedump.models.configuration.jsonconfig;
using Firedump.models.configuration.jsonconfig.dto;
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
    public partial class MoreSQLOptions : Form
    {
        public MoreSQLOptions()
        {
            InitializeComponent();
        }

        private void MoreSQLOptions_Load(object sender, EventArgs e)
        {
            SqlDumpDto settings = ConfigurationManager.getInstance().mysqlDumpConfigInstance.getSettings();
            //general
            cbAddComments.Checked = settings.includeComments;
            cbForeignKey.Checked = settings.disableForeignKeyChecks;
            if(settings.singleTransaction || settings.lockTables)
            {
                cbEnableDataPreservation.Checked = true;
                if (settings.singleTransaction)
                {
                    rbSingleTransaction.Checked = true;
                }
                else
                {
                    rbLockTables.Checked = true;
                }
            }
            else
            {
                cbEnableDataPreservation.Checked = false;
            }
            disableOrEnableRadioButtons(cbEnableDataPreservation.Checked);
            cbNoAutocommit.Checked = settings.noAutocommit;
            tbCustomComment.Text = settings.addCustomCommentInHeader;
            cbIncreasedComp.Checked = settings.moreCompatible;
            string[] charsets = { "utf8", "armscii8","ascii", "cp850", "cp852", "cp866", "cp1250", "cp1251", "cp1256", "cp1257", "dec8", "geostd8", "greek", "hebrew", "hp8", "Index",
                "keybcs2", "koi8r", "koi8u", "latin1", "latin2", "latin5", "latin7", "macce", "macroman", "swe7" };
            cmbCharacterSet.DataSource = charsets;
            cmbCharacterSet.SelectedItem = settings.characterSet;
            cbXml.Checked = settings.xml;

            //structure
            cbAddDropDatabase.Checked = settings.addDropDatabase;
            cbAddCreateDatabase.Checked = settings.createDatabase;
            cbAddDropTable.Checked = settings.addDropTable;
            cbAddLocks.Checked = settings.addLocks;
            cbAddDateComment.Checked = settings.addInfoComments;
            cbEncloseBackquotes.Checked = settings.encloseWithBackquotes;

            //data
            cbUseCompleteInserts.Checked = settings.completeInsertStatements;
            cbUseExtendedInserts.Checked = settings.extendedInsertStatements;
            cbUseIgnoreInserts.Checked = settings.useIgnoreInserts;
            cbUseHexadecimal.Checked = settings.useHexadecimal;
            nudMaxLength.Value = settings.maximumLengthOfQuery;
            nudMaxPacketSize.Value = settings.maximumPacketLength;
            string[] exportTypes = { "INSERT","REPLACE" };
            cmbExportType.DataSource = exportTypes;
            cmbExportType.SelectedIndex = settings.exportType;
        }

        private void disableOrEnableRadioButtons(bool action)
        {
            rbSingleTransaction.Enabled = action;
            rbLockTables.Enabled = action;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SqlDumpDto settings = ConfigurationManager.getInstance().mysqlDumpConfigInstance.getSettings();

            //general
            settings.includeComments = cbAddComments.Checked;
            settings.disableForeignKeyChecks = cbForeignKey.Checked;
            if (cbEnableDataPreservation.Checked)
            {
                settings.singleTransaction = rbSingleTransaction.Checked;
                settings.lockTables = rbLockTables.Checked;
            }
            else
            {
                settings.singleTransaction = false;
                settings.lockTables = false;
            }
            settings.noAutocommit = cbNoAutocommit.Checked;
            settings.addCustomCommentInHeader = tbCustomComment.Text;
            settings.moreCompatible = cbIncreasedComp.Checked;
            settings.characterSet = (string)cmbCharacterSet.SelectedItem;
            settings.xml = cbXml.Checked;

            //structure
            settings.addDropDatabase = cbAddDropDatabase.Checked;
            settings.createDatabase = cbAddCreateDatabase.Checked;
            settings.addDropTable = cbAddDropTable.Checked;
            settings.addLocks = cbAddLocks.Checked;
            settings.addInfoComments = cbAddDateComment.Checked;
            settings.encloseWithBackquotes = cbEncloseBackquotes.Checked;

            //data
            settings.completeInsertStatements = cbUseCompleteInserts.Checked;
            settings.extendedInsertStatements = cbUseExtendedInserts.Checked;
            settings.useIgnoreInserts = cbUseIgnoreInserts.Checked;
            settings.useHexadecimal = cbUseHexadecimal.Checked;
            settings.maximumLengthOfQuery = (int)nudMaxLength.Value;
            settings.maximumPacketLength = (int)nudMaxPacketSize.Value;
            settings.exportType = cmbExportType.SelectedIndex;

            ConfigurationManager.getInstance().mysqlDumpConfigInstance.setSettings(settings);
            ConfigurationManager.getInstance().mysqlDumpConfigInstance.saveConfig();
            this.Close();
        }

        private void cbEnableDataPreservation_CheckedChanged(object sender, EventArgs e)
        {
            disableOrEnableRadioButtons(cbEnableDataPreservation.Checked);
        }
    }
}
