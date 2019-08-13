using Firedump.models.configuration.dynamicconfig;
using Firedump.models.configuration.jsonconfig;
using Firedump.models.dump;
using Firedump.models.location;
using Firedump.utils;
using System;
using System.Data;
using System.IO;

namespace Firedump.models.sqlimport
{
    class ImportAdapterManager
    {
        //<events>

        //onInnerProccessInit
        public delegate void innerProccessInit(int proc_type, int maxprogress);
        public event innerProccessInit InnerProccessInit;
        private void onInnerProccessInit(int proc_type, int maxprogress)
        {
            InnerProccessInit?.Invoke(proc_type,maxprogress);
        }

        //onImportProgress
        public delegate void importProgress(int progress, int speed);
        public event importProgress ImportProgress;
        private void onImportProgress(int progress, int speed)
        {
            ImportProgress?.Invoke(progress, speed);
        }

        //onImportInit
        public delegate void importInit(int maxprogress);
        public event importInit ImportInit;
        private void onImportInit(int maxprogress)
        {
            ImportInit?.Invoke(maxprogress);
        }

        //onImportComplete
        public delegate void importComplete(ImportResultSet result);
        public event importComplete ImportComplete;
        private void onImportComplete(ImportResultSet result)
        {
            ImportComplete?.Invoke(result);
        }

        //onImportError
        public delegate void importError(string message);
        public event importError ImportError;
        private void onImportError(string message)
        {
            ImportError?.Invoke(message);
        }

        //</events>
        private string path;
        private string templocalpath;
        private string templocalfilename;
        private string filename;
        private string decompressDirectory;
        private string filetoimport;
        private DataRow locationdata;
        private ImportCredentialsConfig importconfig;
        private bool isLocal;
        private bool isCompressed;
        private bool isEncrypted;
        private string password;
        private LocationAdapter locationadapter;
        private CompressionAdapter compressionadapter;
        private ImportAdapter importadapter;
        private ImportAdapterManager() { }
        public ImportAdapterManager(string path, bool isLocal, bool isCompressed,bool isEncrypted, string password, DataRow locationdata,ImportCredentialsConfig importconfig)
        {
            string[] splitpath = StringUtils.splitPath(path);
            this.path = splitpath[0];
            this.filename = splitpath[1];
            this.isLocal = isLocal;
            this.isCompressed = isCompressed;
            this.isEncrypted = isEncrypted;
            this.password = password;
            this.locationdata = locationdata;
            this.importconfig = importconfig;
        }

        public void startImport()
        {
            if (isLocal)
            {
                if (!File.Exists(path+filename))
                {
                    onImportError("File doesnt exist, path: "+path);
                    return;
                }
                templocalpath = path;
                templocalfilename = filename;
                startDecompression();
            }
            else
            {
                //set config
                locationadapter = new LocationAdapter();
                locationadapter.Progress += downloadProgressHandler;
                locationadapter.SaveComplete += downloadCompleteHandler;
                locationadapter.SaveError += downloadErrorHandler;
                LocationCredentialsConfig config;
                templocalpath = ConfigurationManager.getInstance().mysqlDumpConfigInstance.getSettings().tempSavePath;
                //calculate local path
                if(!File.Exists(path + filename))
                {
                    templocalfilename = filename;
                }
                else
                {
                    Random rnd = new Random();
                    string extension = StringUtils.getExtension(filename);
                    templocalfilename = "Temp" + rnd.Next(1000000, 9999999) + extension;

                    Directory.CreateDirectory(templocalpath);


                    //checking if file exists
                    while (File.Exists(templocalpath + templocalfilename))
                    {
                        templocalfilename = "Temp" + rnd.Next(1000000, 9999999) + extension;
                    }
                }
                try
                {
                    long type = (Int64)locationdata["service_type"];
                    switch (type) //edw gemizei to config apo to database prepei na kanei diaforetiko query gia kathe diaforetiko type kai na gemisei to config prin to settarei ston adapter
                    {
                        case 0: //file system
                            //De ginete na einai file system kai na erthei edw
                            break;
                        case 1: //FTP
                            config = new FTPCredentialsConfig();
                            config.sourcePath = path + filename;
                            config.locationPath = templocalpath + templocalfilename;
                            ((FTPCredentialsConfig)config).id = (Int64)locationdata["id"];
                            ((FTPCredentialsConfig)config).host = (string)locationdata["host"];
                            config.port = unchecked((int)(Int64)locationdata["port"]);
                            config.username = (string)locationdata["username"];
                            config.password = (string)locationdata["password"];
                            Int64 useSFTP = (Int64)locationdata["usesftp"];
                            if (useSFTP == 1)
                            {
                                ((FTPCredentialsConfig)config).useSFTP = true;
                                ((FTPCredentialsConfig)config).SshHostKeyFingerprint = (string)locationdata["ssh_key_fingerprint"];
                            }
                            string keypath = (string)locationdata["ssh_key"];
                            if (!string.IsNullOrEmpty(keypath))
                            {
                                ((FTPCredentialsConfig)config).usePrivateKey = true;
                                ((FTPCredentialsConfig)config).privateKeyPath = keypath;
                            }
                            locationadapter.setFtpLocation(config);
                            break;
                        case 2: //Dropbox
                            DropBoxCredentials boxcreds = new DropBoxCredentials();
                            //EDW SETUP TO CONFIG
                            locationadapter.setCloudBoxLocation(boxcreds);
                            break;
                        case 3: //Google drive
                            config = new LocationCredentialsConfig();
                            //EDW SETUP TO CONFIG
                            locationadapter.setCloudDriveLocation(config);
                            break;
                        default:
                            onImportError("Location type unknown");
                            return;
                    }

                    onInnerProccessInit(Convert.ToInt32(type),100);
                    locationadapter.getFile();
                }
                catch (InvalidCastException ex)
                {
                    onImportError("Save location data load failed:\n"+ex.Message);
                }

                
                

            }

        }

