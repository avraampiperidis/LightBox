using Firedump.models;
using Firedump.models.location;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.location
{
    public partial class FileSystem : Form
    {
        private LocationSwitchboard locswitch;
        private DataRow locallocation;
        private firedumpdbDataSetTableAdapters.backup_locationsTableAdapter adapter;
        public bool isEditor { set; get; }
        public bool loadData { set; get; }
        private FileSystem() { }
        public FileSystem(LocationSwitchboard locswitch)
        {
            InitializeComponent();
            this.locswitch = locswitch;
        }
        public FileSystem(LocationSwitchboard locswitch, bool isEditor, DataRow locallocation)
        {
            InitializeComponent();
            this.locswitch = locswitch;
            this.isEditor = isEditor;
            this.locallocation = locallocation;
            loadData = true;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Please enter a valid name for the enw file location","New file system location",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            try
            {
                Path.IsPathRooted(tbPath.Text);
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show("Please choose a valid path", "New file system location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            adapter = new firedumpdbDataSetTableAdapters.backup_locationsTableAdapter();
            if ((Int64)adapter.numberOfOccurances(tbName.Text) != 0)
            {
                MessageBox.Show("A save location with this name already exists", "New file system location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (isEditor)
                {
                    adapter.Update(tbName.Text, "", "", tbPath.Text, "", (int)ServiceType.Type.Local, 0, "", "", "", "", "", "", "", 0, 0, "", "", 0, "", 0, (Int64)locallocation["id"]);
                }
                else
                {
                    adapter.Insert(tbName.Text, "", "", tbPath.Text, "", (int)ServiceType.Type.Local, 0, "", "", "", "", "", "", "", 0, 0, "", "", 0, "", 0);
                }                
                locswitch.reloadDataset(); //callback stin klasi pou to kalese na kanei refresh to combobox
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error occured trying to save to the database:\n" + ex.Message, "File system Location Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                     

        }

        private void bPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            //sfd.DefaultExt = ".sql";
            //sfd.Filter = "SQL file (*.sql)|*.sql|XML file (*.xml)|*.xml";
            sfd.Filter = "All Files (Do not add extension it will be automatically added)|*";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = sfd.FileName;
            }
            
        }

        private void FileSystem_Load(object sender, EventArgs e)
        {
            if (loadData)
            {
                try
                {
                    tbName.Text = (string)locallocation["name"];
                    tbPath.Text = (string)locallocation["path"];
                }
                catch(InvalidCastException ex)
                {
                    MessageBox.Show("Error occured trying to load from the database:\n" + ex.Message, "File system Location Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
