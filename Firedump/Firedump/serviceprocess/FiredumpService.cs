using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Topshelf;
using Firedump.models.dump;
using Firedump.models.location;
using Firedump.models.configuration.jsonconfig;

namespace Firedump.service
{
    public class FiredumpService : ServiceControl
    {       
        //DO NOT CHANGE THIS
        private static readonly int MILLISECS = 5000;

        private static Thread serviceThread;
        private static bool run = true;

        private firedumpdbDataSet.schedulesDataTable schedules;
        private firedumpdbDataSetTableAdapters.schedulesTableAdapter schedulesAdapter;
        private ScheduleManager schedulemanager;
        private List<firedumpdbDataSet.schedulesRow> scheduleRowList;
        private Queue<ScheduleManager> scheduleQueue;
        
        public FiredumpService()
        {
        }

        public bool Start(HostControl hostControl)
        {
            run = true;
            if(serviceThread == null || !serviceThread.IsAlive)
            {
                serviceThread = new Thread(new ThreadStart(Run));
                serviceThread.Start();
            }
            
            return true;
        }


        private void Run()
        {
            //on comment i have no schedule so some kind of null exception raised and the service broke
            //CANT DEBUG/WRITELINE/LOG ON CONSOLE.WRITELINE a service!
            try
            {               
                setUpScheduleList();
            }catch(Exception ex)
            {
                File.AppendAllText(@"errorlog.txt",ex.ToString());
            }

            //Sort scheduleRowList by date and take the nearest upcomming
            //malon panw anti gia Fill ena FillByDate query pou tha ta fernei etima me date order

            while (run)
            {
                ConfigurationManager.getInstance();
                Thread.Sleep(MILLISECS);
                try
                {
                    //SAFE COMMENT ALL
                    
                    int day = (int)DateTime.Now.DayOfWeek;
                    int hours = DateTime.Now.Hour;
                    int minute = DateTime.Now.Minute;
                    int second = DateTime.Now.Second;

                    if(scheduleRowList.Count > 0 && day == scheduleRowList[0].day && hours == scheduleRowList[0].hours && minute == scheduleRowList[0].minutes)
                    {
                        //File.AppendAllText(@"errorlog.txt", " SAME " + '\n');
                        //inbounds same minute
                        bool overlap = scheduleRowList[0].seconds <= second;
                        if(overlap)
                        {
                           // File.AppendAllText(@"errorlog.txt", " overlap " + '\n');
                            int dif = second - scheduleRowList[0].seconds;
                            if(dif <= 4)
                            {
                                //File.AppendAllText(@"errorlog.txt", " INTIME "+'\n');
                                
                                schedulemanager = new ScheduleManager();
                                schedulemanager.setSchedule(scheduleRowList[0]);
                                firedumpdbDataSet.schedulesRow row = scheduleRowList[0];
                                scheduleRowList.Remove(row);
                                schedulemanager.Start();
                                scheduleQueue.Enqueue(schedulemanager);
                                    
                            }
                        }
                    }

                    //File.AppendAllText(@"errorlog.txt", " NEXTS "+ day+" "+ hours+" "+ minute+'\n');
                    //Refill
                    if (scheduleRowList.Count == 0)
                        setUpScheduleList();
                        
                }
                catch (Exception ex) {
                    //write ex message to file
                    File.AppendAllText(@"errorlog.txt",ex.ToString());
                }
            }
        }


        private void setUpScheduleList()
        {
            scheduleQueue?.Clear();
            scheduleQueue = new Queue<ScheduleManager>();
            schedules = new firedumpdbDataSet.schedulesDataTable();
            schedulesAdapter = new firedumpdbDataSetTableAdapters.schedulesTableAdapter();

            //FillByDateOrder
            schedulesAdapter.FillOrderByDate(schedules);

            scheduleRowList = new List<firedumpdbDataSet.schedulesRow>();
            //copy schedules to List<>scheduleRowList
            for(int i =0; i < schedules.Count; i++)
            {
                scheduleRowList.Add(schedules[i]);
            }           
        }

        
        public bool Stop(HostControl hostControl)
        {
            run = false;
            return true;
        }

        
    }
}
