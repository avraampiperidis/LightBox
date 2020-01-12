using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Firedump.core;
using Firedump.core.db;
using Firedump.core.sql;

namespace Firedump.usercontrols
{
    public sealed partial class TabView : UserControlReference
    {
       
        public TabView(IParentRef parent):base(parent)
        {
            InitializeComponent();
        }

        public void setServerDataToComboBox(List<string> databases)
        {
            this.comboBoxServers.BeginUpdate();
            this.comboBoxServers.Items.Clear();
            this.comboBoxServers.Items.AddRange(databases.ToArray());
            if(this.comboBoxServers.Items.Count > 0)
            {
                this.comboBoxServers.SelectedItem = this.comboBoxServers.Items[0];
            }
            this.comboBoxServers.EndUpdate();
        }

        private void ComboBoxServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setDatabaseAndInitTabControls(comboBoxServers.SelectedItem.ToString());
        }

        private void setDatabaseAndInitTabControls(string database)
        {
            base.changeDatabase(database);
            this.initTabControl();
        }


        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.initTabControl();
        }


        // On tab select set the data.
        private void initTabControl()
        {
            if (this.checkConnection())
            {
                string tab = tabControl1.SelectedTab.Text;
                switch(tab)
                {
                    case "Tables":
                        this.setDatagridviewTables();
                        break;
                    case "Indexes":
                        this.setDataGridViewIndexes();
                        break;
                    case "Triggers":
                        this.setDataGridTriggers();
                        break;
                    case "Procedures":
                        this.setDataGridProcedures();
                        break;
                    case "PKs":
                        this.setDataGridViewPKs();
                        break;
                    case "UKs":
                        this.setDataGridUniques();
                        break;
                    case "FKs":
                        this.setDataGridFKs();
                        break;
                    case "Functions":
                        this.setDataGridFunctions();
                        break;
                    case "Views":
                        this.setDatagridViews();
                        break;
                }
            }
        }

        private void setDatagridviewTables()
        {
            SqlBuilderFactory sqlFactory = new SqlBuilderFactory(GetServer());
            ISqlBuilder sqlBuilder = sqlFactory.Create(GetSqlConnection().Database);
            dataGridViewTables.DataSource = DbUtils.getDataTableData(GetSqlConnection(),
                sqlBuilder.getDatabaseTables());
        }
    

        private void setDataGridViewIndexes()
        {
            dataGridViewIndexes.DataSource = DbUtils.getDataTableData(GetSqlConnection(),
                new SqlBuilderFactory(GetServer()).Create(GetSqlConnection().Database).createDatabaseIndexes());
        }

        private void setDataGridViewPKs()
        {
            dataGridViewPKs.DataSource = DbUtils.getDataTableData(GetSqlConnection(),
               new SqlBuilderFactory(GetServer()).Create(GetSqlConnection().Database).getDatabasePrimaryKeys());
        }

        private void setDataGridUniques()
        {
            dataGridViewUnique.DataSource = DbUtils.getDataTableData(GetSqlConnection(),
               new SqlBuilderFactory(GetServer()).Create(GetSqlConnection().Database).getDatabaseUniques());
        }

        private void setDataGridFKs()
        {
            dataGridViewFKs.DataSource = DbUtils.getDataTableData(GetSqlConnection(),
               new SqlBuilderFactory(GetServer()).Create(GetSqlConnection().Database).getDatabaseForeignKeys());
        }

        private void setDataGridTriggers()
        {
            dataGridViewTrigger.DataSource = DbUtils.getDataTableData(GetSqlConnection(), "show triggers");
        }

        private void setDataGridProcedures()
        {
            dataGridViewProcedures.DataSource = DbUtils.getDataTableData(GetSqlConnection(), "SHOW PROCEDURE STATUS WHERE Db = '"+ GetSqlConnection().Database+"'");
        }

        private void setDataGridFunctions()
        {
            dataGridViewFunctions.DataSource = DbUtils.getDataTableData(GetSqlConnection(), "SHOW FUNCTION STATUS WHERE Db = '" + GetSqlConnection().Database + "'");
        }

        private void setDatagridViews()
        {
            dataGridViewView.DataSource = DbUtils.getDataTableData(GetSqlConnection(), "SHOW FULL TABLES IN "+ GetSqlConnection().Database+" WHERE TABLE_TYPE LIKE 'VIEW';");
        }
    }
}
