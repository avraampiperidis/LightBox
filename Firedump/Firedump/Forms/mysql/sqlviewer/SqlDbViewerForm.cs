using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using Firedump.models.db;
using Firedump.models.dbUtils;

namespace Firedump.Forms.mysql.sqlviewer
{
    
    public partial class SqlDbViewerForm : Form, IIntelliSense
    {



        private bool skip = false;
        private string currentWord = "";
        private Stack<string> undoList = new Stack<string>();
        private Stack<string> redoList = new Stack<string>();
        private Point point = new Point();

        private sqlservers server;
        //merge whene database mysql_server gets database field
        private string database;

        private string[] limits = new string[] {
            "Limit to 50 rows",
            "Limit to 100 rows",
            "Limit to 500 rows",
            "Limit to 1000 rows",
            "Limit to 5000 rows",
            "No Limit"
        };

        public SqlDbViewerForm(sqlservers server,string database)
        {
            InitializeComponent();          
            try {
                if (DB.TestConnection(server).wasSuccessful)
                {

                    this.server = server;
                    this.database = database;
                    List<string> tables = DbUtils.getTables(this.server,this.database); 
                    MysqlWords.tables = tables;

                    TreeNode[] nodearray = new TreeNode[tables.Count];
                    for (int i = 0; i < tables.Count; i++)
                    {
                        TreeNode treenode = new TreeNode(tables[i]);
                        treenode.ImageIndex = 1;
                        nodearray[i] = treenode;
                    }
                    for (int i = 0; i < MysqlWords.tables.Count; i++)
                    {
                        MysqlWords.tables[i] = MysqlWords.tables[i].ToUpper();
                    }

                    ImageList imagelist = new ImageList();
                    imagelist.Images.Add(Bitmap.FromFile("resources\\icons\\databaseimage.bmp"));
                    imagelist.Images.Add(Bitmap.FromFile("resources\\icons\\tableimage.bmp"));

                    TreeNode rootNode = new TreeNode("database:" + database, nodearray);
                    rootNode.ImageIndex = 1;
                    rootNode.ImageIndex = 0;
                    rootNode.Expand();

                    treeView1.Nodes.Add(rootNode);

                    treeView1.ImageIndex = 0;
                    treeView1.ImageList = imagelist;
                    
                }
                else
                {
                    MessageBox.Show("Couldent OldMySqlConnect to " + database + " database");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            richTextBox1.Text = "";
            for(int i =0; i < limits.Length; i++)
            {
                toolStripComboBox1.Items.Add(limits[i]);
            }
            toolStripComboBox1.SelectedIndex = 2;

       
        }


        private void EvaluateCaretPosition()
        {
           
        }

        public void GetCaretPosition()
        {
           
        }


        private void executesql_click(object sender, EventArgs e)
        {
            string queryText = richTextBox1.Text.ToUpper();
            if (queryText.Contains( "UPDATE ") || queryText.Contains(" INSERT ") || queryText.StartsWith("UPDATE ") || queryText.StartsWith("INSERT "))
                executeUpdateOrInsertQuery(richTextBox1.Text);
            else
                executeQuery(richTextBox1.Text);         
        }
        
        private void executeUpdateOrInsertQuery(string query)
        {
            if(!String.IsNullOrEmpty(query))
            {
                undoList.Push(query);
                try {
                    using (var con = DB.connect(this.server,this.database))
                    {
                    //    var command = new MySqlCommand();
                    //    command.Connection = con;
                    //    command.CommandText = query;
                    //    int numofrowsupdated = command.ExecuteNonQuery();
                    //    command.Dispose();
                        
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    DataSet dataset = new DataSet();
                    DataTable datatable = new DataTable("MySql Error");
                    datatable.Columns.Add(new DataColumn("Type", typeof(string)));
                    datatable.Columns.Add(new DataColumn("Message", typeof(string)));
                    DataRow datarow = datatable.NewRow();
                    datarow["Type"] = "MySql Error";
                    datarow["Message"] = ex.Message;
                    datatable.Rows.Add(datarow);
                    dataset.Tables.Add(datatable);

                    dataGridView1.DataSource = dataset.Tables[0];
                }
            }
        }

        private void executeQuery(string query)
        {
            
            if (!String.IsNullOrEmpty(query))
            {
                undoList.Push(query);
                try {
                    // this whole form is about to be completle deleted anyway
                    //using (var connection = DB.OldMySqlConnect(this.server,this.database))
                    //{
                    //    using (MySqlDataAdapter adapter = new MySqlDataAdapter(limitQuery(query), connection))
                    //    {
                    //        try
                    //        {
                    //            var dataset = new DataSet();
                    //            var bs = new BindingSource();
                    //            adapter.Fill(dataset);
                    //            //if its byte[] == blob is db
                    //            //then set it to null otherwise the program stops
                    //            for(int i =0; i < dataset.Tables[0].Rows.Count; i++)
                    //            {
                    //                for (int x =0; x < dataset.Tables[0].Rows[i].Table.Columns.Count; x++)
                    //                {
                    //                    if (dataset.Tables[0].Rows[i].Table.Columns[x].DataType.ToString() == "System.Byte[]")
                    //                    {
                    //                        dataset.Tables[0].Rows[i][x] = null;
                    //                    }
                    //                }
                    //            }

                    //            bs.DataSource = dataset.Tables[0].DefaultView;
                    //            dataGridView1.DataSource = bs;

                    //            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    //            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //        }
                    //        catch (MySqlException ex)
                    //        {
                                
                    //            Console.WriteLine(ex.Message);
                               
                    //        }

                    //    }
                    //}
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                   
                }
            }
        }


        private void nodeSelectEvent(object sender, TreeViewEventArgs e)
        {
            if(!e.Node.Text.StartsWith("database:"))
            {
                string table = e.Node.Text;
                string sql = "SELECT * FROM "+table + " ";
                //lastQuery = sql;
                string[] sqlarr = sql.Split(' ');
                richTextBox1.Text = "";
                for(int i =0; i < sqlarr.Length; i++)
                {
                    richTextBox1.AppendText(sqlarr[i] + " ");
                    richTextBox1.SelectionStart = richTextBox1.TextLength;
                    setSqlHighlight();
                }
                executeQuery(sql);
            }
        }


        private void setSqlHighlight()
        {
            undoList.Push(richTextBox1.Text);

            int i = 0;
            string word = "";
            int c = 0;
            for (i = richTextBox1.SelectionStart - 2; i >= 0; i--)
            {
                if (richTextBox1.Text[i] == ' ' || i == 0)
                {
                    word = richTextBox1.Text.Substring(i, c + 1).Trim().ToUpper();
                    break;
                }
                c++;
            }
            int cursorpos = richTextBox1.SelectionStart;
            if (!String.IsNullOrEmpty(word))
            {
                if (i == -1)
                    i = 0;
              
                richTextBox1.Select(i, word.Length + 1);              
                    
                if (MysqlWords.tables.Contains(word))
                {
                    richTextBox1.SelectionColor = Color.Blue;
                }
                else if (MysqlWords.tables.Contains(word))
                {
                    richTextBox1.SelectionColor = Color.Purple;
                }
                else if (MysqlWords.operators.Contains(word))
                {
                    richTextBox1.SelectionColor = Color.Red;
                }
                else
                {
                    richTextBox1.SelectionColor = Color.Black;
                }

                richTextBox1.Select(richTextBox1.TextLength, 0);
                richTextBox1.SelectionColor = richTextBox1.ForeColor;
                richTextBox1.SelectionStart = cursorpos;
            }
        }

        private void onKeyUpEvent(object sender, KeyEventArgs e)
        {
            EvaluateCaretPosition();
            
            //space
            if (((char)e.KeyCode) == ' ' && ((char)e.KeyCode) != (char)Keys.Back)
            {
               setSqlHighlight();
            }
            else if (((char)e.KeyCode) == (char)Keys.Back)
            {
                //richTextBox1.Select(richTextBox1.TextLength,0);
                //richTextBox1.SelectionColor = richTextBox1.ForeColor;
            }

            currentWord = getCurrentWord();
            string word = currentWord.ToUpper();
           
        }

        


        private string limitQuery(string query)
        {
            if (!query.ToUpper().StartsWith("SHOW"))
            {
                if (query.ToUpper().Contains("LIMIT"))
                {
                    return query;
                }
                else
                {
                    int pos = toolStripComboBox1.SelectedIndex;
                    if (pos == 0)
                    {
                        return query+" LIMIT 50";
                    }
                    if (pos == 1)
                        return query+" LIMIT 100";
                    if (pos == 2)
                        return query+" LIMIT 500";
                    if (pos == 3)
                        return query+" LIMIT 1000";
                    if (pos == 4)
                        return query+" LIMIT 5000";
                    return query;
                }
            }

            return query;
        }

        private void clearQueryField(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
        

        private void unduTextClick(object sender, EventArgs e)
        {
            if(undoList.Count != 0)
            {
                string unduText = undoList.Pop();
                richTextBox1.Text = unduText;
                redoList.Push(unduText);
            }         
        }

        private void redoClick(object sender, EventArgs e)
        {
            if(redoList.Count != 0)
            {
                string content = redoList.Pop();
                richTextBox1.Text = content;
                undoList.Push(content);
            }
        }

        private void saveToExcelClick(object sender, EventArgs e)
        {
                    
        }



        private string getCurrentWord()
        {
            if (richTextBox1.SelectionStart > 1)
            {
                int cursorPosition = richTextBox1.SelectionStart;
                int nextSpace = richTextBox1.Text.IndexOf(' ', cursorPosition);
                int selectionStart = 0;
                string trimmedString = string.Empty;
                if (nextSpace != -1)
                {
                    trimmedString = richTextBox1.Text.Substring(0, nextSpace);
                }
                else
                {
                    trimmedString = richTextBox1.Text;
                }

                if (trimmedString.LastIndexOf(' ') != -1)
                {
                    selectionStart = 1 + trimmedString.LastIndexOf(' ');
                    trimmedString = trimmedString.Substring(1 + trimmedString.LastIndexOf(' '));
                }

                string word = richTextBox1.Text.Substring(selectionStart, trimmedString.Length);
                Console.WriteLine(word);
                return word;
                //select the word
                //richTextBox1.SelectionStart = selectionStart;
                //richTextBox1.SelectionLength = trimmedString.Length;
            }
            return "";
        }


        public void MyOnKeyUp(KeyPressEventArgs e, string value)
        {
            if (e.KeyChar == (char)Keys.Up || e.KeyChar == (char)Keys.Down)
            {

            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                richTextBox1.Text = richTextBox1.Text.Replace(currentWord, value);
                richTextBox1.SelectionStart = richTextBox1.Text.Length;

                initText();
            }
            else
            {               
                if(e.KeyChar != (char)Keys.Back)
                {
                    Console.WriteLine(e.KeyChar.ToString());
                    richTextBox1.Focus();
                    richTextBox1.AppendText(e.KeyChar.ToString());
                } else
                {
                    richTextBox1.Focus();
                    richTextBox1.Text = richTextBox1.Text.Substring(0,richTextBox1.Text.Length-1);
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;

                    //initText();
                    string[] sqlarr = richTextBox1.Text.Split(' ');
                    richTextBox1.Text = "";
                    for (int i = 0; i < sqlarr.Length; i++)
                    {
                        int n = i;
                        int t = ++n;
                        if (t == sqlarr.Length)
                            richTextBox1.AppendText(sqlarr[i]);
                        else
                            richTextBox1.AppendText(sqlarr[i] + " ");

                        richTextBox1.SelectionStart = richTextBox1.TextLength;
                        setSqlHighlight();
                    }
                }                
            }

        }


        //---interface method
        public void onValueSelected(string value)
        {

        
                
        }




        private void initText()
        {
            string[] sqlarr = richTextBox1.Text.Split(' ');
            richTextBox1.Text = "";
            for (int i = 0; i < sqlarr.Length; i++)
            {              
                richTextBox1.AppendText(sqlarr[i] + " ");
                richTextBox1.SelectionStart = richTextBox1.TextLength;
                setSqlHighlight();
            }
        }

       
    }
}
