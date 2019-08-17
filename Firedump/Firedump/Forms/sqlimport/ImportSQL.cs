using Firedump.Forms.location;
using Firedump.models.configuration.dynamicconfig;
using Firedump.models.databaseUtils;
using Firedump.models.db;
using Firedump.models.dbUtils;
using Firedump.models.location;
using Firedump.models.sqlimport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.sqlimport
{
    public partial class ImportSQL : Form
    {
        private Task reloadDatabasesTask;
        private List<string> databases = new List<string>();
        private DataRow location;
        private ImportAdapterManager adapter;
        private bool isLocal;
        private bool isCompressed;
        private bool isEncrypted;
        private TextBox tb = new TextBox();
        public ImportSQL()
        {
            InitializeComponent();
        }

        private void SQLImport_Load(object sender, EventArgs e)
        {
            linfo.Text = "If the file is compressed it must contain\na .sql file with the same name for example\nthefile.7z must contain thefile.sql";

            // TODO: This line of code loads data into the 'firedumpdbDataSet.backup_locations' table. You can move, or remove it, as needed.
            this.backup_locationsTableAdapter.Fill(this.firedumpdbDataSet.backup_locations);
            // TODO: This line of code loads data into the 'firedumpdbDataSet.sqlservers' table. You can move, or remove it, as needed.
            this.mysql_serversTableAdapter.Fill(this.firedumpdbDataSet.sql_servers);

            cbEncryptedFile_CheckedChanged(null, null);
            cmbDatabases.DataSource = databases;
            cmbServers_SelectedIndexChanged(null, null);
        }

        private bool performChecks()
        {
            //checks before import here
            tb = tbFilePathFs;
            if(string.IsNullOrWhiteSpace(tbFilePathFs.Text) && string.IsNullOrWhiteSpace(tbFilePathSv.Text))
            {
                MessageBox.Show("No file selected", "Import SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(tbFilePathFs.Text))
            {
                tb = tbFilePathSv;
            }
            else if (string.IsNullOrWhiteSpace(tbFilePathSv.Text))
            {
                tb = tbFilePathFs;
            }
            else
            {
                MessageBox.Show("Both paths are set", "Import SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!(tb.Text.EndsWith(".sql")|| tb.Text.EndsWith(".7z") || tb.Text.EndsWith(".rar") || tb.Text.EndsWith(".gzip") || tb.Text.EndsWith(".zip") || tb.Text.EndsWith(".bzip2") || tb.Text.EndsWith(".tar") || tb.Text.EndsWith(".iso") || tb.Text.EndsWith(".udf")))
            {
                MessageBox.Show("File must end with one of these extensions:\n.sql .7z .rar .gzip .zip .bzip2 .tar .iso .udf", "Import SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (gbCompressed.Enabled)
            {
                if (cbEncryptedFile.Checked)
                {
                    isEncrypted = true;
                    if (string.IsNullOrWhiteSpace(tbPass.Text))
                    {
                        MessageBox.Show("Encyption is enabled and password field is empty or consists of only spaces", "Import SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if(tbPass.Text != tbConfirmPass.Text)
                    {
                        MessageBox.Show("Encyption is enabled and passwords do not match", "Import SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                isEncrypted = cbEncryptedFile.Checked;
            }
            else
            {
                isEncrypted = false;
            }
            return true;
        }

        private void bChoosePathSv_Click(object sender, EventArgs e)
        {
            if (cmbSaveLocations.Items.Count == 0) { MessageBox.Show("No save locations available.","File browser",MessageBoxButtons.OK,MessageBoxIcon.Error); return; }
            try
            {
                DataRow row = firedumpdbDataSet.backup_locations.Rows[cmbSaveLocations.SelectedIndex];
                long type = (Int64)row["service_type"];
                location = row;
                switch (type)
                {
                    case 0: //local
                        pathChooser(tbFilePathFs, tbFilePathSv);
                        break;
                    case 1: //ftp
                        FTPCredentialsConfig config = new FTPCredentialsConfig();
                        ((FTPCredentialsConfig)config).id = (Int64)row["id"];
                        ((FTPCredentialsConfig)config).host = (string)row["host"];
                        config.port = unchecked((int)(Int64)row["port"]);
                        config.username = (string)row["username"];
                        config.password = (string)row["password"];
                        Int64 useSFTP = (Int64)row["usesftp"];
                        if (useSFTP == 1)
                        {
                            ((FTPCredentialsConfig)config).useSFTP = true;
                            ((FTPCredentialsConfig)config).SshHostKeyFingerprint = (string)row["ssh_key_fingerprint"];
                        }
                        string keypath = (string)row["ssh_key"];
                        if (!string.IsNullOrEmpty(keypath))
                        {
                            ((FTPCredentialsConfig)config).usePrivateKey = true;
                            ((FTPCredentialsConfig)config).privateKeyPath = keypath;
                        }
                        FTPDirectory ftpdir = new FTPDirectory(false, config);
                        DialogResult res = ftpdir.ShowDialog();
                        if(res == DialogResult.OK)
                        {
                            tbFilePathFs.Text = "";
                            tbFilePathSv.Text = ftpdir.path;
                            isLocal = false;
                            checkCompressed(tbFilePathSv);
                        }
                                           
                        break; //set to is local kai check compressed mi ksexastoun apo katw
                    case 2: //dropbox
                        break;
                    case 3: //google drive
                        break;
                    default:
                        MessageBox.Show("Unknown save location type", "File browser", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error occured:\n"+ex.Message, "File browser", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkCompressed(TextBox settb)
        {
            if (settb.Text.EndsWith(".7z")||settb.Text.EndsWith(".rar") || settb.Text.EndsWith(".gzip") || settb.Text.EndsWith(".zip") || settb.Text.EndsWith(".bzip2") || settb.Text.EndsWith(".tar") || settb.Text.EndsWith(".iso") || settb.Text.EndsWith(".udf"))
            {
                gbCompressed.Enabled = true;
                isCompressed = true;
            }
            else
            {
                gbCompressed.Enabled = false;
            }
        }

        private void pathChooser(TextBox clearedtb, TextBox settb)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //.sql .7z .rar .gzip .zip .bzip2 .tar .iso .udf
            ofd.Filter = "All allowed types|*.sql;*.7z;*.rar;*.gzip;*.zip;*.bzip2;*.tar;*.iso;*.udf|" +
                "SQL files|*.sql|7z files|*.7z|Rar files|*.rar|Gzip files|*.gzip|Zip files|*.zip|Bzip2 files|*.bzip2|Tar files|*.tar|Iso files|*.iso|Udf files|*.udf";
            DialogResult res = ofd.ShowDialog();
            if (res == DialogResult.OK)
            {
                clearedtb.Text = "";
                settb.Text = ofd.FileName;
                isLocal = true;
                checkCompressed(settb);
            }        
        }

        private void bChoosePathFs_Click(object sender, EventArgs e)
        {
            pathChooser(tbFilePathSv,tbFilePathFs);
        }

        private void cbEncryptedFile_CheckedChanged(object sender, EventArgs e)
        {
            enableORDisablePasswords(cbEncryptedFile.Checked);
        }

        private void enableORDisablePasswords(bool action)
        {
            lPass.Enabled = action;
            lConfirmPass.Enabled = action;
            lPassHelp.Enabled = action;
            tbPass.Enabled = action;
            tbConfirmPass.Enabled = action;
        }

        private void cmbServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServers.Items.Count == 0) return;

            if (reloadDatabasesTask != null && !reloadDatabasesTask.IsCompleted) return;

            reloadDatabasesTask = new Task(reloadDatabasesCombobox);
            reloadDatabasesTask.Start();
        }

        private async void reloadDatabasesCombobox()
        {
            try
            {
                databases.Clear();

                int selectedindex = 0;
                cmbServers.Invoke((MethodInvoker)delegate () {
                    selectedindex = cmbServers.SelectedIndex;
                });

                DataRow row = firedumpdbDataSet.sql_servers.Rows[selectedindex];     
                string database = null;
                try
                {
                    database = (string)row["database"];
                }
                catch(Exception ex) {  }
                databases = new List<string>();
                databases.Add("none");

                if (!string.IsNullOrWhiteSpace(database))
                {
                    cmbDatabases.Invoke((MethodInvoker)delegate () {
                        cmbDatabases.DataSource = databases;
                    });
                    return;
                }
                List<string> tempdbs = DbUtils.getDatabases(new sqlservers((string)row["host"], unchecked((int)(Int64)row["port"]), (string)row["username"],
                    (string)row["password"]));//con.getDatabases();
                if (!cbShowSysDb.Checked)
                {
                    tempdbs.Remove("mysql");
                    tempdbs.Remove("information_schema");
                    tempdbs.Remove("performance_schema");
                }

                foreach (string db in tempdbs)
                {
                    databases.Add(db);
                }
                cmbDatabases.Invoke((MethodInvoker)delegate () {
                    cmbDatabases.DataSource = databases;
                });

            }
            catch (Exception ex)
            {
                if (cmbServers.IsDisposed) return; //sto kleisimo tou form erxetai edw den exw idea giati
                DialogResult res = MessageBox.Show("Databases load failed:\n"+ex.Message,"Databases load",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                if(res == DialogResult.Retry)
                {
                    reloadDatabasesTask = new Task(reloadDatabasesCombobox);
                    reloadDatabasesTask.Start();
                }
            }

        }

        private void tbConfirmPass_Leave(object sender, EventArgs e)
        {
            if (tbPass.Text != tbConfirmPass.Text) { lPassHelp.Visible = true; } else { lPassHelp.Visible = false; }
        }

        private void bStartImport_Click(object sender, EventArgs e)
        {
            if (!performChecks()) return;

            this.UseWaitCursor = true;
            bStartImport.Enabled = false;

            DataRow serverdata = firedumpdbDataSet.sql_servers.Rows[cmbServers.SelectedIndex];
            ImportCredentialsConfig config = new ImportCredentialsConfig();
            config.database = (string)serverdata["database"];
            if (cmbDatabases.SelectedIndex != 0)
            {
                config.database = (string)cmbDatabases.SelectedValue;
            }
            config.host = (string)serverdata["host"];
            config.password = (string)serverdata["password"];
            config.port = Convert.ToInt32((Int64)serverdata["port"]);
            config.username = (string)serverdata["username"];
            config.scriptDelimeter = tbDelimeter.Text;

            adapter = new ImportAdapterManager(tb.Text,isLocal,isCompressed,isEncrypted,tbConfirmPass.Text,location,config);
            adapter.ImportComplete += onImportCompleteHandler;
            adapter.ImportInit += onImportInitHandler;
            adapter.ImportError += onImportErrorHandler;
            adapter.ImportProgress += onImportProgressHandler;
            adapter.InnerProccessInit += onInnerProccessInitHandler;
            
            adapter.startImport();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = false;
            if (adapter != null)
            {
                adapter.cancel();
            }
        }

        private void cbShowSysDb_CheckedChanged(object sender, EventArgs e)
        {
            cmbServers_SelectedIndexChanged(null,null);
        }

        private void onInnerProccessInitHandler(int proc_type, int maxprogress)
        {
            switch (proc_type)
            {
                case 1: //ftp
                    this.Invoke((MethodInvoker)delegate () {
                        pbMainProgress.Maximum = maxprogress;
                        lbSpeed.Visible = true;
                        lbSpeed.Text = "";
                        lStatus.Text = "Status: Downloading (FTP)";
                    });
                    break;
                case 2: //dropbox
                    break;
                case 3: //google drive
                    break;
                case 10: //decompression
                    this.Invoke((MethodInvoker)delegate () {
                        pbMainProgress.Maximum = maxprogress;
                        lbSpeed.Visible = false;
                        lbSpeed.Text = "";
                        lStatus.Text = "Status: Decompressing...";
                    });
                    break;
            }
        }

        private void onImportInitHandler(int maxprogress)
        {
            this.Invoke((MethodInvoker)delegate () {
                pbMainProgress.Maximum = maxprogress;
                lbSpeed.Visible = false;
                lbSpeed.Text = "";
                lStatus.Text = "Status: Executing sql file...";
            });
        }

        private void onImportCompleteHandler(ImportResultSet result)
        {
            this.UseWaitCursor = false;
            this.Invoke((MethodInvoker)delegate () {
                pbMainProgress.Value = pbMainProgress.Maximum;
                lStatus.Text = "Status: Complete";
                bStartImport.Enabled = true;
            });
            
            //results handle
            if (result.wasSuccessful)
            {
                MessageBox.Show("Import completed successfuly!","SQL Import",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Import completed with errors:\n"+result.errorMessage, "SQL Import", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void setProgressValue(int progress)
        {
            pbMainProgress.Invoke((MethodInvoker)delegate () {
                try
                {
                    pbMainProgress.Value = progress;
                }
                catch(Exception ex) { }
            });
        }

        private void onImportProgressHandler(int progress, int speed)
        {
            setProgressValue(progress);
            if (speed == -1) { return; }
            string speedlabelext = "B/s";
            double tspeed = 0;
            if (speed <= 1050)
            {
                speedlabelext = "B/s";
                tspeed = speed;
            }
            else if (speed <= 1050000)
            {
                speedlabelext = "kB/s";
                tspeed = speed / 1000;
            }
            else
            {
                speedlabelext = "mB/s";
                tspeed = speed / 1000000;
            }
            string printedspeed = "";
            if (tspeed < 10)
            {
                //kanei format to double se ena dekadiko psifio se morfi string alliws den ginete stin c#
                printedspeed = string.Format("{0:0.0}", tspeed);
            }
            else
            {
                printedspeed = Convert.ToInt32(tspeed).ToString();
            }
            lbSpeed.Invoke((MethodInvoker)delegate () {
                lbSpeed.Text = printedspeed + " " + speedlabelext;
            });
        }

        private void onImportErrorHandler(string message)
        {
            this.UseWaitCursor = false;
            MessageBox.Show(message,"SQL import",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void onSaveLocationDeletedHandler(BackupLocation loc)
        {
            this.backup_locationsTableAdapter.Fill(this.firedumpdbDataSet.backup_locations);
            //EDW NA KANEI SELECT OTI ALLAKSE TELEUTAIO
        }

        private void onSaveLocationAddedHandler()
        {
            this.backup_locationsTableAdapter.Fill(this.firedumpdbDataSet.backup_locations);
            //gia na doulepsei edw prepei na allaksei kai stis klaseis pou epikoinwnoun me ti locationswitchboard
        }

        private void bManageSaveLocs_Click(object sender, EventArgs e)
        {
            LocationSwitchboard locswitch = new LocationSwitchboard(true);
            locswitch.SaveLocationAdded += onSaveLocationAddedHandler;
            locswitch.SaveLocationDeletedAfter += onSaveLocationDeletedHandler;
            locswitch.ShowDialog();
        }
    }
}
