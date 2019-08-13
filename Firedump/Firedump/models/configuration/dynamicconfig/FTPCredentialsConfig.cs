using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.dynamicconfig
{
    public class FTPCredentialsConfig : LocationCredentialsConfig
    {
        public FTPCredentialsConfig()
        { }
        public FTPCredentialsConfig(string host,int port,bool usePrivateKey,string privateKeyPath, string sshHostKeyFingerprint,string username,string password,bool useSFTP)
            :base(host, port, username,password)
        {
            this.usePrivateKey = usePrivateKey;
            this.privateKeyPath = privateKeyPath;
            this.SshHostKeyFingerprint = sshHostKeyFingerprint;
            this.useSFTP = useSFTP;
        }
        public Int64 id { set; get; }
        public bool useSFTP { set; get; }
        public string SshHostKeyFingerprint { set; get; }
        /// <summary>
        /// Use private key for SFTP login (useSFTP must be true or this is disregarded)
        /// If used privateKeyPath must also be set
        /// </summary>
        public bool usePrivateKey { set; get; }
        /// <summary>
        /// The path to the private key file
        /// </summary>
        public string privateKeyPath { set; get; }
    }
}
