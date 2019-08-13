using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.dynamicconfig
{
    public class DropBoxCredentials
    {
        public DropBoxCredentials() { }

        public string Name { get; set; }

        public string FileName { get; set; }

        public string Token { get; set; }

        public string Path { get; set; }

        public string LocalFilePath { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }

}
