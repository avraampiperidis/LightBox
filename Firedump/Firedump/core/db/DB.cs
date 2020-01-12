using Firedump.core.sql;
using Firedump.models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Common;

namespace Firedump.core.db
{
    public sealed class DB
    {
        public DB()
        {
        }

        public static ConnectionResultSet TestConnection(sqlservers server, string database = null)
        {
            try
            {
                using (var con = new DbConnectionFactory(server, ConnectionStringFactory.CreateConnectionString(server, database)).Create())
                {
                    con.Open();
                }
            }
            catch (Exception ex)
            {
                return new ConnectionResultSet(ex);
            }
            return new ConnectionResultSet();
        }

        public static DbConnection connect(sqlservers server, string database = null)
        {
            var con = new DbConnectionFactory(server, ConnectionStringFactory.CreateConnectionString(server, database)).Create();
            con.Open();
            return con;
        }

        internal static DbConnection connect(CredentialsConfig creds, string database = null)
        {
            return connect(new sqlservers(creds), database);
        }

        internal static ConnectionResultSet TestConnection(CredentialsConfig creds, string database = null)
        {
            return TestConnection(new sqlservers(creds), database);
        }


        internal static void close(DbConnection con)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        internal static void SetAutoCommit(DbConnection con, bool autoCommit)
        {
            using (var command = new DbCommandFactory(con, "set autocommit=" + (autoCommit == true ? "1" : "0")).Create())
            {
                command.ExecuteNonQuery();
            }
        }

        internal static void Rollback(DbConnection con)
        {
            using (var command = new DbCommandFactory(con, "rollback").Create())
            {
                command.ExecuteNonQuery();
            }
        }

        internal static void Commit(DbConnection con)
        {
            using (var command = new DbCommandFactory(con, "commit").Create())
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
