using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Firedump.models.configuration.dynamicconfig;
using Firedump.models.configuration.jsonconfig;
using Firedump.models.dump;
using System.IO;
using System.Text.RegularExpressions;
using Firedump.models.databaseUtils;
using Firedump.utils;
using Firedump.models.dbUtils;
using Firedump.models.configuration.jsonconfig.dto;

namespace Firedump.models.dump
{
    public class SqlDump
    {
        public bool IsTest { get; set; }
        static readonly string mysqldumpfile = "resources\\mysqldump\\mysqldump.exe";
        //</events>

        /// <summary>
        /// Create a new credentials instance and set it before executing mysqldump
        /// </summary>
        private DumpCredentialsConfig credentialsConfigInstance { set; get; }

        private Process proc;
        private Compression comp;
        private string tempTableName = "";
        private string currentDatabase = "";


        //onTableStartDump
        public delegate void tableStartDump(string table);
        public event tableStartDump TableStartDump;
        private void onTableStartDump(string table)
        {
            TableStartDump?.Invoke(table);
        }

        //onCompressStart
        public delegate void tableRowCount(int rowcount);
        public event tableRowCount TableRowCount;
        private void onTableRowCount(int rowcount)
        {
            TableRowCount?.Invoke(rowcount);
        }

        //onCompressProgress
        public delegate void compressProgress(int progress);
        public event compressProgress CompressProgress;
        private void onCompressProgress(int progress)
        {
            CompressProgress?.Invoke(progress);
        }

        //onCompressStart
        public delegate void compressStart();
        public event compressStart CompressStart;
        private void onCompressStart()
        {
            CompressStart?.Invoke();
        }

        public SqlDump(DumpCredentialsConfig creds)
        {
            this.credentialsConfigInstance = creds;        
        }

        private Tuple<StringBuilder, DumpResultSet> calculateArguments()
        {
            StringBuilder arguments = new StringBuilder();
            DumpResultSet resultObj = new DumpResultSet();
            arguments.Append("--protocol=tcp ");
            //Credentials
            //host
            if (!String.IsNullOrEmpty(credentialsConfigInstance.host))
            {
                arguments.Append("--host " + credentialsConfigInstance.host + " ");
            }
            else
            {
                resultObj.wasSuccessful = false;
                resultObj.errorNumber = -1;
                resultObj.errorMessage = "Host not set";
            }
            //port
            if (credentialsConfigInstance.port < 1 || credentialsConfigInstance.port > 65535)
            {
                resultObj.wasSuccessful = false;
                resultObj.errorNumber = -1;
                resultObj.errorMessage = "Invalid port number: " + credentialsConfigInstance.port;
            }
            else
            {
                arguments.Append("--port=" + credentialsConfigInstance.port + " ");
            }

            //username
            if (!String.IsNullOrEmpty(credentialsConfigInstance.username))
            {
                arguments.Append("--user " + credentialsConfigInstance.username + " ");
            }
            else
            {
                resultObj.wasSuccessful = false;
                resultObj.errorNumber = -1;
                resultObj.errorMessage = "Username not set";
            }

            //pasword
            if (!String.IsNullOrEmpty(credentialsConfigInstance.password))
            {
                arguments.Append("--password=" + credentialsConfigInstance.password + " ");
            }

            //MySqlDumpConfiguration
            ConfigurationManager configurationManagerInstance = ConfigurationManager.getInstance();
            //includeCreateSchema
            if (!configurationManagerInstance.mysqlDumpConfigInstance.getSettings().includeCreateSchema)
            {
                arguments.Append("--no-create-info ");
            }

            //includeData
            if (!configurationManagerInstance.mysqlDumpConfigInstance.getSettings().includeData)
            {
                arguments.Append("--no-data ");
            }

            //includeComments
            if (!configurationManagerInstance.mysqlDumpConfigInstance.getSettings().includeComments)
            {
                arguments.Append("--skip-comments ");
            }

            //singleTransaction
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().singleTransaction)
            {
                arguments.Append("--single-transaction ");
            }

            //disableForeignKeyChecks
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().disableForeignKeyChecks)
            {
                arguments.Append("--disable-keys ");
            }

