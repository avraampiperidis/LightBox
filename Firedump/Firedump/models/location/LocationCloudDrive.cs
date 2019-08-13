using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    class LocationCloudDrive : Location,ILocationCloud
    {
        //<events>
        public delegate void progress(int progress, int speed);
        public event progress Progress;
        private void onProgress(int progress, int speed)
        {
            Progress?.Invoke(progress, speed);
        }
        //</events>
        public LocationCredentialsConfig config { set; get; }
        public LocationCloudDrive() { }
        public LocationConnectionResultSet connect()
        {
            throw new NotImplementedException();
        }

        public LocationConnectionResultSet connect(object o)
        {
            throw new NotImplementedException();
        }

        public void doExtraStuff()
        {
            throw new NotImplementedException();
        }

        public LocationResultSet getFile()
        {
            throw new NotImplementedException();
        }

        public LocationResultSet send()
        {
            throw new NotImplementedException();
        }

        public void setExtraCredentials()
        {
            throw new NotImplementedException();
        }
    }
}
