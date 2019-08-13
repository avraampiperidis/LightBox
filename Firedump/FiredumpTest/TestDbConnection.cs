using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data;
using MySql.Data.MySqlClient;
using Firedump.Forms.mysql;
using System.Collections.Generic;
using Firedump.models.databaseUtils;
using Firedump.models.db;
using Firedump;
using Firedump.models.dbUtils;

namespace FiredumpTest
{
    /// <summary>
    /// this tests need real mysql server database
    /// </summary>
    [TestClass]
    public class TestDbConnection
    {
        private static sqlservers server = new sqlservers(Const.host,3306,Const.username,Const.password);

        /// <summary>
        /// runs only once at class init
        /// </summary>
        [ClassInitialize()]
        public static void initDb(TestContext context)
        {           
            populateDb(100);
        }

        /// <summary>
        /// runs only once at class destroy
        /// </summary>
        [ClassCleanup()]
        public static void clearDb()
        {
            using (var con = (MySqlConnection) DB.connect(server))
            {
                string sql = "DROP DATABASE IF EXISTS testfiredump;";
                using (MySqlCommand command = new MySqlCommand(sql,con))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch(MySqlException ex) { 
                    }
                    
                }
            }
        }

        /// <summary>
        /// runs every time before every test method
        /// </summary>
        [TestInitialize()]
        public void Initialize() {
        }

        /// <summary>
        /// runs every time after every test method
        /// </summary>
        [TestCleanup()]
        public void Cleanup() {
        }

        private static string password = Const.password;

        [TestMethod]
        public void TestTestConnection()
        {
            Assert.IsTrue(DB.TestConnection(server).wasSuccessful);
            Assert.IsFalse(DB.TestConnection(new sqlservers("localhost",3306,"user","wrongPassword")).wasSuccessful);
        }

       

        [TestMethod]
        public void TestGetDatabases()
        {
            Assert.IsFalse(DbUtils.getDatabases(server).Count == 0);
        }

        [TestMethod]
        public void TestGetTables()
        {
            //may not always pass!
            //depends on the mysql user privilages,if it has read permissions for information_schema and mysql databases
            Assert.IsFalse(DbUtils.getTables(server, "information_schema").Count == 0);
            Assert.IsFalse(DbUtils.getTables(server,"mysql").Count == 0);
            Assert.IsTrue(DbUtils.getTables(server,Const.database).Count > 0);
            List<string> tables = DbUtils.getTables(server,Const.database);
            Assert.AreEqual(3, tables.Count);
        }
        


        public static void populateDb(int rowsToCreate)
        {
            using (var con = (MySqlConnection)DB.connect(server))
            {
                //create test database and test tables
                string sql = "CREATE DATABASE IF NOT EXISTS testfiredump;use testfiredump";
                MySqlCommand command = new MySqlCommand(sql, con);
                int count = command.ExecuteNonQuery();
                Assert.AreEqual(1, count);

                sql = "CREATE TABLE IF NOT EXISTS table1 (id int,text VARCHAR(45))";
                command = new MySqlCommand(sql, con);
                count = command.ExecuteNonQuery();

                sql = "CREATE TABLE IF NOT EXISTS table2 (id int,text VARCHAR(45))";
                command = new MySqlCommand(sql, con);
                count = command.ExecuteNonQuery();

                sql = "CREATE TABLE IF NOT EXISTS table3 (id int,text VARCHAR(45))";
                command = new MySqlCommand(sql, con);
                count = command.ExecuteNonQuery();

                //populate them with junk data
                for (int i = 0; i < rowsToCreate; i++)
                {
                    
                    sql = "INSERT INTO table1(id,text) VALUES(" + i + ",'text" + i + "');";
                    command = new MySqlCommand(sql, con);
                    count = command.ExecuteNonQuery();
                    Assert.AreEqual(1, count);

                    sql = "INSERT INTO table2(id,text) VALUES(" + i + ",'text" + i + "');";
                    command = new MySqlCommand(sql, con);
                    count = command.ExecuteNonQuery();
                    Assert.AreEqual(1, count);

                    sql = "INSERT INTO table3(id,text) VALUES(" + i + ",'text" + i + "');";
                    command = new MySqlCommand(sql, con);
                    count = command.ExecuteNonQuery();
                    Assert.AreEqual(1, count);
                }



                if (command != null)
                {
                    command.Dispose();
                }

            }
        }


    }
}
