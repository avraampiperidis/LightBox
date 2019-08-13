using Firedump.models.configuration.dynamicconfig;
using System;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    class LocationAdapter
    {
        //<events>

        //onProgress
        public delegate void progress(int progress, int speed);
        public event progress Progress;
        private void onProgress(int progress, int speed)
        {
            Progress?.Invoke(progress, speed);
        }

        //onSaveInit
        public delegate void saveInit();
        public event saveInit SaveInit;
        private void onSaveInit()
        {
            SaveInit?.Invoke();
        }

        //onSaveComplete
        public delegate void saveComplete(LocationResultSet result);
        public event saveComplete SaveComplete;
        private void onSaveComplete(LocationResultSet result)
        {
            SaveComplete?.Invoke(result);
        }

        //onSaveError
        public delegate void saveError(string message);
        public event saveError SaveError;
        private void onSaveError(string message)
        {
            SaveError?.Invoke(message);
        }

        //onTestConnectionComplete
        public delegate void testConnectionComplete(LocationConnectionResultSet result);
        public event testConnectionComplete TestConnectionComplete;
        private void onTestConnectionComplete(LocationConnectionResultSet result)
        {
            TestConnectionComplete?.Invoke(result);
        }

        //</events>
        private ILocation location;
        private Task<LocationConnectionResultSet> innerconnectiontask;
        private Task<LocationResultSet> innersendtask;
        private Task<LocationResultSet> innergettask;
        private int locationId = -1;

        public LocationAdapter() { }

        public void setLocalLocation(LocationCredentialsConfig config) //auta na kanoun try catch gia to cast kai na kaloun onError se fail
        {
            this.location = new LocationLocal();
            ((LocationLocal)this.location).config = config;
            ((LocationLocal)this.location).Progress += progressHandler;
        }

        public void setFtpLocation(LocationCredentialsConfig config)
        {
            this.location = new LocationFtp();
            ((LocationFtp)this.location).config = config;
            ((LocationFtp)this.location).Progress += progressHandler;
        }
        public void setCloudBoxLocation(DropBoxCredentials config)
        {
            this.location = new LocationCloudBox();
            ((LocationCloudBox)this.location).config = config;
            ((LocationCloudBox)this.location).Progress += progressHandler;
        }
        public void setCloudDriveLocation(LocationCredentialsConfig config)
        {
            this.location = new LocationCloudDrive();
            ((LocationCloudDrive)this.location).config = config;
            ((LocationCloudDrive)this.location).Progress += progressHandler;
        }
        /// <summary>
        /// Prosoxi den einai ilopoihmeni padou mporei na petaksei not implemented exception
        /// ama kalestei gia LocationLocal px
        /// </summary>
        public void testConnection()
        {
            if (this.location == null)
            {
                onSaveError("Location type not set. Aborting...");
                return;
            }
            

            Task testcontask = new Task(testConnectionExecutor);
            testcontask.Start();
        }
        private async void testConnectionExecutor()
        {
            if (innerconnectiontask != null && !innerconnectiontask.IsCompleted) //ama spammarei test connection tha stamataei edw
            {
                onSaveError("Another test connection is running please wait");
                return;
            }
            innerconnectiontask = new Task<LocationConnectionResultSet>(location.connect);
            LocationConnectionResultSet res;
            innerconnectiontask.Start();

            try
            {
                res = await innerconnectiontask;
                onTestConnectionComplete(res);
            }
            catch (NullReferenceException) { }
        }

        internal void setLocationId(int v)
        {
            locationId = v;
        }

        public void sendFile()
        {
            if (this.location == null)
            {
                onSaveError("Location type not set. Aborting...");
                return;
            }

            Task task = new Task(sendFileTaskExecutor);
            task.Start();
        }

        public void getFile()
        {
            if (this.location == null)
            {
                onSaveError("Location type not set. Aborting...");
                return;
            }

            Task task = new Task(getFileTaskExecutor);
            task.Start();
        }

        private async void sendFileTaskExecutor()
        {
            if (innersendtask != null && !innersendtask.IsCompleted)
            {
                onSaveError("Another task is running. Aborting...");
                return;
            }

            innersendtask = new Task<LocationResultSet>(location.send);
            LocationResultSet res;
            innersendtask.Start();  
                    
            try
            {
                res = await innersendtask;
                onSaveComplete(res);
            }
            catch (NullReferenceException) { }

        }

        private async void getFileTaskExecutor()
        {
            if (innergettask != null && !innergettask.IsCompleted)
            {
                onSaveError("Another task is running. Aborting...");
                return;
            }

            innergettask = new Task<LocationResultSet>(location.getFile);
            LocationResultSet res;
            innergettask.Start();
            try
            {
                res = await innergettask;
                onSaveComplete(res);
            }
            catch (NullReferenceException) { }
        }

        private void progressHandler(int progress, int speed)
        {
            onProgress(progress, speed);
        }

        internal bool isLocationRunning(long id)
        {
            return locationId == id;
        }
    }
}
