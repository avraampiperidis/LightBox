using Firedump.models.configuration.dynamicconfig;
using Firedump.utils;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Firedump.models.sqlimport
{
    class ImportAdapter
    {
        //onImportProgress
        public delegate void importProgress(int progress);
        public event importProgress ImportProgress;
        private void onImportProgress(int progress)
        {
            ImportProgress?.Invoke(progress);
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
        private SQLImport sqlimportInstance;
        private Task<ImportResultSet> innertask;
        private ImportAdapter() { }
        public ImportAdapter(ImportCredentialsConfig config)
        {
            sqlimportInstance = new SQLImport(config);
            sqlimportInstance.Progress += onProgressHandler;
        }

        public void executeScript()
        {
            if(innertask != null && !innertask.IsCompleted)
            {
                onImportError("Another import is running.");
                return;
            }

            Task task = new Task(scriptExecutor);
            task.Start();         
        }

        private async void scriptExecutor()
        {
            try
            {
                sqlimportInstance.script = File.ReadAllText(sqlimportInstance.config.scriptPath);
                int commandsCount = StringUtils.countOccurances(sqlimportInstance.script, sqlimportInstance.config.scriptDelimeter);
                if (commandsCount == 0) commandsCount = 1;
                onImportInit(commandsCount);

                innertask = new Task<ImportResultSet>(sqlimportInstance.executeScript);
                ImportResultSet result;
                innertask.Start();
                result = await innertask;

                onImportProgress(commandsCount);
                onImportComplete(result);
            }
            catch (Exception ex)
            {
                onImportError("Script import failed:\n" + ex.Message);
            }
        }

        private void onProgressHandler(int progress)
        {
            onImportProgress(progress);
        }
    }
}
