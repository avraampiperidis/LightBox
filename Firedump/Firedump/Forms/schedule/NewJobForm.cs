using Firedump.models.databaseUtils;
using Firedump.models.db;
using Firedump.models.dbUtils;
using Firedump.models.pojos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.schedule
{
    public partial class NewJobForm : Form
    {
        public delegate void onSetJobDetails(JobDetail jobDetail);
        public event onSetJobDetails setJobDetails;
        private List<string> tables;
        private firedumpdbDataSet.backup_locationsDataTable loctable;

        private void OnSetJobDetails(JobDetail jobDetail)
        {
            setJobDetails?.Invoke(jobDetail);
        }

        private firedumpdbDataSet.sql_serversDataTable serverData;
        private firedumpdbDataSetTableAdapters.sql_serversTableAdapter mysql_serversAdapter = new firedumpdbDataSetTableAdapters.sql_serversTableAdapter();

        public NewJobForm()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += fillDatabaseCmb;
            loadComboBoxServers();
            loadlocationsCombobox();      
        }

        private void loadlocationsCombobox()
        {
            firedumpdbDataSetTableAdapters.backup_locationsTableAdapter locAdapter = new firedumpdbDataSetTableAdapters.backup_locationsTableAdapter();
            loctable = new firedumpdbDataSet.backup_locationsDataTable();
            locAdapter.Fill(loctable);
            cblocation.DataSource = loctable;
            cblocation.DisplayMember = "name";
            cblocation.ValueMember = "id";        
            if(cblocation.Items.Count > 0)
            {
                cblocation.SelectedIndex = 0;
            }
        }

        private void loadComboBoxServers()
        {
            serverData = new firedumpdbDataSet.sql_serversDataTable();
            mysql_serversAdapter = new firedumpdbDataSetTableAdapters.sql_serversTableAdapter();
            mysql_serversAdapter.Fill(serverData);
            cmbServers.DataSource = serverData;
            cmbServers.DisplayMember = "name";
            cmbServers.ValueMember = "id";
            if (cmbServers.Items.Count > 0)
            {
                cmbServers.SelectedIndex = 0;
                //backgroundWorker1.RunWorkerAsync();
                fillDatabaseCmb(null,null);
            }
        }


        private void setjobclick(object sender, EventArgs e)
        {
            
            //validate inputs
            //check if other schedule is in same minute.
            string jobname = tbjobname.Text;
            if (String.IsNullOrEmpty(jobname))
            {
                MessageBox.Show("Job must have a Name!");
                return;
            }

            if(cblocation.Items.Count <= 0)
            {
                MessageBox.Show("No destination location set!");
                return;
            }

            int day = (int)numericDay.Value;
            int hour = (int)numericHour.Value;
            int minute = (int)numericMinute.Value;
            if (!isTimeValid(day, hour, minute))
            {
                MessageBox.Show("Cant set this!Other Job is with Same Date/Time");
                return;
            }

            try {
                if (DB.TestConnection(this.getServerFromUI()).wasSuccessful)
                {
                    MySqlConnection con = (MySqlConnection)DB.connect(this.getServerFromUI());
                    tables = DbUtils.getTables(this.getServerFromUI(), cmbdatabase.SelectedItem.ToString(),con);
                    string locname = (string)loctable.Rows[cblocation.SelectedIndex]["name"];
                    int id = int.Parse(loctable.Rows[cblocation.SelectedIndex]["id"].ToString());
                    JobDetail jobdetails = new JobDetail();
                    jobdetails.DayOfWeek = day;
                    jobdetails.Hour = hour;
                    jobdetails.Minute = minute;
                    jobdetails.Name = jobname;
                    jobdetails.Database = cmbdatabase.SelectedItem.ToString();
                    jobdetails.Tables = tables;
                    jobdetails.Server = (firedumpdbDataSet.sql_serversRow)serverData.Rows[cmbServers.SelectedIndex];
                    jobdetails.LocationId = id;
                    jobdetails.LocationName = locname;
                    int activate = 0;
                    if (!cbactivate.Checked)
                        activate = 1;
                    jobdetails.Activate = activate;

                    OnSetJobDetails(jobdetails);
                    DB.close(con);
                    this.Close();
                } else
                {
                    MessageBox.Show("Error connection to server");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }    

        }


        private bool isTimeValid(int day, int hour, int minute)
        {

            firedumpdbDataSetTableAdapters.schedulesTableAdapter scheduleAdapter = new firedumpdbDataSetTableAdapters.schedulesTableAdapter();
            firedumpdbDataSet.schedulesDataTable scheduletable = new firedumpdbDataSet.schedulesDataTable();
            scheduleAdapter.FillOrderByDate(scheduletable);
            if(scheduletable.Count > 0)
            {
                foreach(firedumpdbDataSet.schedulesRow row in scheduletable)
                {
                    if (isScheduleOverLap(row, day, hour, minute))
                        return false;
                }
            }

            return true;
        }

        private bool isScheduleOverLap(firedumpdbDataSet.schedulesRow row,int day,int hour,int minute)
        {
            if (row.day == day && row.hours == hour && row.minutes == minute)
                return true;
            return false;
        }

        private void fillDatabaseCmb(object sender, DoWorkEventArgs args)
        {
            
            if (cmbServers.Items.Count == 0) { return; } //ama den iparxei kanenas server den to kanei           
            
            //edw prepei na bei to database kai mia if then else apo katw analoga ama kanei OldMySqlConnect se server i se database
            try {
                ConnectionResultSet result = DB.TestConnection(this.getServerFromUI());//con.testConnection();
                if (result.wasSuccessful)
                {
                    using (var con = DB.connect(this.getServerFromUI()))
                    {
                        List<string> databases = DbUtils.getDatabases(this.getServerFromUI());
                        databases.Remove("information_schema");
                        databases.Remove("mysql");
                        databases.Remove("performance_schema");
                        databases.Remove("sys");
                        cmbdatabase.Items.Clear();
                        foreach (string database in databases)
                        {
                            TreeNode node = new TreeNode(database);
                            node.ImageIndex = 0;
                            cmbdatabase.Items.Add(database);
                            Console.WriteLine(database);
                        }
                        if (cmbdatabase.Items.Count > 0)
                            cmbdatabase.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Connection failed: \n" + result.errorMessage, "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmbServers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fillDatabaseCmb(null, null);

        }

        private sqlservers getServerFromUI()
        {
            return new sqlservers((string)serverData.Rows[cmbServers.SelectedIndex]["host"], unchecked((int)(long)serverData.Rows[cmbServers.SelectedIndex]["port"]),
                (string)serverData.Rows[cmbServers.SelectedIndex]["username"], (string)serverData.Rows[cmbServers.SelectedIndex]["password"]);
        }
    }
}
