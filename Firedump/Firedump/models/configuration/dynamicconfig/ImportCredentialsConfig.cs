using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.dynamicconfig
{
    public class ImportCredentialsConfig : CredentialsConfig
    {
        public string database { set; get; }
        public string scriptPath { set; get; }
        public string scriptDelimeter { set; get; } = ";";
    }
}
