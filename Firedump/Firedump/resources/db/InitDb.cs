using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Firedump.utils;

namespace Firedump.db
{
    /// <summary>
    /// initialization database sqlite firedump.db script,
    /// so this is utility only first run script.
    /// 
    /// 
    /// </summary>
    public class InitDb
    {
        private static readonly string BUILD_SERVER_SQLITEDB = "C://jenkins//resources//firedumpdb.db";
        private static readonly string BUILD_SERVER_DATASOURCE = "Data Source=C://jenkins//resources//firedumpdb.db";

        private static string conn = ".//resources//db//firedumpdb.db";
        private static readonly int dbVersion = 1;
        public static bool IsTest { get; set; }

        public InitDb() { }

        public static string ConnectionString { get { return conn; } }

        private static readonly IDictionary<string, string> tables = new Dictionary<string,string>()
        {
            {"backup_locations","backup_locations"},
            {"logs","logs"},
            {"sqlservers","sqlservers"},
            {"schedule_save_locations","schedule_save_locations" },
            {"schedules","schedules" },
            {"userinfo","userinfo"}
        };

        private static readonly IDictionary<string, string> Indices = new Dictionary<string, string>()
        {
            {"backup_location_id_key_idx","backup_location_id_key_idx" },
            {"schedule_id_key4_idx","schedule_id_key4_idx"},
            {"schedule_id_key_idx","schedule_id_key_idx" },
            {"server_id_key_idx","server_id_key_idx"},
            {"schedule_id_key_2_idx","schedule_id_key_2_idx" }
        };


        private static readonly IDictionary<string, string> createTables = new Dictionary<string, string>()
        {
            {"backup_locations","CREATE TABLE "+tables["backup_locations"] + " (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,name VARCHAR(45) NULL DEFAULT NULL COLLATE NOCASE,username VARCHAR(45) NULL DEFAULT NULL COLLATE NOCASE,password VARCHAR(45) NULL DEFAULT NULL COLLATE NOCASE,path TEXT NULL COLLATE NOCASE)"},
            {"logs","CREATE TABLE "+tables["logs"] + " (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,schedule_id INTEGER NULL DEFAULT NULL ,type INTEGER NOT NULL ,message TEXT NULL COLLATE NOCASE,date DATETIME NULL DEFAULT NULL ,success INTEGER NULL DEFAULT NULL ,CONSTRAINT `schedule_id_key` FOREIGN KEY (`schedule_id`) REFERENCES schedules (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION)" },
            {"sqlservers","CREATE TABLE "+tables["sqlservers"] + " (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,name VARCHAR(80) NOT NULL COLLATE NOCASE,port INTEGER NOT NULL ,host TEXT NOT NULL COLLATE NOCASE,username VARCHAR(45) NOT NULL COLLATE NOCASE,password VARCHAR(45) NOT NULL COLLATE NOCASE)" },
            {"schedule_save_locations","CREATE TABLE "+tables["schedule_save_locations"] + " (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,schedule_id INTEGER NULL DEFAULT NULL ,service_type INTEGER NULL DEFAULT NULL ,backup_location_id INTEGER NULL DEFAULT NULL ,CONSTRAINT `backup_location_id_key` FOREIGN KEY (`backup_location_id`) REFERENCES backup_locations (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,CONSTRAINT `schedule_id_key4` FOREIGN KEY (`schedule_id`) REFERENCES schedules (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION)" },
            {"schedules","CREATE TABLE "+tables["schedules"] + " (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,server_id INTEGER NOT NULL ,name VARCHAR(45) NOT NULL COLLATE NOCASE,date DATETIME NULL DEFAULT NULL ,activated INTEGER NOT NULL ,hours INTEGER NOT NULL ,CONSTRAINT `server_id_key` FOREIGN KEY (`server_id`) REFERENCES sqlservers (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION)" },
            {"userinfo","CREATE TABLE "+tables["userinfo"] + "  (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,schedule_id INTEGER NULL DEFAULT NULL ,successemail VARCHAR(45) NULL DEFAULT NULL COLLATE NOCASE,failemail VARCHAR(45) NULL DEFAULT NULL COLLATE NOCASE,CONSTRAINT `shedule_id_key_2` FOREIGN KEY (`schedule_id`) REFERENCES schedules (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION)" }
        };

        private static readonly IDictionary<string, string> createIndices = new Dictionary<string, string>()
        {
            {"backup_location_id_key_idx","CREATE INDEX " + Indices["backup_location_id_key_idx"] + " backup_location_id_key_idx ON schedule_save_locations (`backup_location_id` DESC)"},
            {"schedule_id_key4_idx","CREATE INDEX "+ Indices["schedule_id_key4_idx"] + " CREATE INDEX schedule_id_key4_idx ON schedule_save_locations (`schedule_id` DESC)" },
            {"schedule_id_key_idx","CREATE INDEX " + Indices["schedule_id_key_idx"]  + " CREATE INDEX schedule_id_key_idx ON logs (`schedule_id` DESC)"},
            {"server_id_key_idx","CREATE INDEX " + Indices["server_id_key_idx"] + " CREATE INDEX server_id_key_idx ON schedules (`server_id` DESC)" },
            {"schedule_id_key_2_idx","CREATE INDEX " + Indices["schedule_id_key_2_idx"] + " CREATE INDEX shedule_id_key_2_idx ON userinfo (`schedule_id` DESC)" }
        };




        public static void createDbTables()
        {
            string datasource = "Data Source=.//resources//firedumpdb.db";
            if (IsTest)
            {
                if (OS.IsWindowsServer())
                {
                    conn = BUILD_SERVER_SQLITEDB;
                    datasource = BUILD_SERVER_DATASOURCE;
                }
            }
            
            if (!System.IO.File.Exists(conn))
            {
                SQLiteConnection.CreateFile(conn);
                using (SQLiteConnection con = new SQLiteConnection(datasource))
                {
                    con.Open();              
                    foreach(KeyValuePair<string,string> entry in tables)
                    {
                        if(!isTableExists(entry.Value))
                        {
                            using (SQLiteCommand command = new SQLiteCommand(createTables[entry.Key], con))
                            {
                                command.ExecuteNonQuery();
                            }
                        }                       
                    }                
                }
            }            
        }


        public static bool isTableExists(string table)
        {
            string datasource = "Data Source=.//resources//firedumpdb.db";
            if (IsTest)
            {
                if (OS.IsWindowsServer())
                {
                    conn = BUILD_SERVER_SQLITEDB;
                    datasource = BUILD_SERVER_DATASOURCE;
                }
            }

            string count = "0";
            if(table == null)
            {
                return false;
            }

            using (SQLiteConnection con = new SQLiteConnection(datasource))
            {
                con.Open();
                string sql = string.Format("SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = '{0}'",table);
                using (SQLiteCommand command = new SQLiteCommand(con))
                {
                    command.CommandText = sql;
                    object value = command.ExecuteScalar();
                    if(value != null)
                    {
                        count = value.ToString();
                    } else
                    {
                        count = "";
                    }

                    return Convert.ToInt32(count) > 0;
                }
            }
          
        }


    }


}
