using Firedump.models.pojos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    public class LocationConnectionResultSet : BaseStatus
    {
        public LocationConnectionResultSet() : base() { }
        public string sshHostKeyFingerprint { set; get; }
    }
}
