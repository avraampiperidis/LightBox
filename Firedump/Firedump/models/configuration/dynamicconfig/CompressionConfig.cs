using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.dynamicconfig
{
    class CompressionConfig
    {
        public string absolutePath { set; get; }
        public string decompressDirectory { set; get; }
        public bool isEncrypted { set; get; }
        public string password { set; get; }
    }
}
