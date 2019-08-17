using Firedump.models.configuration.dynamicconfig;
using Firedump.models.location;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firedump.models;
using Firedump.utils.encryption;

namespace Firedump.Forms.location
{
    public partial class FTPLocation : Form
    {
        private LocationSwitchboard listener;
        private LocationAdapter adapter;
        private string sshKeyFingerprint = "";
        public DataRow ftplocation { set; get; }
        bool testConnectionSucceded = false;
        public bool isEditor { set; get; }
        public bool doLoadConfig { set; get; }
        private FTPLocation()
        {
        }

        public FTPLocation(LocationSwitchboard listener) : this()
        {
            InitializeComponent();
            this.listener = listener;
            adapter = new LocationAdapter();
            adapter.SaveError += onSaveErrorHandler;
            adapter.TestConnectionComplete += onTestConnectionCompleteHandler;
        }
        /// <summary>
        /// Call this constructor to load FTPconfig into the components
        /// </summary>
        /// <param name="listener">The Location switchboard instance</param>
        /// <param name="isEditor">If true on save it will try to update the save location when Save is clicked else it will try to insert</param>
        /// <param name="ftplocation">DataRow from backup_locations table that contains the ftp location to load</param>
        public FTPLocation(LocationSwitchboard listener, bool isEditor, DataRow ftplocation) : this()
        {
            InitializeComponent();
            this.listener = listener;
            this.isEditor = isEditor;
            this.ftplocation = ftplocation;
            doLoadConfig = true;
            adapter = new LocationAdapter();
            adapter.SaveError += onSaveErrorHandler;
            adapter.TestConnectionComplete += onTestConnectionCompleteHandler;
        }

