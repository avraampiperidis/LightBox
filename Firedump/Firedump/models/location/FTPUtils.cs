using Firedump.models.configuration.dynamicconfig;
using Firedump.utils;
using System;
using System.Collections.Generic;
using WinSCP;

namespace Firedump.models.location
{
    class FTPUtils
    {
        //<events>
        public delegate void progress(int progress, int speed);
        public event progress Progress;
        private void onProgress(int progress, int speed)
        {
            Progress?.Invoke(progress, speed);
        }
        //</events>
        private SessionOptions sessionOptions;
        private FTPCredentialsConfig config;
        private Session session;
        bool firstCheck = true;
        private FTPUtils() { }

        public FTPUtils(FTPCredentialsConfig config)
        {
            this.config = config;
            setupSessionOptions();
        }

        public void setupSessionOptions()
        {
            sessionOptions = new SessionOptions
            {
                HostName = config.host,
                UserName = config.username,
                Password = config.password,
                PortNumber = config.port,
            };
            if (config.useSFTP)
            {
                sessionOptions.Protocol = Protocol.Sftp;
                try
                {
                    sessionOptions.SshHostKeyFingerprint = config.SshHostKeyFingerprint;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                if (config.usePrivateKey)
                {
                    sessionOptions.SshPrivateKeyPath = config.privateKeyPath;
                }
            }
            else
            {
                sessionOptions.Protocol = Protocol.Ftp;
            }
            if (config.usePrivateKey)
            {
                sessionOptions.SshPrivateKeyPath = config.privateKeyPath;
            }
        }

        public void startSession()
        {
            try
            {
                session = new Session();
                checkFingerprint();
                session.Open(sessionOptions);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                if (firstCheck && e.Message.StartsWith("Host key does not match configured key"))
                {
                    compareFingerprint();
                    firstCheck = false;
                    startSession();
                }
            }
        }

        public void disposeSession()
        {
            try
            {
                session.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void checkFingerprint()
        {
            if (config.useSFTP && string.IsNullOrEmpty(sessionOptions.SshHostKeyFingerprint))
            {
                sessionOptions.SshHostKeyFingerprint = session.ScanFingerprint(sessionOptions);
                saveFingerprint(sessionOptions.SshHostKeyFingerprint);
            }
        }

        private void compareFingerprint()
        {
            if (config.useSFTP)
            {
                sessionOptions.SshHostKeyFingerprint = session.ScanFingerprint(sessionOptions);
                if (sessionOptions.SshHostKeyFingerprint != config.SshHostKeyFingerprint)
                {
                    saveFingerprint(sessionOptions.SshHostKeyFingerprint);
                }
            }
        }

        private void saveFingerprint(string fingerprint)
        {
            firedumpdbDataSetTableAdapters.backup_locationsTableAdapter adapter = new firedumpdbDataSetTableAdapters.backup_locationsTableAdapter();
            adapter.UpdateFingerprint(fingerprint, config.id);
        }

        /// <summary>
        /// A listener is not required for this method to work properly.
        /// startSession() must be called before this method is called.
        /// Call disposeSession() after the job is finished.
        /// </summary>
        /// <param name="path">Path of the directory to list</param>
        /// <param name="onlyDirectories">If set to true only directories in the directory will be listed</param>
        /// <param name="showHiddenFiles">If set to true files with a name starting with . with be displayed</param>
        /// <returns>A list of Fileinfos</returns>
        public List<RemoteFileInfo> getDirectoryListing(string path, bool onlyDirectories, bool showHiddenFiles)
        {
            List<RemoteFileInfo> files = new List<RemoteFileInfo>();
            try
            {
                RemoteDirectoryInfo directory = session.ListDirectory(path);
                foreach(RemoteFileInfo file in directory.Files)
                {   //    this part excludes files                this excludes . and ..                     this excludes files starting with . 
                    if(!(!file.IsDirectory && onlyDirectories) && file.Name!="." && file.Name!=".." && !(!showHiddenFiles && file.Name.StartsWith(".")))
                    {
                        files.Add(file);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return files;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Empty string for success or the exception message</returns>
        public LocationConnectionResultSet testConnection()
        {
            LocationConnectionResultSet result = new LocationConnectionResultSet();
            try
            {
                session = new Session();
                if (config.useSFTP)
                {
                    result.sshHostKeyFingerprint = session.ScanFingerprint(sessionOptions);
                    sessionOptions.SshHostKeyFingerprint = result.sshHostKeyFingerprint;
                }
                session.Open(sessionOptions);
                result.wasSuccessful = true;
            }
            catch (Exception ex)
            {
                result.errorMessage = ex.Message;
            }
            finally
            {
                session.Dispose();
            }
            return result;
        }


        /// <summary>
        /// To location path prepei na einai directory
        /// Location path tis morfis /home/user/filename
        /// </summary>
        public LocationResultSet sendFile()
        {
            LocationResultSet result = new LocationResultSet();
            try
            {
                session = new Session();

                session.FileTransferProgress += sessionFileTransferProgress;
                checkFingerprint();

                string[] locationinfo = StringUtils.splitPath(config.locationPath);
                string[] sourceinfo = StringUtils.splitPath(config.sourcePath);
                string ext = StringUtils.getExtension(sourceinfo[1]);

                session.Open(sessionOptions);
                

                //mporeis na peirakseis ta dikaiwmata tou arxeiou
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;

                TransferOperationResult transferResult;             
                transferResult = session.PutFiles(config.sourcePath,locationinfo[0], false, transferOptions);

                transferResult.Check(); //Prepei na kanei throw exception se periptwsi fail iparxei kai transferResult.isSuccess den to exw testarei
                try
                {
                    session.ExecuteCommand("rm "+ locationinfo[0] + locationinfo[1] + ext);
                }
                catch(Exception ex)
                {

                }
                session.MoveFile(locationinfo[0]+sourceinfo[1],locationinfo[0]+locationinfo[1]+ext);

                /* ama ithela na xeiristw results apo transfers polaplwn arxeiwn
                foreach (TransferEventArgs transfer in transferResult.Transfers)
                {
                    Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
                }*/

                result.wasSuccessful = true;
                result.path = locationinfo[0] + locationinfo[1] + ext;
            }
            catch(Exception ex)
            {
                if (firstCheck && ex.Message.StartsWith("Host key does not match configured key"))
                {
                    compareFingerprint();
                    firstCheck = false;
                    sendFile();
                }
                else
                {
                    result.wasSuccessful = false;
                    result.errorMessage = ex.Message;
                }
            }
            finally
            {
                session.Dispose();
            }
            return result;
        }

        /// <summary>
        /// Sto config sourcePath einai tou server kai to locationPath prepei na einai directory
        /// </summary>
        public LocationResultSet getFile()
        {
            LocationResultSet result = new LocationResultSet();
            try
            {
                session = new Session();

                session.FileTransferProgress += sessionFileTransferProgress;
                checkFingerprint();

                session.Open(sessionOptions);

                session.GetFiles(config.sourcePath, config.locationPath).Check();

                result.wasSuccessful = true;
                result.path = config.locationPath;
            }
            catch (Exception ex)
            {
                if (firstCheck && ex.Message.StartsWith("Host key does not match configured key"))
                {
                    compareFingerprint();
                    firstCheck = false;
                    sendFile();
                }
                else
                {
                    result.wasSuccessful = false;
                    result.errorMessage = ex.Message;
                }
            }
            finally
            {
                session.Dispose();
            }
            return result;
        }

        private void sessionFileTransferProgress(object sender, FileTransferProgressEventArgs e)
        {
            onProgress(Convert.ToInt32(e.OverallProgress*100), e.CPS);
        }
    }
}
