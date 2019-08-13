using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Firedump;
using Firedump.firedumpdbDataSetTableAdapters;
using System.Threading;
using Firedump.service;
using System.Linq;

namespace FiredumpTest
{
    /// <summary>
    /// Test first approach
    /// </summary>
    [TestClass]
    public class TestFiredumpService
    {
        private static readonly string SCHEDULE_BASE_NAME = "TEST_SCHEDULE_NO";
        private List<firedumpdbDataSet.schedulesRow> schedules;

        [ClassInitialize()]
        public static void TestServiceInitialize(TestContext context)
        {
            //fill sqlite with schedules
            fillDummySchedules();
        }

        [ClassCleanup()]
        public static void TestServiceCleanUp()
        {
            //remove  schedules from sqlite
            removeDummySchedules();
        }


        [TestMethod]
        public void TestStart()
        {

        }

        [TestMethod]
        public void TestStop()
        {

        }

        //Test first approach
        [TestMethod]
        public void TestRun()
        {
            TestSetUpScheduleList();
            for(int i =0; i < schedules.Count; i++)
            {
                Console.WriteLine("name:"+schedules[i].name+",day:" + schedules[i].day + ",hour:" + schedules[i].hours + ",minute:" + schedules[i].minutes + ",sec:" + schedules[i].seconds);
            }

            //for test
            int day = 0;
            int hours = 0;
            int minute = 10;
            int second = 10;

            int count = 0;
            while (true)
            {
                Console.WriteLine("Thread Sleeping..."+count);
                Thread.Sleep(2500);

                //int day = (int)DateTime.Now.DayOfWeek;
                //int hours = DateTime.Now.Hour;
                //int minute = DateTime.Now.Minute;
                //int second = DateTime.Now.Second;
                
                
                Console.WriteLine("BEFORECHECK:"+schedules.Count);
                
                //if is in day-hour-minute
                if ((schedules.Count > 0) && day == schedules[0].day && hours == schedules[0].hours && schedules[0].minutes == minute)
                {
                    Console.WriteLine("day:" + schedules[0].day + ",hour:" + schedules[0].hours + ",minute:" + schedules[0].minutes + ",sec:" + schedules[0].seconds);
                    //check if schedule is near now secs but not passed
                    bool overlap = schedules[0].seconds <= second;
                    Console.WriteLine("overlap:"+overlap);
                    if (overlap)
                    {   //if yes, check if the difference between now and schedule is lessOrEqual to 3
                        int dif = second - schedules[0].seconds;
                        Console.WriteLine("dif:"+dif);
                        if(dif <= 3)
                        {
                            //if yes execute schedule and remove it from list
                            ScheduleManager manager = new ScheduleManager();
                            Console.WriteLine(schedules[0].name);
                            Console.WriteLine("INTIME"+"day:"+schedules[0].day+",hour:"+ schedules[0].hours+",minute:"+ schedules[0].minutes+",sec:"+ schedules[0].seconds);
                            firedumpdbDataSet.schedulesRow row = schedules[0];
                            schedules.Remove(row);
                            //break;
                            if(count == 5)
                            {
                                day++;
                                hours++;
                                minute++;
                                second++;
                                second++;
                                second++;
                                second++;
                                second++;
                            }
                            else
                            {
                                day++;
                                hours++;
                                minute++;
                                second++;
                            }
                           
                        }
                    }
                }

                if(schedules.Count == 0)
                {
                    //refill
                }

                if (count == 5)
                {
                    break;
                }
                count++;
            }

            //no needed
            Assert.IsTrue(true);
        }


        [TestMethod]
        public void TestSetUpScheduleList()
        {

            schedules = new List<firedumpdbDataSet.schedulesRow>();
            firedumpdbDataSet.schedulesDataTable schedulestable = new firedumpdbDataSet.schedulesDataTable();
            schedulesTableAdapter adapter = new schedulesTableAdapter();
            adapter.FillOrderByDate(schedulestable);

            Assert.IsTrue(schedulestable.Count > 0);
            for(int i =0; i < schedulestable.Count; i++)
            {
                schedules.Add(schedulestable[i]);               
            }

        }

        /// <summary>
        /// test first
        /// char - is table seperator
        /// </summary>
        [TestMethod]
        public void TestExtractTablesFromString()
        {
            string tablestring = "---table1---table2-table3-table4--";
            string[] arr = tablestring.Split('-');

            List<string> tablelist = new List<string>();
            for (int i =0; i < arr.Length; i++)
            {
                if(!String.IsNullOrEmpty(arr[i]))
                {
                    tablelist.Add(arr[i]);
                }
            }
        
            foreach(string t in tablelist){
                Console.WriteLine(t);
            }

            Assert.AreEqual(4, tablelist.Count);
        }


        private static void fillDummySchedules()
        {
            sql_serversTableAdapter server = new sql_serversTableAdapter();
            for (int i = 0; i < 10; i++)
            {
                server.Insert(SCHEDULE_BASE_NAME+i,3306,"127.0.0.1","username","pass","database");
            }

            schedulesTableAdapter adapter = new schedulesTableAdapter();
            for (int i =0; i < 10; i++)
            {
                string scheduleName = SCHEDULE_BASE_NAME + i;
                
                int rowid = (int)(long)server.GetIdByName(scheduleName);
                adapter.Insert((int)rowid,scheduleName,DateTime.Now.Date,0,i,"database","table1-table2-table3",i+10,i+10,i);
                Console.WriteLine("Insert");
            }
        }

        private static void removeDummySchedules()
        {
            sql_serversTableAdapter server = new sql_serversTableAdapter();
            schedulesTableAdapter adapter = new schedulesTableAdapter();
            for (int i =0; i < 10; i++)
            {
                string scheduleName = SCHEDULE_BASE_NAME + i;
                adapter.DeleteByName(scheduleName);
                Console.WriteLine("Remove");
                server.DeleteBYName(scheduleName);
            }
        }

    }
}