        private bool performChecks(bool isSave)
        {
            //port
            if (!string.IsNullOrEmpty(tbPort.Text))
            {
                try
                {
                    int port = int.Parse(tbPort.Text);
                    if (port < 1 || port > 65535)
                    {
                        MessageBox.Show(tbPort.Text + " is not a valid port number", "FTP Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(tbPort.Text + " is not a valid port number", "FTP Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            //host
            if (string.IsNullOrEmpty(tbHost.Text))
            {
                MessageBox.Show("Hostname is empty.", "FTP Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //username
            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                MessageBox.Show("Username is empty.", "FTP Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //private key
            if (cbPrivateKey.Checked)
            {
                if (string.IsNullOrWhiteSpace(tbPrivateKey.Text))
                {
                    MessageBox.Show("Private key is enabled but path is not set.", "FTP Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (isSave)
            {
                if (string.IsNullOrWhiteSpace(tbFilename.Text))
                {
                    MessageBox.Show("Please enter a filename", "FTP Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    // LOLLED

                    //bool containsForbiddenChars = false;
                    //char thechar = 'a';
                    //char[] forbiddenchars = { '<', '>', ':', '"', '/', '\\', '|', '?', '*', ' ', '\0', '`', ';' };
                    //int i = 0;
                    //while (!containsForbiddenChars && i < forbiddenchars.Length)
                    //{
                    //    if (tbFilename.Text.Contains(forbiddenchars[i]))
                    //    {
                    //        containsForbiddenChars = true;
                    //        thechar = forbiddenchars[i];
                    //    }
                    //    i++;
                    //}
                    char[] forbiddenchars = { '<','>',':','"','/','\\','|','?','*',' ','\0','`',';'};
                    int index = tbFilename.Text.IndexOfAny(forbiddenchars);
                    if (index != -1)
                    {
                        MessageBox.Show("Char: "+ forbiddenchars[index]+ " in the filename is forbidden", "FTP Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (tbFilename.Text.StartsWith("-"))
                    {
                        MessageBox.Show("Filename must not start with -", "FTP Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (string.IsNullOrWhiteSpace(tbChooseAPath.Text))
                {
                    MessageBox.Show("Please choose a path", "FTP Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e) 
        {
            if (!performChecks(true)) return;

            if (!testConnectionSucceded)
            {
                DialogResult res = MessageBox.Show("Connection wasn't tested or the test wasn't successful. Save anyway?","FTP Location Save",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(res != DialogResult.Yes)
                {
                    return;
                }
            }

            firedumpdbDataSetTableAdapters.backup_locationsTableAdapter backup_adapter = new firedumpdbDataSetTableAdapters.backup_locationsTableAdapter();
            int protocol = cmbProtocol.SelectedIndex;
            try
            {
                String passwd = EncryptionUtils.sEncrypt(tbPassword.Text);
                if (isEditor)
                {
                    backup_adapter.Update(tbName.Text, tbUsername.Text, passwd, tbChooseAPath.Text, tbFilename.Text, (int)ServiceType.Type.Ftp, protocol, tbPrivateKey.Text, sshKeyFingerprint, "", "", "", "", "", 0, 0, "", "", Convert.ToInt64(tbPort.Text), tbHost.Text, protocol, (Int64)ftplocation["id"]);
                }
                else
                {
                    backup_adapter.Insert(tbName.Text, tbUsername.Text, passwd, tbChooseAPath.Text, tbFilename.Text, (int)ServiceType.Type.Ftp, protocol, tbPrivateKey.Text, sshKeyFingerprint, "", "", "", "", "", 0, 0, "", "", Convert.ToInt64(tbPort.Text), tbHost.Text, protocol);
                }
                listener.reloadDataset();
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("Error occured trying to save:\n"+ex.Message, "FTP Location Save",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void bPrivateKeyPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Private Key Files|*.ppk";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbPrivateKey.Text = ofd.FileName;
            }
        }


        private void bPathOnServer_Click(object sender, EventArgs e)
        {
            FTPDirectory ftpdirectory = new FTPDirectory(true, new FTPCredentialsConfig(tbHost.Text, Convert.ToInt32(tbPort.Text),
                cbPrivateKey.Checked, tbPrivateKey.Text, sshKeyFingerprint,
                tbUsername.Text, tbPassword.Text, cmbProtocol.SelectedIndex == 1 ? true : false));
            if(!String.IsNullOrEmpty(tbChooseAPath.Text))
            {
                ftpdirectory.path = tbChooseAPath.Text;
            }

            DialogResult res = ftpdirectory.ShowDialog();
            if(res == DialogResult.OK && !string.IsNullOrEmpty(ftpdirectory.path))
            {               
                bool isDirectory = ftpdirectory.isDirectory;
                //an den einai pare to telefteo filename
                if(!isDirectory)
                {
                    tbFilename.Text = ftpdirectory.path.Substring(ftpdirectory.path.LastIndexOf('/')+1);
                    tbChooseAPath.Text = ftpdirectory.path.Substring(0, ftpdirectory.path.LastIndexOf('/'));
                    if (!tbChooseAPath.Text.EndsWith("/"))
                        tbChooseAPath.Text = tbChooseAPath.Text + "/";
                } else
                {
                    tbChooseAPath.Text = ftpdirectory.path;
                    if (!tbChooseAPath.Text.EndsWith("/"))
                        tbChooseAPath.Text = tbChooseAPath.Text + "/";
                }
            }

          
        }

        private void cbPrivateKey_CheckedChanged(object sender, EventArgs e)
        {
            enableOrDisablePrivateKey(cbPrivateKey.Checked);
        }

        private void FTPLocation_Load(object sender, EventArgs e)
        {
            //Init Compronents
            cmbProtocol.DataSource = new string[] { "FTP", "SFTP"};
            cmbProtocol.SelectedIndex = 1;
            setPort();
            enableOrDisablePrivateKey(cbPrivateKey.Checked);

            if (!doLoadConfig) return;

            //EDW LOAD TO CONFIG STA COMPONENTS
            if (ftplocation == null)
            {
                Console.WriteLine("FTPLocation: ftplocation not set cannot load config!");
                return;
            }
            try
            {
                tbName.Text = (string)ftplocation["name"];
                Int64 usesftp = (Int64)ftplocation["usesftp"];
                switch (usesftp)
                {
                    case 0:
                        cmbProtocol.SelectedIndex = 0;
                        break;
                    case 1:
                        cmbProtocol.SelectedIndex = 1;
                        break;
                    default:
                        cmbProtocol.SelectedIndex = 0;
                        break;
                }
                string privateKey = (string)ftplocation["ssh_key"];
                if (!string.IsNullOrEmpty(privateKey))
                {
                    cbPrivateKey.Checked = true;
                    tbPrivateKey.Text = privateKey;
                }
                tbPort.Text = Convert.ToString((Int64)ftplocation["port"]);
                tbHost.Text = (string)ftplocation["host"];
                tbUsername.Text = (string)ftplocation["username"];
                tbPassword.Text = EncryptionUtils.sDecrypt((string)ftplocation["password"]);
                tbFilename.Text = (string)ftplocation["filename"];
                tbChooseAPath.Text = (string)ftplocation["path"];
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Error occured trying to load from the database:\n" + ex.Message, "FTP Location Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            setPort();
            enableOrDisablePrivateKey(cbPrivateKey.Checked);
        }

        private void enableOrDisablePrivateKey(bool action)
        {
            lbPrivateKey.Enabled = action;
            tbPrivateKey.Enabled = action;
            bPrivateKeyPath.Enabled = action;
        }

        private void setPort()
        {
            if (string.IsNullOrWhiteSpace(tbPort.Text) || tbPort.Text == "21" || tbPort.Text == "22")
            {
                tbPort.Text = cmbProtocol.SelectedIndex == 1 ? "22" : "21";
            }
        }

        private void cmbProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            setPort();
        }

        private void bTestConnection_Click(object sender, EventArgs e)
        {
            if (!performChecks(false))
                return;
            this.UseWaitCursor = true;
            adapter.setFtpLocation(new FTPCredentialsConfig(tbHost.Text, Convert.ToInt32(tbPort.Text),
                cbPrivateKey.Checked, tbPrivateKey.Text, sshKeyFingerprint,
                tbUsername.Text, tbPassword.Text, cmbProtocol.SelectedIndex == 1 ? true : false));
            adapter.testConnection();
        }

        private void onSaveErrorHandler(string message)
        {
            this.UseWaitCursor = false;
            MessageBox.Show(message, "FTP test connection", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void onTestConnectionCompleteHandler(LocationConnectionResultSet result)
        {
            this.UseWaitCursor = false;
            if (result.wasSuccessful)
            {
                sshKeyFingerprint = result.sshHostKeyFingerprint;
                testConnectionSucceded = true;
                MessageBox.Show("Connection successful!","FTP test connection",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Connection failed:\n"+result.errorMessage, "FTP test connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
