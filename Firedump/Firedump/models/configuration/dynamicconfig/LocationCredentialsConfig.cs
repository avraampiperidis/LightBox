using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.dynamicconfig
{
    public class LocationCredentialsConfig : CredentialsConfig
    {
        public LocationCredentialsConfig() { }
        public LocationCredentialsConfig(string host, int port, string username, string password):base(host,port,username,password)
        {
        }

        public string sourcePath { set; get; }
        public string locationPath { set; get; }
    }
}
