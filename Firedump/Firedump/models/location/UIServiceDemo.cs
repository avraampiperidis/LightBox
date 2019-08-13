using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using WinSCP;

namespace Firedump.models.location
{
    class UIServiceDemo
    {

        public UIServiceDemo() { }
        public void demo()
        {         
            LocationAdapterManager adapter = new LocationAdapterManager(new List<int> { 2,3,4,5}, "K:\\MyStuff\\summer season 2015 checkout\\[Ajin2.com] Ajin Season 2 Episode 4 [720p].mkv");
            adapter.startSave();
        }

        public void demoFTP()
        {
            FTPCredentialsConfig config = new FTPCredentialsConfig();
            config.host = "cspeitch.com";
            config.port = 22;
            config.username = "";
            config.password = "";
            config.sourcePath = "D:\\MyStuff\\DSC_0133.JPG";
            config.locationPath = "/home/cspeitch/eikona";
            config.SshHostKeyFingerprint = "";
            config.useSFTP = true;

            FTPUtils ftp = new FTPUtils(config);         
            ftp.startSession();
            List<RemoteFileInfo> files = ftp.getDirectoryListing("/", false, false);
            foreach(RemoteFileInfo file in files)
            {
                Console.WriteLine(file.IsDirectory+" "+file.Name);
            }
            Console.WriteLine();
            files = ftp.getDirectoryListing("/home/cspeitch", false, false);
            foreach (RemoteFileInfo file in files)
            {
                Console.WriteLine(file.IsDirectory + " " + file.Name);
            }
            Console.WriteLine();
            files = ftp.getDirectoryListing("/home/cspeitch/animeapp", false, false);
            foreach (RemoteFileInfo file in files)
            {
                Console.WriteLine(file.IsDirectory + " " + file.Name);
            }
            Console.WriteLine();
            ftp.disposeSession();

        }

        public void onInnerSaveInit(string location, int location_type)
        {
            Console.WriteLine("Inner save init: "+location);
        }

        public void onLocationProgress(int progress,int speed)
        {
            throw new NotImplementedException();
        }

        public void onProgress(int progress, int speed)
        {
            Console.WriteLine(progress + " " + speed);
        }

        public void onSaveComplete(List<LocationResultSet> results)
        {

            Console.WriteLine("Save Completed!");
            Console.WriteLine("Results:");
            foreach(LocationResultSet result in results)
            {
                Console.WriteLine(result.wasSuccessful);
                if(!result.wasSuccessful)
                Console.WriteLine(result.errorMessage);
            }
        }

        public void onSaveComplete(LocationResultSet result)
        {
            Console.WriteLine("Save Completed!");
        }

        public void onSaveError(string message)
        {
            Console.WriteLine("Save Error: "+message);
        }

        public void onSaveInit()
        {
            Console.WriteLine("Save Init");
        }

        public void onSaveInit(int maxprogress)
        {
            Console.WriteLine("Setting max progress to: "+maxprogress);
        }

        public void onTransferComplete()
        {
            Console.WriteLine("Transfer complete");
        }

        public void onTransferError(string message)
        {
            Console.WriteLine("Transfer error: "+message);
        }

        public void setSaveProgress(int progress, int speed)
        {
            Console.WriteLine(progress);
            //throw new NotImplementedException();
        }
    }
}
