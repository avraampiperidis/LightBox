using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.factories
{
    sealed class MySqlConnectionStringBuilder
    {
        internal static string connectionStringBuilder(sqlservers server, string database = null) =>
            connectionStringBuilder(server.host, server.username, server.password, database, server.port);

        // string params order matters!
        internal static string connectionStringBuilder(string host, string username, string password, string database, long port = 3306, int timeout = 120, string SslMode = "none")
            =>
            "Server=" + host + ";" + (String.IsNullOrEmpty(database) ? "" : "database=" + database
                + ";Convert Zero Datetime=true;default command timeout=" + timeout + "") + ";UID=" + username
                + ";" + (!String.IsNullOrEmpty(password) ? "password=" + password : "") + ";port=" + port + ";SslMode=" + SslMode;

    }
}
