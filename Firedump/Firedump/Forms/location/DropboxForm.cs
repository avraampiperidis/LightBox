using Dropbox.Api;
using Dropbox.Api.Files;
using Dropbox.Api.Users;
using Firedump.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.location
{
    public partial class DropboxForm : Form
    {
        private string token = "";
        //empty string is also root path at dropbox
        private string path = "";
        private LocationSwitchboard locswitch;
        private DropboxClient dbx;
        private FullAccount fullAccount;
        private List<DropBoxItem> boxItems = new List<DropBoxItem>();
        private bool isEditor;
        private firedumpdbDataSet.backup_locationsRow row;

        public DropboxForm(LocationSwitchboard locswitch,bool isedit, firedumpdbDataSet.backup_locationsRow row)
        {
            InitializeComponent();
            isEditor = isedit;
            this.locswitch = locswitch;
            this.row = row;

            Console.WriteLine(row.access_token);
            tbtoken.Text = row.access_token;
            tbfilename.Text = row.filename;
            tbsavename.Text = row.name;
            path = row.path;
            init();

            if (String.IsNullOrEmpty(tbtoken.Text))
            {
                MessageBox.Show("Must fill token field, visit https://www.dropbox.com/developers/apps to create app and get the token");
                return;
            }
            //save token

            if (!backgroundWorker1.IsBusy)
            {
                this.UseWaitCursor = true;
                token = tbtoken.Text;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        public DropboxForm(LocationSwitchboard locswitch)
        {
            InitializeComponent();
            this.locswitch = locswitch;
            init();
        }


        private void init()
        {
            backgroundWorker1.DoWork += connect;

            ImageList smallimagelist = new ImageList();
            smallimagelist.Images.Add(Bitmap.FromFile("resources\\icons\\folderimage.bmp"));
            smallimagelist.Images.Add(Bitmap.FromFile("resources\\icons\\fileimage.bmp"));
            listView1.SmallImageList = smallimagelist;
        }


        private async void connect(object sender, DoWorkEventArgs e) 
        {
            dbx = new DropboxClient(token);

            try {
                fullAccount = await dbx.Users.GetCurrentAccountAsync();

                boxItems.Clear();
                this.Invoke((MethodInvoker)delegate () {
                    linfo.Text = "Name:" + fullAccount.Name.DisplayName + "  Email:" + fullAccount.Email;
                    listView1.Items.Clear();
                });
                
                var list = await dbx.Files.ListFolderAsync(path);
                foreach (var item in list.Entries.Where(i => i.IsFolder))
                {
                    DropBoxItem boxitem = new DropBoxItem();
                    boxitem.Name = item.Name;
                    boxitem.IsDeleted = item.IsDeleted;
                    boxitem.IsFile = item.IsFile;
                    boxitem.IsFolder = item.IsFolder;
                    boxitem.ParentShareFolderId = item.ParentSharedFolderId;
                    boxitem.PathDisplay = item.PathDisplay;
                    boxitem.PathLower = item.PathLower;
                    boxitem.Tag = item;
                    int imageindex = 0;
                    ListViewItem listItem = new ListViewItem(boxitem.Name, imageindex);
                    listItem.Tag = boxitem;
                   
                    this.Invoke((MethodInvoker)delegate () {
                        listView1.Items.Add(listItem);
                    });
                    
                    boxItems.Add(boxitem);                  
                }

                foreach (var item in list.Entries.Where(i => i.IsFile))
                {
                    DropBoxItem boxitem = new DropBoxItem();
                    boxitem.Name = item.Name;
                    boxitem.IsDeleted = item.IsDeleted;
                    boxitem.IsFile = item.IsFile;
                    boxitem.IsFolder = item.IsFolder;
                    boxitem.ParentShareFolderId = item.ParentSharedFolderId;
                    boxitem.PathDisplay = item.PathDisplay;
                    boxitem.PathLower = item.PathLower;
                    boxitem.Size = (int)(item.AsFile.Size/8);
                    boxitem.Tag = item;
                    
                    int imageindex = 1;
                    ListViewItem listItem = new ListViewItem(boxitem.Name, imageindex);
                    listItem.Tag = boxitem;
                    listItem.SubItems.Add(boxitem.Size.ToString());

                    this.Invoke((MethodInvoker)delegate () {
                        listView1.Items.Add(listItem);
                    });
                    boxItems.Add(boxitem);
                }

                this.UseWaitCursor = false;
            }
            catch(Exception ex)
            {
                this.UseWaitCursor = false;
                MessageBox.Show(ex.Message);
            }     
        }

        private void bsaveconnect_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbtoken.Text))
            {
                MessageBox.Show("Must fill token field, visit https://www.dropbox.com/developers/apps to create app and get the token");
                return;
            }
            //save token

            if (!backgroundWorker1.IsBusy)
            {
                this.UseWaitCursor = true;
                token = tbtoken.Text;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void DropboxForm_Load(object sender, EventArgs e)
        {
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            Process.Start("IExplore.exe", "https://www.dropbox.com/developers/apps");
        }



        private class DropBoxItem
        {

            public DropBoxItem() { }

            public bool IsDeleted { get; set; }

            public bool IsFile { get; set; }

            public bool IsFolder { get; set; }

            public string Name { get; set; }

            public string ParentShareFolderId { get; set; }

            public string PathDisplay { get; set; }

            public string PathLower { get; set; }

            public int Size { get; set; }

            public object Tag { get; set; }


            public override string ToString()
            {
                return Name + " " + PathDisplay;
            }

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DropBoxItem boxitem = (DropBoxItem)listView1.SelectedItems[0].Tag;
            if (boxitem.IsFolder)
            {
                path = boxitem.PathDisplay;
                if (!backgroundWorker1.IsBusy)
                {
                    this.UseWaitCursor = true;
                    token = tbtoken.Text;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void btback_Click(object sender, EventArgs e)
        {
            path = "";
            if (!backgroundWorker1.IsBusy)
            {
                this.UseWaitCursor = true;
                token = tbtoken.Text;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnsavelocation_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbfilename.Text) || String.IsNullOrEmpty(tbsavename.Text))
            {
                MessageBox.Show("Must provide fileName and SaveName to save");
                return;
            }

            try {
                firedumpdbDataSetTableAdapters.backup_locationsTableAdapter backup_adapter = new firedumpdbDataSetTableAdapters.backup_locationsTableAdapter();
                if (isEditor)
                {
                    backup_adapter.Update(tbsavename.Text, "", "", path, tbfilename.Text, (int)ServiceType.Type.DropBox, 0, "", "", "", "", "", "", "", 0, 0, tbtoken.Text, "", 0, "", 0,row.id);
                }
                else
                {
                    backup_adapter.Insert(tbsavename.Text,"","",path,tbfilename.Text,(int)ServiceType.Type.DropBox,0,"","","","","","","",0,0,tbtoken.Text,"",0,"",0);
                }

                locswitch.reloadDataset();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not save , error!");
            }
        }
    }
}
