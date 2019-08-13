namespace Firedump
{


    partial class firedumpdbDataSet
    {
        partial class backup_locationsDataTable
        {
        }

        partial class schedulesDataTable
        {
        }

        partial class sql_serversDataTable
        {
        }
    }
}

namespace Firedump.firedumpdbDataSetTableAdapters
{
    partial class schedule_save_locationsTableAdapter
    {
    }

    partial class schedulesTableAdapter
    {
    }

    public partial class sql_serversTableAdapter
    {
        // new insert query with db type
        public virtual int InsertQuery(string name, long port, string host, string username, string password, string database,int db_type)
        {
            if ((name == null))
            {
                throw new global::System.ArgumentNullException("name");
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[0].Value = ((string)(name));
            }
            this.Adapter.InsertCommand.Parameters[1].Value = ((long)(port));
            if ((host == null))
            {
                throw new global::System.ArgumentNullException("host");
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[2].Value = ((string)(host));
            }
            if ((username == null))
            {
                throw new global::System.ArgumentNullException("username");
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[3].Value = ((string)(username));
            }
            if ((password == null))
            {
                throw new global::System.ArgumentNullException("password");
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[4].Value = ((string)(password));
            }
            if ((database == null))
            {
                this.Adapter.InsertCommand.Parameters[5].Value = global::System.DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[5].Value = ((string)(database));
            }
            this.Adapter.InsertCommand.Parameters[6].Value = db_type;
            global::System.Data.ConnectionState previousConnectionState = this.Adapter.InsertCommand.Connection.State;
            if (((this.Adapter.InsertCommand.Connection.State & global::System.Data.ConnectionState.Open)
                        != global::System.Data.ConnectionState.Open))
            {
                this.Adapter.InsertCommand.Connection.Open();
            }
            try
            {
                int returnValue = this.Adapter.InsertCommand.ExecuteNonQuery();
                return returnValue;
            }
            finally
            {
                if ((previousConnectionState == global::System.Data.ConnectionState.Closed))
                {
                    this.Adapter.InsertCommand.Connection.Close();
                }
            }
        }


        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private void InitAdapter()
        {
            this._adapter = new global::System.Data.SQLite.SQLiteDataAdapter();
            global::System.Data.Common.DataTableMapping tableMapping = new global::System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "sql_servers";
            tableMapping.ColumnMappings.Add("id", "id");
            tableMapping.ColumnMappings.Add("name", "name");
            tableMapping.ColumnMappings.Add("port", "port");
            tableMapping.ColumnMappings.Add("host", "host");
            tableMapping.ColumnMappings.Add("username", "username");
            tableMapping.ColumnMappings.Add("password", "password");
            tableMapping.ColumnMappings.Add("database", "database");
            tableMapping.ColumnMappings.Add("db_type", "db_type");
            this._adapter.TableMappings.Add(tableMapping);
            this._adapter.DeleteCommand = new global::System.Data.SQLite.SQLiteCommand();
            this._adapter.DeleteCommand.Connection = this.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [main].[sqlite_default_schema].[mysql_servers] WHERE (([id] = @Original_id) AND ([name] = @Original_name) AND ([port] = @Original_port) AND ([host] = @Original_host) AND ([username] = @Original_username) AND ([password] = @Original_password) AND ((@IsNull_database = 1 AND [database] IS NULL) OR ([database] = @Original_database)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            global::System.Data.SQLite.SQLiteParameter param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@Original_id";
            param.DbType = global::System.Data.DbType.Int64;
            param.DbType = global::System.Data.DbType.Int64;
            param.SourceColumn = "id";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapter.DeleteCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@Original_name";
            param.DbType = global::System.Data.DbType.AnsiString;
            param.DbType = global::System.Data.DbType.AnsiString;
            param.SourceColumn = "name";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapter.DeleteCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@Original_port";
            param.DbType = global::System.Data.DbType.Int64;
            param.DbType = global::System.Data.DbType.Int64;
            param.SourceColumn = "port";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapter.DeleteCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@Original_host";
            param.DbType = global::System.Data.DbType.String;
            param.SourceColumn = "host";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapter.DeleteCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@Original_username";
            param.DbType = global::System.Data.DbType.AnsiString;
            param.DbType = global::System.Data.DbType.AnsiString;
            param.SourceColumn = "username";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapter.DeleteCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@Original_password";
            param.DbType = global::System.Data.DbType.AnsiString;
            param.DbType = global::System.Data.DbType.AnsiString;
            param.SourceColumn = "password";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapter.DeleteCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@IsNull_database";
            param.DbType = global::System.Data.DbType.Int32;
            param.DbType = global::System.Data.DbType.Int32;
            param.SourceColumn = "database";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            param.SourceColumnNullMapping = true;
            this._adapter.DeleteCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@Original_database";
            param.DbType = global::System.Data.DbType.String;
            param.SourceColumn = "database";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapter.DeleteCommand.Parameters.Add(param);
            this._adapter.InsertCommand = new global::System.Data.SQLite.SQLiteCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [main].[sqlite_default_schema].[mysql_servers] ([name], [port], [host" +
                "], [username], [password], [database]) VALUES (@name, @port, @host, @username, @" +
                "password, @database)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@name";
            param.DbType = global::System.Data.DbType.AnsiString;
            param.DbType = global::System.Data.DbType.AnsiString;
            param.SourceColumn = "name";
            this._adapter.InsertCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@port";
            param.DbType = global::System.Data.DbType.Int64;
            param.DbType = global::System.Data.DbType.Int64;
            param.SourceColumn = "port";
            this._adapter.InsertCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@host";
            param.DbType = global::System.Data.DbType.String;
            param.SourceColumn = "host";
            this._adapter.InsertCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@username";
            param.DbType = global::System.Data.DbType.AnsiString;
            param.DbType = global::System.Data.DbType.AnsiString;
            param.SourceColumn = "username";
            this._adapter.InsertCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@password";
            param.DbType = global::System.Data.DbType.AnsiString;
            param.DbType = global::System.Data.DbType.AnsiString;
            param.SourceColumn = "password";
            this._adapter.InsertCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@database";
            param.DbType = global::System.Data.DbType.String;
            param.SourceColumn = "database";
            this._adapter.InsertCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@db_type";
            param.DbType = global::System.Data.DbType.Int32;
            param.SourceColumn = "db_type";
            this._adapter.InsertCommand.Parameters.Add(param);
            this._adapter.UpdateCommand = new global::System.Data.SQLite.SQLiteCommand();
            this._adapter.UpdateCommand.Connection = this.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [main].[sqlite_default_schema].[mysql_servers] SET [name] = @name, [port] = @port, [host] = @host, [username] = @username, [password] = @password, [database] = @database WHERE (([id] = @Original_id) AND ([name] = @Original_name) AND ([port] = @Original_port) AND ([host] = @Original_host) AND ([username] = @Original_username) AND ([password] = @Original_password) AND ((@IsNull_database = 1 AND [database] IS NULL) OR ([database] = @Original_database)))";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@name";
            param.DbType = global::System.Data.DbType.AnsiString;
            param.DbType = global::System.Data.DbType.AnsiString;
            param.SourceColumn = "name";
            this._adapter.UpdateCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@port";
            param.DbType = global::System.Data.DbType.Int64;
            param.DbType = global::System.Data.DbType.Int64;
            param.SourceColumn = "port";
            this._adapter.UpdateCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@host";
            param.DbType = global::System.Data.DbType.String;
            param.SourceColumn = "host";
            this._adapter.UpdateCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@username";
            param.DbType = global::System.Data.DbType.AnsiString;
            param.DbType = global::System.Data.DbType.AnsiString;
            param.SourceColumn = "username";
            this._adapter.UpdateCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@password";
            param.DbType = global::System.Data.DbType.AnsiString;
            param.DbType = global::System.Data.DbType.AnsiString;
            param.SourceColumn = "password";
            this._adapter.UpdateCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@database";
            param.DbType = global::System.Data.DbType.String;
            param.SourceColumn = "database";
            this._adapter.UpdateCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@Original_id";
            param.DbType = global::System.Data.DbType.Int64;
            param.DbType = global::System.Data.DbType.Int64;
            param.SourceColumn = "id";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapter.UpdateCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@Original_name";
            param.DbType = global::System.Data.DbType.AnsiString;
            param.DbType = global::System.Data.DbType.AnsiString;
            param.SourceColumn = "name";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapter.UpdateCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@Original_port";
            param.DbType = global::System.Data.DbType.Int64;
            param.DbType = global::System.Data.DbType.Int64;
            param.SourceColumn = "port";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapter.UpdateCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@Original_host";
            param.DbType = global::System.Data.DbType.String;
            param.SourceColumn = "host";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapter.UpdateCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@Original_username";
            param.DbType = global::System.Data.DbType.AnsiString;
            param.DbType = global::System.Data.DbType.AnsiString;
            param.SourceColumn = "username";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapter.UpdateCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@Original_password";
            param.DbType = global::System.Data.DbType.AnsiString;
            param.DbType = global::System.Data.DbType.AnsiString;
            param.SourceColumn = "password";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapter.UpdateCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@IsNull_database";
            param.DbType = global::System.Data.DbType.Int32;
            param.DbType = global::System.Data.DbType.Int32;
            param.SourceColumn = "database";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            param.SourceColumnNullMapping = true;
            this._adapter.UpdateCommand.Parameters.Add(param);
            param = new global::System.Data.SQLite.SQLiteParameter();
            param.ParameterName = "@Original_database";
            param.DbType = global::System.Data.DbType.String;
            param.SourceColumn = "database";
            param.SourceVersion = global::System.Data.DataRowVersion.Original;
            this._adapter.UpdateCommand.Parameters.Add(param);
        }

    }
}
