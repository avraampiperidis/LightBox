using Firedump.models.location;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.location
{
    public partial class LocationSwitchboard : Form
    {
        //<events>
        public delegate void saveLocationAdded();
        public event saveLocationAdded SaveLocationAdded;
        private void onSaveLocationAdded()
        {
            SaveLocationAdded?.Invoke();
        }

        public delegate void saveLocationDeleted(BackupLocation loc);
        public event saveLocationDeleted SaveLocationDeleted;
        private void onSaveLocationDeleted(BackupLocation loc)
        {
            SaveLocationDeleted?.Invoke(loc);
        }

        public delegate void saveLocationDeletedAfter(BackupLocation loc);
        public event saveLocationDeletedAfter SaveLocationDeletedAfter;
        private void onSaveLocationDeletedAfter(BackupLocation loc)
        {
            SaveLocationDeletedAfter?.Invoke(loc);
        }

        public delegate void saveLocationEdited(BackupLocation loc);
        public event saveLocationEdited SaveLocationEdited;
        private void onSaveLocationEdited(BackupLocation loc)
        {
            SaveLocationEdited?.Invoke(loc);
        }

        public delegate void addSaveLocation(BackupLocation loc);
        public event addSaveLocation AddSaveLocation;
        private void onAddSaveLocation(BackupLocation loc)
        {
            AddSaveLocation?.Invoke(loc);
        }

        //</events>
        public LocationSwitchboard() { InitializeComponent(); }
        public LocationSwitchboard(bool isManager)
        {
            InitializeComponent();
            if (isManager) bAdd.Visible = false;
        }

        private void bFileSystem_Click(object sender, EventArgs e)
        {
            FileSystem fs = new FileSystem(this);
            fs.ShowDialog();
        }

        public void reloadDataset()
        {
            this.backup_locationsTableAdapter.Fill(this.firedumpdbDataSet.backup_locations);
            try //AFTO EDW THELEI ALLAGI
            {
                cmbName.SelectedIndex = cmbName.Items.Count - 1;
            }
            catch (Exception ex)
            {

            }
            onSaveLocationAdded();
        }

        private void reloadPath()
        {
            if (cmbName.Items.Count == 0 || cmbName.SelectedIndex == -1)
            {
                return;
            }
            tbPath.Text = (string)firedumpdbDataSet.backup_locations.Rows.Find((Int64)cmbName.SelectedValue)["path"];
        }

        private void LocationSwitchboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'firedumpdbDataSet.backup_locations' table. You can move, or remove it, as needed.
            this.backup_locationsTableAdapter.Fill(this.firedumpdbDataSet.backup_locations);
            
            if (cmbName.Items.Count != 0)
            {
                cmbName.SelectedIndex = 0;
            }
            reloadPath();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if(cmbName.Items.Count==0 || cmbName.SelectedIndex == -1)
            {
                return;
            }
            try
            {
                BackupLocation loc = new BackupLocation();
                loc.id = unchecked((int)(Int64)cmbName.SelectedValue);
                loc.Tag = findRow(loc.id);
                DialogResult res = MessageBox.Show("Are you sure you want to delete save location: "+ ((firedumpdbDataSet.backup_locationsRow)loc.Tag).name, "Delete Save Location", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res != DialogResult.Yes)
                {
                    return;
                }
                onSaveLocationDeleted(loc);
                this.backup_locationsTableAdapter.DeleteQuery((Int64)cmbName.SelectedValue);
                this.backup_locationsTableAdapter.Fill(this.firedumpdbDataSet.backup_locations);
                onSaveLocationDeletedAfter(loc);
                reloadPath();
            }catch(Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        private firedumpdbDataSet.backup_locationsRow findRow(int id)
        {
            return firedumpdbDataSet.backup_locations.Where(i => i.id == id)
                .DefaultIfEmpty(firedumpdbDataSet.backup_locations[0]).First();
            // LOLLED 

            //int i = 0;
            //bool foundflag = false;
            //firedumpdbDataSet.backup_locationsRow row = firedumpdbDataSet.backup_locations[0];
            //while (!foundflag && i < firedumpdbDataSet.backup_locations.Count)
            //{
            //    firedumpdbDataSet.backup_locationsRow temprow = firedumpdbDataSet.backup_locations[i];
            //    if (temprow.id == id)
            //    {
            //        row = temprow;
            //        foundflag = true;
            //    }
            //    i++;
            //}
            //return row;

        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadPath();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (cmbName.Items.Count == 0 || cmbName.SelectedIndex == -1)
            {
                MessageBox.Show("There are no save locations. Please create a new save location and try again.", "Add save location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Console.WriteLine(cmbName.SelectedValue);
            BackupLocation loc = new BackupLocation();
            loc.id = unchecked((int)(Int64)cmbName.SelectedValue);
            loc.path = tbPath.Text;
            loc.Tag = findRow(loc.id);
            onAddSaveLocation(loc);           
        }

        private void bFTP_Click(object sender, EventArgs e)
        {
            new FTPLocation(this).ShowDialog();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if(cmbName.Items.Count == 0)
            {
                MessageBox.Show("No save locations to edit. Add a new save location.","Edit save location",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            DataRow row = ((DataRowView)cmbName.Items[cmbName.SelectedIndex]).Row;
            switch ((Int64)row["service_type"])
            {
                case 0: //local
                    FileSystem fs = new FileSystem(this, true, row);
                    fs.ShowDialog();
                    break;
                case 1: //ftp
                    FTPLocation ftploc = new FTPLocation(this, true, row);
                    ftploc.ShowDialog();
                    break;
                case 2: //dropbox
                    DropboxForm boxform = new DropboxForm(this,true,(firedumpdbDataSet.backup_locationsRow)row);
                    boxform.Show();
                    break;
                case 3: //google drive
                    break;
                default: //error
                    MessageBox.Show("Unknown location service type", "Edit save location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            
        }

        private void bDropbox_Click(object sender, EventArgs e)
        {
            new DropboxForm(this).Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new FileSystem(this).ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new DropboxForm(this).Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new FTPLocation(this).ShowDialog();
        }

        private void bGoogleDrive_Click(object sender, EventArgs e)
        {
            new GoogleDriveForm().Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new GoogleDriveForm().Show();
        }
    }
}
