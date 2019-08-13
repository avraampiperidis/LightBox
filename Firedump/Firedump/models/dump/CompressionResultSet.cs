using Firedump.models.pojos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dump
{
    public class CompressionResultSet : BaseStatus
    {
        public CompressionResultSet() : base() { }
        public string resultAbsPath { set; get; }
        public string standardError { set; get; }
    }
}
