using Firedump.models.configuration.dynamicconfig;
using System;


namespace Firedump.models.location
{
    class LocationFtp : Location , ILocation
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
        public LocationFtp() { }
        public LocationConnectionResultSet connect()
        {
            FTPUtils ftputils = new FTPUtils((FTPCredentialsConfig)config);
            ftputils.Progress += progressHandler;
            LocationConnectionResultSet result = ftputils.testConnection();
            return result;
        }

        public LocationConnectionResultSet connect(object o)
        {
            throw new NotImplementedException();
        }

        public LocationResultSet getFile()
        {
            FTPUtils ftputils = new FTPUtils((FTPCredentialsConfig)config);
            ftputils.Progress += progressHandler;
            LocationResultSet result = ftputils.getFile();
            return result;
        }

        public LocationResultSet send()
        {
            FTPUtils ftputils = new FTPUtils((FTPCredentialsConfig)config);
            ftputils.Progress += progressHandler;
            LocationResultSet result = ftputils.sendFile();
            return result;
        }

        private void progressHandler(int progress, int speed)
        {
            onProgress(progress, speed);
        }
    }
}
