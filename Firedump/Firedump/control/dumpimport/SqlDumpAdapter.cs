
using Firedump.models.configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using Firedump.models.dump;
using System.Collections.Generic;
using Firedump.models.configuration.dynamicconfig;
using Firedump.models.databaseUtils;
using System.IO;
using Firedump.models.db;
using Firedump.models.dbUtils;

namespace Firedump.models.dump
{
    public class SqlDumpAdapter
    {
        //<events>

        //onProgress
        public delegate void progress(string progress);
        public event progress Progress;
        private void onProgress(string progress)
        {
            Progress?.Invoke(progress);
        }

        //onError
        public delegate void error(int error);
        public event error Error;
        private void onError(int error)
        {
            Error?.Invoke(error);
        }

        //
        public delegate void cancelled();
        public event cancelled Cancelled;
        private void onCancelled()
        {
            Cancelled?.Invoke();
        }

        //onCompleted
        public delegate void completed(DumpResultSet status);
        public event completed Completed;
        private void onCompleted(DumpResultSet status)
        {
            Completed?.Invoke(status);
        }

        //onInitDumpTables
        public delegate void initDumpTables(List<string> tables);
        public event initDumpTables InitDumpTables;
        private void onInitDumpTables(List<string> tables)
        {
            InitDumpTables?.Invoke(tables);
        }

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

        //</events>
        private SqlDump mydump;
        private DumpCredentialsConfig credentialsConfigInstance;
        private List<string> tableList;

        public SqlDumpAdapter() {           
        }


        /// <summary>
        /// start mysql dump/backup
        /// usualy gets called from the user
        /// </summary>
        /// <param name="credentialsConfigInstance">Instance of class CredentialsConfig with set credentials for dump</param>
        /// <param name="listener">the listener interface for the notifications status of the whole job \n
        ///                       IDumpProgressListener to notify the user about the job status 
        /// </param>
        public void startDump(DumpCredentialsConfig credentialsConfigInstance)
        {
            onProgress("mysql dump started!");//+options.getHost());

            this.credentialsConfigInstance = credentialsConfigInstance;

            Task mysqldumpTask = new Task(DumpMysqlTaskExecutor);
            mysqldumpTask.Start();
        }
        
       
        /// <summary>
        /// main mysql dump executor task
        /// start/running in ASYNC mode.
        /// internal its calling other task/jobs and waits for completion.
        /// with every task completed its firing notification events(listener)
        /// --BASIC FLOW--
        /// </summary>
        async void DumpMysqlTaskExecutor()
        {
            Task<List<string>> testConnectionTask = testCon();
            List<string> tables = await testConnectionTask;
            if (tables != null)
            {
                onProgress("connected");
                onInitDumpTables(tables);

                mydump = new SqlDump(credentialsConfigInstance);               
                mydump.CompressProgress += onCompressProgressHandler;
                mydump.CompressStart += onCompressStartHandler;
                mydump.TableRowCount += onTableRowCountHandler;
                mydump.TableStartDump += onTableStartDumpHandler;

                Task<DumpResultSet> result = dumptask(mydump);
                DumpResultSet dumpresult = null;
                try
                {
                    dumpresult = await result;
                }
                catch (Exception ex)
                {
                    if (!(ex is NullReferenceException))
                    {
                        dumpresult = new DumpResultSet();
                        dumpresult.wasSuccessful = false;
                        dumpresult.errorNumber = 2;
                        dumpresult.mysqldumpexeStandardError = "Error in MySQLDumpAdapter:\n" + ex.Message;
                    }
                }

                onCompleted(dumpresult);
                mydump = null;
            }
            else
            {

                //we need enumaration classes for all kind of different erros
                //..We still need enumaration class for all kind of dif erros
                onError(-1);

                mydump = null;
            }
            
        }


        internal void cancelDump()
        {
            if(mydump != null)
            {
                mydump.cancelMysqlDumpProcess();
                mydump = null;              
            }
        }

        public bool isDumpRunning()
        {
            return mydump != null;
        }


        async Task<List<string>>  testCon()
        {
            try {       
                if (DB.TestConnection(new sqlservers(this.credentialsConfigInstance.host, this.credentialsConfigInstance.port, this.credentialsConfigInstance.username, this.credentialsConfigInstance.password), this.credentialsConfigInstance.database).wasSuccessful)
                {
                    return DbUtils.getTables(new sqlservers(this.credentialsConfigInstance.host, this.credentialsConfigInstance.port, this.credentialsConfigInstance.username, this.credentialsConfigInstance.password), this.credentialsConfigInstance.database);            
                }
            }catch(Exception ex)
            {
            }
            return null;
        }


        static async Task<DumpResultSet> dumptask(SqlDump mydump)
        {
            return mydump.executeDump();
        }


        private void onTableStartDumpHandler(string table)
        {
            onTableStartDump(table);
        }

        private void onTableRowCountHandler(int rowcount)
        {
            onTableRowCount(rowcount);
        }

        private void onCompressProgressHandler(int progress)
        {
            onCompressProgress(progress);
        }

        private void onCompressStartHandler()
        {
            onCompressStart();
        }

        internal void setTableList(List<string> tableList)
        {
            this.tableList = tableList;
        }
    }
    

}