            //addDropDatabase
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().addDropDatabase)
            {
                arguments.Append("--add-drop-database ");
            }

            //createDatabase
            if (!configurationManagerInstance.mysqlDumpConfigInstance.getSettings().createDatabase)
            {
                arguments.Append("--no-create-db ");
            }

            //moreCompatible
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().moreCompatible)
            {
                arguments.Append("--compatible ");
            }

            //characterSet
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().characterSet != "utf8")
            {
                string charSetPath = "\"" + AppDomain.CurrentDomain.BaseDirectory + "resources\\mysqldump\\charsets\"";
                arguments.Append("--character-sets-dir=" + charSetPath + " ");
                arguments.Append("--default-character-set=" + configurationManagerInstance.mysqlDumpConfigInstance.getSettings().characterSet + " ");
            }

            //addDropTable
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().addDropTable)
            {
                arguments.Append("--add-drop-table ");
            }
            else
            {
                arguments.Append("--skip-add-drop-table ");
            }

            //addLocks
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().addLocks)
            {
                arguments.Append("--add-locks ");
            }

            //noAutocommit
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().noAutocommit)
            {
                arguments.Append("--no-autocommit ");
            }

            //encloseWithBackquotes
            if (!configurationManagerInstance.mysqlDumpConfigInstance.getSettings().encloseWithBackquotes)
            {
                arguments.Append("--skip-quote-names ");
            }

            //addCreateProcedureFunction
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().addCreateProcedureFunction)
            {
                arguments.Append(" --routines ");
            }

            //addInfoComments
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().addInfoComments)
            {
                arguments.Append("--dump-date ");
            }

            //completeInsertStatements
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().completeInsertStatements)
            {
                arguments.Append("--complete-insert ");
            }

            //extendedInsertStatements
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().completeInsertStatements)
            {
                arguments.Append("--extended-insert ");
            }

            //maximumLengthOfQuery
            arguments.Append("--net-buffer-length " + configurationManagerInstance.mysqlDumpConfigInstance.getSettings().maximumLengthOfQuery + " ");

            //maximumPacketLength
            arguments.Append("--max_allowed_packet=" + configurationManagerInstance.mysqlDumpConfigInstance.getSettings().maximumPacketLength + "M ");

            //useIgnoreInserts
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().useIgnoreInserts)
            {
                arguments.Append("--insert-ignore ");
            }

            //useHexadecimal
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().useHexadecimal)
            {
                arguments.Append("--hex-blob ");
            }

            //dumpTriggers
            if (!configurationManagerInstance.mysqlDumpConfigInstance.getSettings().dumpTriggers)
            {
                arguments.Append("--skip-triggers ");
            }

            //dumpEvents
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().dumpEvents)
            {
                arguments.Append("--events ");
            }

            //xml
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().xml)
            {
                arguments.Append("--xml ");
            }

            //exportType
            switch (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().exportType)
            {
                case 0:
                    break;
                case 1:
                    arguments.Append("--replace ");
                    break;
                default:
                    break;
            }

            //database choice
            if (credentialsConfigInstance.databases == null)
            {
                if (string.IsNullOrEmpty(credentialsConfigInstance.database))
                {
                    arguments.Append("--all-databases ");
                }
                else
                {
                    arguments.Append("--databases " + credentialsConfigInstance.database);
                    if (credentialsConfigInstance.excludeTablesSingleDatabase != null)
                    {
                        arguments.Append(" ");
                        string[] tables = credentialsConfigInstance.excludeTablesSingleDatabase.Split(',');
                        foreach (string table in tables)
                        {
                            arguments.Append("--ignore-table=" + credentialsConfigInstance.database + "." + table + " ");
                        }
                    }
                }
            }
            else
            {
                arguments.Append("--databases ");
                foreach (string database in credentialsConfigInstance.databases)
                {
                    arguments.Append(database + " ");
                }
                if (credentialsConfigInstance.excludeTables != null)
                {
                    for (int i = 0; i < credentialsConfigInstance.excludeTables.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(credentialsConfigInstance.excludeTables[i]))
                        {
                            string[] tables = credentialsConfigInstance.excludeTables[i].Split(',');
                            foreach (string table in tables)
                            {
                                arguments.Append("--ignore-table=" + credentialsConfigInstance.databases[i] + "." + table + " ");
                            }
                        }
                    }
                }
            }
            return Tuple.Create(arguments, resultObj);
        }


        public DumpResultSet executeDump()
        {
            Tuple<StringBuilder,DumpResultSet> pair = calculateArguments();
            StringBuilder arguments = pair.Item1;
            DumpResultSet resultObj = pair.Item2;
            if (!resultObj.wasSuccessful)
            {
                return resultObj;
            }
            //dump execution
            Console.WriteLine(arguments.ToString());   
            proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = mysqldumpfile,//AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "mysqldump.exe") ,
                    Arguments = arguments.ToString(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true, //prepei na diavastoun me ti seira pou ginonte ta redirect alliws kolaei se endless loop
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
         
            Console.WriteLine("MySqlDump: Dump starting now");      
            proc.Start();

            Random rnd = new Random();
            string fileExt;
            ConfigurationManager configurationManagerInstance = ConfigurationManager.getInstance();
            if (configurationManagerInstance.mysqlDumpConfigInstance.getSettings().xml)
            {
                fileExt = ".xml";
            }
            else
            {
                fileExt = ".sql";
            }
            String filename = "dump" + rnd.Next(1000000, 9999999) + fileExt;

            Directory.CreateDirectory(configurationManagerInstance.mysqlDumpConfigInstance.getSettings().tempSavePath);
           

            //checking if file exists
            while (File.Exists(configurationManagerInstance.mysqlDumpConfigInstance.getSettings().tempSavePath + filename)){
                filename = "Dump" + rnd.Next(10000000, 99999999) + fileExt;
            }

            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@configurationManagerInstance.mysqlDumpConfigInstance.getSettings().tempSavePath + filename))
                {
                    //addCustomCommentInHeader
                    if (!string.IsNullOrEmpty(configurationManagerInstance.mysqlDumpConfigInstance.getSettings().addCustomCommentInHeader))
                    {
                        file.WriteLine("-- Custom comment: " + configurationManagerInstance.mysqlDumpConfigInstance.getSettings().addCustomCommentInHeader);
                    }


                    while (!proc.StandardOutput.EndOfStream)
                    {
                        string line = proc.StandardOutput.ReadLine();
                        file.WriteLine(line);
                        handleLineOutput(line, configurationManagerInstance.mysqlDumpConfigInstance.getSettings());
                    }

                }

                resultObj.mysqldumpexeStandardError = "";
                while (!proc.StandardError.EndOfStream)
                {
                    resultObj.mysqldumpexeStandardError += proc.StandardError.ReadLine() + "\n";
                }

                if(resultObj.mysqldumpexeStandardError.StartsWith("Warning: Using a password"))
                {
                    resultObj.mysqldumpexeStandardError = resultObj.mysqldumpexeStandardError.Replace("Warning: Using a password on the command line interface can be insecure.\n","");
                }

                Console.WriteLine(resultObj.mysqldumpexeStandardError); //for testing

                proc.WaitForExit();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("MySQLdump null reference exception on proccess: "+ex.Message);
                File.Delete(configurationManagerInstance.mysqlDumpConfigInstance.getSettings().tempSavePath + filename);
            }
            if (proc == null || proc.ExitCode != 0)
            {
                resultObj.wasSuccessful = false;
                resultObj.errorNumber = -2;
                if(proc == null)
                {
                    resultObj.mysqldumpexeStandardError = "MySQL dump proccess was killed.";
                }
                File.Delete(configurationManagerInstance.mysqlDumpConfigInstance.getSettings().tempSavePath + filename);
            }
            else
            {
                resultObj.wasSuccessful = true;
                resultObj.fileAbsPath = configurationManagerInstance.mysqlDumpConfigInstance.getSettings().tempSavePath + filename;

                //compression
                if (configurationManagerInstance.compressConfigInstance.getSettings().enableCompression)
                {
                    comp = new Compression();
                    comp.absolutePath = resultObj.fileAbsPath;
                    comp.CompressProgress += onCompressProgressHandler;
                    comp.CompressStart += onCompressStartHandler;
                   
                    CompressionResultSet compResult = comp.doCompress7z(); //edw kaleitai to compression

                    if (!compResult.wasSuccessful)
                    {
                        resultObj.wasSuccessful = false;
                        resultObj.errorNumber = -3;
                        resultObj.mysqldumpexeStandardError = compResult.standardError;
                    }
                    File.Delete(resultObj.fileAbsPath); //delete to sketo .sql
                    resultObj.fileAbsPath = compResult.resultAbsPath;
                }
            }
                    
            return resultObj;
        }

        private void onCompressProgressHandler(int progress)
        {
            onCompressProgress(progress);
        }

        private void onCompressStartHandler()
        {
            onCompressStart();
        }


        public void cancelMysqlDumpProcess()
        {        
                try
                {
                    if(comp != null)
                    {
                        comp.KillProc();
                    }                   
                    proc.Kill();
                    proc = null;                   
                }catch(Exception ex)
                {
                }                
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="createschema"></param>
        private void handleLineOutput(string line,SqlDumpDto dto) //ekana ta boolean global gia na min ta pernaei sinexws parametrika
        {
            if (!String.IsNullOrEmpty(line))
            {
                if (dto.encloseWithBackquotes && line.ToUpper().StartsWith("USE"))
                {
                    currentDatabase = line.Split('`', '`')[1];
                }
                else if(line.ToUpper().StartsWith("USE"))
                {
                    currentDatabase = line.Replace("USE", "").Trim();
                }

                string insertStartsWith = "";
                if (dto.exportType == 1 && dto.useIgnoreInserts == true)
                {
                    insertStartsWith = "REPLACE  IGNORE INTO";
                }
                else if (dto.exportType == 1)
                {
                    insertStartsWith = "REPLACE INTO";
                }
                else if (dto.useIgnoreInserts)
                {
                    insertStartsWith = "INSERT  IGNORE INTO";
                }
                else
                {
                    insertStartsWith = "INSERT INTO";
                }

                if (!dto.xml)
                {
                    if (dto.includeCreateSchema)
                    {
                        if (line.StartsWith("CREATE TABLE"))
                        {
                            string tablename = "";
                            if (!dto.encloseWithBackquotes)
                            {
                                int Pos1 = line.IndexOf("TABLE") + 5;
                                int Pos2 = line.IndexOf("(");
                                tablename = line.Substring(Pos1, Pos2 - Pos1).Trim();
                            }
                            else
                            {
                                tablename = line.Split('`', '`')[1];
                            }
                            int rowcount = 1;
                            try
                            {
                                rowcount = getDbTableRowsCount(tablename, currentDatabase);
                            }
                            catch (Exception ex)
                            {
                            }
                            onTableStartDump(tablename);
                            onTableRowCount(rowcount);
                        }

                    }
                    else if(line.Contains(insertStartsWith))
                    {
                        string tablename = "";
                        if (!dto.encloseWithBackquotes)
                        {
                            int Pos1 = line.IndexOf("INTO") + 4;
                            tablename = line.Substring(Pos1, line.IndexOf("(") - Pos1).Trim();
                        }
                        else
                        {
                            tablename = line.Split('`', '`')[1];
                        }

                        if (tablename != tempTableName)
                        {
                            tempTableName = tablename;
                            int rowcount = 1;
                            try
                            {
                                rowcount = getDbTableRowsCount(tablename, currentDatabase);
                            }
                            catch (Exception ex)
                            {
                            }
                            //fire event
                            onTableStartDump(tablename);
                            onTableRowCount(rowcount);
                        }
                    }
                }
            }
            
        }
        

        private int getDbTableRowsCount(string tableName,string dbname)
        {
            return DbUtils.getTableRowCount(new sqlservers(credentialsConfigInstance.host, credentialsConfigInstance.port, 
                credentialsConfigInstance.username, credentialsConfigInstance.password), dbname, tableName);
        }

    }
}
