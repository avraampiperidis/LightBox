using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Firedump.models.location
{
    class LocationAdapterManager 
    {
        //<events>

        //onSaveProgress
        public delegate void saveProgress(int progress, int speed);
        public event saveProgress SaveProgress;
        private void onSaveProgress(int progress, int speed)
        {
            SaveProgress?.Invoke(progress, speed);
        }

        //onSaveInit
        public delegate void saveInit(int maxprogress);
        public event saveInit SaveInit;
        private void onSaveInit(int maxprogress)
        {
            SaveInit?.Invoke(maxprogress);
        }

        //onSaveComplete
        public delegate void saveComplete(List<LocationResultSet> results);
        public event saveComplete SaveComplete;
        private void onSaveComplete(List<LocationResultSet> results)
        {
            SaveComplete?.Invoke(results);
        }

        //onSaveError
        public delegate void saveError(string message);
        public event saveError SaveError;
        private void onSaveError(string message)
        {
            SaveError?.Invoke(message);
        }

        //onInnerSaveInit
        public delegate void innerSaveInit(string location_name, int location_type);
        public event innerSaveInit InnerSaveInit;
        private void onInnerSaveInit(string location_name, int location_type)
        {
            InnerSaveInit?.Invoke(location_name,location_type);
        }

        //onLocationProgress
        public delegate void locationProgress(int progress, int speed);
        public event locationProgress LocationProgress;
        private void onLocationProgress(int progress, int speed)
        {
            LocationProgress?.Invoke(progress, speed);
        }

        //</events>
        private List<int> locations;
        private List<LocationResultSet> results;
        private LocationAdapter adapter;
        private firedumpdbDataSetTableAdapters.backup_locationsTableAdapter backup_adapter = new firedumpdbDataSetTableAdapters.backup_locationsTableAdapter(); //malon tha xreiastei adapter pou tha einai join pinakwn tha doume
        private int currentProgress = 0;
        private string sourcePath;
        private LocationAdapterManager() { }
        public LocationAdapterManager(List<int> locations, string sourcePath)
        {
            this.locations = locations;
            this.sourcePath = sourcePath;
            init();
        }
        private void init()
        {
            results = new List<LocationResultSet>();
        }

        public void setProgress()
        {
            onSaveInit(locations.Count * 100); //set to max progress px gia 2 locations 200
        }
        private void setupForNewSave()
        {
            currentProgress += 100;
            if (locations.Count > 0)
            {
                locations.RemoveAt(0);
            }

            if (locations.Count > 0) //teliki sinthiki tou adapter
            {
                startSave();
            }
            else
            {
                try
                {
                    File.Delete(sourcePath);
                }
                catch(Exception e){ }
                onSaveComplete(results);
            }
        }

        public void startSave() //thelei douleia afti
        {
            if(locations.Count == 0)
            {
                onSaveError("Save started with no locations");
                return;
            }
            LocationCredentialsConfig config;
            DataTable data = backup_adapter.GetDataByID(locations[0]);
            if (data.Rows.Count == 0)
            {
                onSaveError("Location not found in the database");
                return;
            }
            long type = (Int64)data.Rows[0]["service_type"];
            adapter = new LocationAdapter();
            adapter.Progress += onSaveProgressHandler;
            adapter.SaveComplete += onSaveCompleteHandler;
            adapter.SaveError += onSaveErrorHandler;
            adapter.setLocationId(locations[0]);
            switch (type) //edw gemizei to config apo to database prepei na kanei diaforetiko query gia kathe diaforetiko type kai na gemisei to config prin to settarei ston adapter
            {              
                case 0: //file system
                    config = new LocationCredentialsConfig();
                    config.sourcePath = sourcePath;
                    config.locationPath = (string)data.Rows[0]["path"];
                    adapter.setLocalLocation(config);
                    break;
                case 1: //FTP
                    config = new FTPCredentialsConfig();
                    config.sourcePath = sourcePath;
                    config.locationPath = (string)data.Rows[0]["path"]+(string)data.Rows[0]["filename"];
                    ((FTPCredentialsConfig)config).id = (Int64)data.Rows[0]["id"];
                    ((FTPCredentialsConfig)config).host = (string)data.Rows[0]["host"];
                    config.port = unchecked((int)(Int64)data.Rows[0]["port"]);
                    config.username = (string)data.Rows[0]["username"];
                    config.password = (string)data.Rows[0]["password"];
                    Int64 useSFTP = (Int64)data.Rows[0]["usesftp"];
                    if (useSFTP == 1)
                    {
                        ((FTPCredentialsConfig)config).useSFTP = true;
                        ((FTPCredentialsConfig)config).SshHostKeyFingerprint = (string)data.Rows[0]["ssh_key_fingerprint"];
                    }
                    string keypath = (string)data.Rows[0]["ssh_key"];
                    if (!string.IsNullOrEmpty(keypath))
                    {
                        ((FTPCredentialsConfig)config).usePrivateKey = true;
                        ((FTPCredentialsConfig)config).privateKeyPath = keypath;
                    }
                    adapter.setFtpLocation(config);
                    break;
                case 2: //Dropbox
                    DropBoxCredentials boxcreds = new DropBoxCredentials();
                    boxcreds.Path = (string)data.Rows[0]["path"];
                    boxcreds.Name = (string)data.Rows[0]["name"];
                    boxcreds.FileName = (string)data.Rows[0]["filename"];
                    boxcreds.Token = (string)data.Rows[0]["access_token"];
                    boxcreds.LocalFilePath = sourcePath;
                    //EDW SETUP TO CONFIG
                    adapter.setCloudBoxLocation(boxcreds);
                    break;
                case 3: //Google drive
                    config = new LocationCredentialsConfig();
                    //EDW SETUP TO CONFIG
                    adapter.setCloudDriveLocation(config);
                    break;
                default:
                    onSaveError("Location type unknown");
                    return;
            }

            onInnerSaveInit((string)data.Rows[0]["name"],unchecked((int)type));
            Task managersendtask = new Task(adapter.sendFile);
            managersendtask.Start();
        }
        
        private void onSaveCompleteHandler(LocationResultSet result)
        {
            results.Add(result);
            setupForNewSave();
        }

        private void onSaveErrorHandler(string message)
        {
            LocationResultSet result = new LocationResultSet();
            result.wasSuccessful = false;
            result.errorMessage = message;
            results.Add(result);
            setupForNewSave();
        }

        private void onSaveProgressHandler(int progress, int speed)
        {
            onSaveProgress(currentProgress+progress, speed);
            //for the current location upload
            onLocationProgress(progress,speed);
        }

        internal void cancelSaveLocation(firedumpdbDataSet.backup_locationsRow tag)
        {           
                if (locations.Contains((Int32)tag.id))
                {
                    locations.Remove((Int32)tag.id);
                    currentProgress += 100;
                }                 
        }

        internal bool isLocationFinished(firedumpdbDataSet.backup_locationsRow row)
        {
            
            return (!locations.Contains((int)row.id) && !adapter.isLocationRunning((int)row.id));
        }

        internal bool isLocationRunning(firedumpdbDataSet.backup_locationsRow row)
        {
            return adapter.isLocationRunning(row.id);
        }

        
    }
}
