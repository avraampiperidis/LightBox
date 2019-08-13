using Dropbox.Api;
using Dropbox.Api.Files;
using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    class LocationCloudBox : Location,ILocationCloud
    {
        //<events>
        public delegate void progress(int progress, int speed);
        public event progress Progress;
        private void onProgress(int progress, int speed)
        {
            Progress?.Invoke(progress, speed);
        }
        //</events>
        public DropBoxCredentials config { set; get; }
        private DropboxClient dbx;
        private LocationResultSet res = new LocationResultSet();
        public LocationCloudBox() { }
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
            return Upload();
        }

        private  LocationResultSet Upload()
        {
            try {
                var uploadTask = UploadTask();

                uploadTask.Wait();
                Console.WriteLine(res.wasSuccessful);
                return res;
            }catch(Exception ex)
            {
                res = new LocationResultSet();
                res.wasSuccessful = false;               
            }
            return res;
        }


        private async Task UploadTask()
        {
            Console.WriteLine(config.LocalFilePath);
            string content = File.ReadAllText(config.LocalFilePath);
            using (var mem = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                dbx = new DropboxClient(config.Token);
                var updated = await dbx.Files.UploadAsync(
                    config.Path + "/" + config.FileName,
                    WriteMode.Overwrite.Instance,
                    body: mem);

                res = new LocationResultSet();
                res.wasSuccessful = updated.IsFile;
                res.path = config.Path;                         
            }
        }

       
        public void setExtraCredentials()
        {
            throw new NotImplementedException();
        }
    }
}
