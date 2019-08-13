using System;
using Firedump.models.configuration.dynamicconfig;
using MySql.Data.MySqlClient;
using Firedump.utils;

namespace Firedump.models.sqlimport
{
    class SQLImport
    {
        //<events>
        public delegate void progress(int progress);
        public event progress Progress;
        private void onProgress(int progress)
        {
            Progress?.Invoke(progress);
        }
        //</events>
        public string script { set; get; }
        public ImportCredentialsConfig config { get; }
        private int commandCounter = 0;
        private string connectionString;
        private SQLImport() { }
        public SQLImport(ImportCredentialsConfig config)
        {
            this.config = config;
            if(config.port == 0)
            {
                this.config.port = 3306;
            }
            conStringBuilder();
        }

        private void conStringBuilder()
        {
            connectionString = "Server=" + config.host + ";UID=" + config.username;
            if (!string.IsNullOrWhiteSpace(config.password))
            {
                connectionString += ";password=" + config.password;
            }
            if (config.port != 3306)
            {
                connectionString += ";port=" + config.port;
            }
            connectionString += ";SslMode=Preferred";
            if (!string.IsNullOrWhiteSpace(config.database))
            {
                connectionString += ";database=" + config.database;
            }
        }

        public ImportResultSet executeScript()
        {
            ImportResultSet result = new ImportResultSet();
            if (string.IsNullOrWhiteSpace(this.script))
            {
                result.wasSuccessful = false;
                result.errorMessage = "Script not set";
                return result;
            }
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();

                MySqlScript script = new MySqlScript(con, this.script);
                script.Delimiter = config.scriptDelimeter;
                script.StatementExecuted += scriptStatementExecuted;
                script.Execute();

                result.wasSuccessful = true;
            }
            catch (Exception ex)
            {
                result.wasSuccessful = false;
                result.errorMessage = ex.Message;
            }

            return result;
        }

        private void scriptStatementExecuted(object sender, MySqlScriptEventArgs e)
        {
            //to testara ligo to apo katw fenete na doulevei swsta
            commandCounter += StringUtils.countOccurances(e.StatementText, config.scriptDelimeter) + 1; //to +1 einai to delimeter(semicolon) sto telos kathe statement 
            onProgress(commandCounter);
        }
        
    }
}