        private void startDecompression()
        {
            if (isCompressed)
            {
                CompressionConfig config = new CompressionConfig();
                config.absolutePath = templocalpath + templocalfilename;
                decompressDirectory = templocalpath + templocalfilename.Replace(StringUtils.getExtension(templocalfilename), "") + "\\";
                config.decompressDirectory = decompressDirectory;
                config.isEncrypted = isEncrypted;
                config.password = password;
                compressionadapter = new CompressionAdapter(config);
                compressionadapter.CompressComplete += onCompressCompleteHandler;
                compressionadapter.CompressError += onCompressErrorHandler;
                compressionadapter.CompressProgress += onCompressProgressHandler;
                compressionadapter.CompressStart += onCompressStartHandler;

                compressionadapter.decompress();
            }
            else
            {
                startImportProccess();
            }
        }

        private void startImportProccess()
        {
            if (isCompressed)
            {
                importconfig.scriptPath = decompressDirectory + filetoimport;
            }
            else
            {
                importconfig.scriptPath = templocalpath + templocalfilename;
            }
            importadapter = new ImportAdapter(importconfig);
            importadapter.ImportComplete += onImportCompleteHandler;
            importadapter.ImportError += onImportErrorHandler;
            importadapter.ImportInit += onImportInitHandler;
            importadapter.ImportProgress += onImportProgressHandler;
            importadapter.executeScript();
        }

        public void cancel()
        {

        }

        private void deletefiles()
        {
            try
            {
                if (!isLocal)
                {
                    File.Delete(templocalpath + templocalfilename);
                }
                if (!string.IsNullOrEmpty(decompressDirectory))
                {
                    Directory.Delete(decompressDirectory, true);
                }
            }
            catch (Exception ex) { }
        }

        //<event handlers>

        //DOWNLOAD
        private void downloadProgressHandler(int progress, int speed)
        {
            onImportProgress(progress,speed);
        }

        private void downloadCompleteHandler(LocationResultSet result)
        {
            if (result.wasSuccessful)
            {
                startDecompression();
            }
            else
            {               
                try
                {
                    File.Delete(templocalpath + templocalfilename);
                }
                catch (Exception ex)
                {

                }
                onImportError(result.errorMessage);
            }
        }

        private void downloadErrorHandler(string message)
        {
            onImportError(message);
        }

        //DECOMPRESSION
        private void onCompressProgressHandler(int progress)
        {
            onImportProgress(progress, -1);
        }

        private void onCompressStartHandler()
        {
            onInnerProccessInit(10, 100);
        }

        private void onCompressCompleteHandler(CompressionResultSet result)
        {
            if (result.wasSuccessful)
            {
                string[] filesinarchive = Directory.GetFiles(decompressDirectory);
                int sqlcounter = 0;
                foreach (string file in filesinarchive)
                {
                    if (file.EndsWith(".sql"))
                    {
                        sqlcounter++;
                        filetoimport = StringUtils.splitPath(file)[1];
                    }
                }
                if (sqlcounter!=1)
                {
                    deletefiles();
                    onImportError("Found "+sqlcounter+ " .sql files in the decompressed directory.\nThe archive must contain only one .sql file.");
                    return;
                }

                startImportProccess();
            }
            else
            {
                onImportError("Decompression proccess exited with errors:\n"+result.standardError);
            }
        }

        private void onCompressErrorHandler(string message)
        {
            onImportError(message);
        }

        //SQLIMPORT
        private void onImportInitHandler(int maxprogress)
        {
            onImportInit(maxprogress);
        }

        private void onImportProgressHandler(int progress)
        {
            onImportProgress(progress,-1);
        }

        private void onImportCompleteHandler(ImportResultSet result)
        {
            deletefiles();
            onImportComplete(result);
        }

        private void onImportErrorHandler(string message)
        {
            onImportError(message);
        }

        //</event handlers>
    }
}
