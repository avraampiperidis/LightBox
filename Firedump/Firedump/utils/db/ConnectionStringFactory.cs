using Firedump.models.configuration.dynamicconfig;
using System;

namespace Firedump.models.dbUtils
{
    public sealed class ConnectionStringFactory
    {

       public ConnectionStringFactory()
       {
       }

        public static string connectionStringBuilder(sqlserver server, string database = null) =>
            connectionStringBuilder(server.host, server.username, server.password, database, server.port);

        public static string connectionStringBuilder(CredentialsConfig creds,string database = null) =>
            connectionStringBuilder(creds.host,creds.username,creds.password,database,creds.port);

        // string params order matters!
        public static string connectionStringBuilder(string host,string username,string password, string database,long port = 3306,int timeout = 120,string SslMode = "none") 
            =>
            "Server=" + host + ";" + (String.IsNullOrEmpty(database) ? "" : "database=" + database
                + ";Convert Zero Datetime=true;default command timeout=" + timeout + "") + ";UID=" + username
                + ";" + (!String.IsNullOrEmpty(password) ? "password=" + password : "") + ";port=" + port + ";SslMode=" + SslMode;

    }
}
