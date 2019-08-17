using Firedump.models.configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firedump.models.configuration.jsonconfig;
using System.ServiceProcess;
using System.IO;
using System.Diagnostics;
using Topshelf;
using Firedump.service;
using System.Threading;
using Topshelf.ServiceConfigurators;
using Firedump.utils.parsers;

namespace Firedump
{
    static class Program
    {
        //private static Thread thread;

        //not used yet
        private static readonly string guid = "{FFEF1C2E-E951-4270-AFBB-807CA84BB79B}";
        private static Mutex mutex = new Mutex(true, @"Global\"+guid);

        /// <summary>
        /// The main entry point for the application.
        /// args can be install start stop uninstall
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                //configuration initialization
                ConfigurationManager.getInstance();
                Application.Run(new MainHome());
            } else
            {
                new Thread(new ThreadStart(service)).Start();
            }
        }

        //service installer/stop/start/uninstaller
        private static void service()
        {
            HostFactory.New(x => {
                x.Service<FiredumpService>((ServiceConfigurator<FiredumpService> s) =>
                {
                    s.ConstructUsing(settings =>
                    {
                        var serviceName = settings.ServiceName;
                        return new FiredumpService();
                    });
                    s.WhenStarted((ms, hostControl) => ms.Start(hostControl));
                    s.WhenStopped((ms, hostControl) => ms.Stop(hostControl));
                    
                });
                x.EnablePauseAndContinue();
                x.EnableShutdown();
                x.StartManually();
                x.RunAsLocalSystem();
                // If Consts.SERVICE_NAME is about to change , remeber to uninstall the old service
                x.SetServiceName(Consts.SERVICE_NAME);
                x.UseNLog();
                // topshelf supper BUG in setting displayName
                // tha kanei set to service name kai tha ftiaksei dio diaforetika services sta windows service registry!
                // x.SetDisplayName(Consts.SERVICE_DESC);
            }).Run();  
        }
    }
}
