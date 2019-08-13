using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dump
{
    class CompressionAdapter
    {
        //<events>

        //onCompressProgress
        public delegate void compressProgress(int progress);
        public event compressProgress CompressProgress;
        private void onCompressProgress(int progress)
        {
            CompressProgress?.Invoke(progress);
        }

        //onCompressStart
        public delegate void compressStart();
        public event compressStart CompressStart;
        private void onCompressStart()
        {
            CompressStart?.Invoke();
        }

        //onCompressComplete
        public delegate void compressComplete(CompressionResultSet result);
        public event compressComplete CompressComplete;
        private void onCompressComplete(CompressionResultSet result)
        {
            CompressComplete?.Invoke(result);
        }

        //onCompressError
        public delegate void compressError(string message);
        public event compressError CompressError;
        private void onCompressError(string message)
        {
            CompressError?.Invoke(message);
        }

        //</events>
        public CompressionConfig config { set; get; }
        public CompressionAdapter() { }

        private Task<CompressionResultSet> innercompresstask;
        private Compression compressioninstance;
        public CompressionAdapter(CompressionConfig config)
        {
            this.config = config;
        }

        public void compress()
        {
            if(innercompresstask != null && !innercompresstask.IsCompleted)
            {
                onCompressError("Compression Error:\nAnother compression task is running");
                return;
            }
            compressioninstance = new Compression(config);
            compressioninstance.absolutePath = config.absolutePath;
            compressioninstance.CompressProgress += onCompressProgressHandler;
            compressioninstance.CompressStart += onCompressStartHandler;
            Task task = new Task(compressExecutor);
            task.Start();
        }

        public void decompress()
        {
            if (innercompresstask != null && !innercompresstask.IsCompleted)
            {
                onCompressError("Compression Error:\nAnother compression task is running");
                return;
            }
            compressioninstance = new Compression(config);
            compressioninstance.CompressProgress += onCompressProgressHandler;
            compressioninstance.CompressStart += onCompressStartHandler;
            Task task = new Task(decompressExecutor);
            task.Start();
        }

        private async void compressExecutor()
        {
            innercompresstask = new Task<CompressionResultSet>(compressioninstance.doCompress7z);
            CompressionResultSet res;
            innercompresstask.Start();
            try
            {
                res = await innercompresstask;
                onCompressProgress(100);
                onCompressComplete(res);
            }
            catch (NullReferenceException) { }
        }

        private async void decompressExecutor()
        {
            innercompresstask = new Task<CompressionResultSet>(compressioninstance.decompress7z);
            CompressionResultSet res;
            innercompresstask.Start();
            try
            {
                res = await innercompresstask;
                onCompressProgress(100);
                onCompressComplete(res);
            }
            catch (NullReferenceException) { }
        }

        private void onCompressProgressHandler (int progress)
        {
            onCompressProgress(progress);
        }

        private void onCompressStartHandler()
        {
            onCompressStart();
        }
    }
}
