using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Firedump.models.dump;
using System.Collections.Generic;
using Firedump.models.dump;
using Firedump.Forms.mysql;
using Firedump.models.configuration.dynamicconfig;
using Firedump.models.configuration.jsonconfig;
using System.IO;
using Firedump.models.databaseUtils;
using Firedump.models.dbUtils;

namespace FiredumpTest
{
    [TestClass]
    public class TestSqlDumpAdapter
    {        
        /// <summary>
        /// runs only once at class init
        /// </summary>
        [ClassInitialize()]
        public static void initDb(TestContext context)
        {
            TestDbConnection.populateDb(40);
            ConfigurationManager.getInstance();
        }


        /// <summary>
        /// runs only once at class destroy
        /// </summary>
        [ClassCleanup()]
        public static void clearDb()
        {
            TestDbConnection.clearDb();
        }



        [TestMethod]
        public  void TestFormDumpEventCallbacks()
        {

            MockFormProgressListener form = new MockFormProgressListener();
            MockAdapterListener adapter = new MockAdapterListener();

            //DbConnection connection = DbConnection.Instance();
            //connection.Host = Const.host;
            //connection.username = Const.username;
            //connection.password = Const.password;

            List<string> tables = DbUtils.getTables(new Firedump.sqlservers(Const.host,3306,Const.username,Const.password),Const.database);
            form.tables = tables;

            DumpCredentialsConfig config = new DumpCredentialsConfig();
            config.host = Const.host;
            config.port = 3306;
            config.username = Const.username;
            config.password = Const.password;
            config.database = Const.database;

             adapter.startDump(config);

        }




        class MockFormProgressListener
        {
            public List<string> tables { get; set; }
            public int progressCallCount { get; set; }

            public int tableEventCount { get; set; }

            public MockFormProgressListener()
            {
                tables = new List<string>();
            }

            public void initDumpTables(List<string> tables)
            {
                Assert.IsNotNull(tables);
                Assert.IsTrue(tables.Count > 0);
                this.tables = tables;
                Assert.AreEqual(this.tables.Count,tables.Count);
            }

            public void onCancelled()
            {
               
            }

            public void onCompleted(DumpResultSet status)
            {
                Assert.IsTrue(status.wasSuccessful);
                Assert.IsTrue(File.Exists(status.fileAbsPath));
                File.Delete(status.fileAbsPath);
                Assert.IsFalse(File.Exists(status.fileAbsPath));
                Console.WriteLine(progressCallCount);
            }

            public void onError(int error)
            {
                Assert.Fail();
            }

            public void onProgress(string progress)
            {
                progressCallCount++;
            }

            public void onTableDumpStart(string table)
            {
                Assert.IsNotNull(table);            
                Assert.IsTrue(this.tables.Contains(table));
            }

            public void tableRowCount(int tablecount)
            {

            }

            public void compressProgress(int progress)
            {

            }

            public void onCompressStart()
            {

            }
        }


        class MockAdapterListener 
        {
            public List<string> tables = new List<string>();
            public MockAdapterListener()
            {
                NumOfTables = 0;
            }
            public int NumOfTables { get; set; }
            public void onTableStartDump(string table)
            {
                Assert.IsNotNull(table);
                NumOfTables++;
                tables.Remove(table);
               
            }

            public void validateOnTableStartDump(int actual)
            {
                Assert.AreEqual(actual, NumOfTables);
                Assert.AreEqual(0, tables.Count);
            }

            public  void startDump(DumpCredentialsConfig credentialsConfigInstance)
            {
                SqlDump mysqldump = new SqlDump(credentialsConfigInstance);
                mysqldump.IsTest = true;
                DumpResultSet dumpresult =  mysqldump.executeDump();
            }

            public void tableRowCount(int rowcount)
            {
                
            }

            public void compressProgress(int progress)
            {

            }

            public void onCompressStart()
            {

            }
        }

        


    }
}
