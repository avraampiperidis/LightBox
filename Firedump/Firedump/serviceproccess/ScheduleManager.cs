using Firedump.models.configuration.dynamicconfig;
using Firedump.models.dump;
using Firedump.models.location;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firedump.models.configuration.jsonconfig;

namespace Firedump.service
{
    public class ScheduleManager
    {

        private SqlDumpAdapter mysqldumpAdapter;
        private LocationAdapterManager locationAdapterManager;
        private firedumpdbDataSet.schedulesRow schedulesRow;
        private firedumpdbDataSet.sql_serversRow server;

        public ScheduleManager()
        {
        }

        internal void StopCurrentJob()
        {
            //cancel mysql dump process
            //cancel location/upload process
        }

        internal void setSchedule(firedumpdbDataSet.schedulesRow schedulesRow)
        {
            this.schedulesRow = schedulesRow;
        }

       
        internal void Start()
        {
            List<string> tables = utils.StringUtils.extractTableListFromString(schedulesRow.tables);
            string database = schedulesRow.database;
            firedumpdbDataSetTableAdapters.sql_serversTableAdapter serveradapter = new firedumpdbDataSetTableAdapters.sql_serversTableAdapter();
            firedumpdbDataSet.sql_serversDataTable servertable = new firedumpdbDataSet.sql_serversDataTable();
            serveradapter.FillById(servertable, schedulesRow.server_id);

            if (servertable?.Count > 0)
            {
                //File.AppendAllText(@"servicelog.txt", "COUNT:"+servertable.Count+",");
                server = servertable[0];
            }                
            else
            {
                //File.AppendAllText(@"servicelog.txt", "COUNT:" + "EMPTY" + ",");
                return;
            }
            DumpCredentialsConfig dumpConfig = new DumpCredentialsConfig(server.host, (int)server.port, server.username, server.password,database);
            if (tables.Count > 0)
                dumpConfig.excludeTables = tables.ToArray();

            mysqldumpAdapter = new SqlDumpAdapter();
            mysqldumpAdapter.Cancelled += OnCancelled;
            mysqldumpAdapter.Completed += OnCompleted;
            mysqldumpAdapter.CompressProgress += oncompressprogress;
            mysqldumpAdapter.CompressStart += oncompstart;
            mysqldumpAdapter.Error += onerror;
            mysqldumpAdapter.InitDumpTables += oninitdumptables;
            mysqldumpAdapter.Progress += onprogress;
            mysqldumpAdapter.TableRowCount += ontablerowcount;
            mysqldumpAdapter.TableStartDump += ontablestartdump;
            
            //File.AppendAllText(@"servicelog.txt", "STARTDUMP");
            mysqldumpAdapter.startDump(dumpConfig);
            
        }

        private void ontablestartdump(string table)
        {
        }

        private void ontablerowcount(int rowcount)
        {
        }

        private void onprogress(string progress)
        {
        }

        private void oninitdumptables(List<string> tables)
        {
        }

        private void onerror(int error)
        {
        }

        private void oncompstart()
        {
        }

        private void oncompressprogress(int progress)
        {
        }

        private void OnCompleted(DumpResultSet resultSet)
        {
            if (resultSet != null)
            {
                if(resultSet.wasSuccessful)
                {
                    List<int> locations = new List<int>();
                    //get schedule_save_location data table by schedule ID
                    firedumpdbDataSetTableAdapters.schedule_save_locationsTableAdapter savelocAdapter = new firedumpdbDataSetTableAdapters.schedule_save_locationsTableAdapter();
                    firedumpdbDataSet.schedule_save_locationsDataTable saveloctable = new firedumpdbDataSet.schedule_save_locationsDataTable();
                    savelocAdapter.FillByScheduleId(saveloctable,schedulesRow.id);

                    if(saveloctable.Count > 0)
                    {
                        //File.AppendAllText(@"servicelog.txt", "saveloctable.Count > 0");
                        //now get backuplocations by backuplocationID
                        try {
                            firedumpdbDataSetTableAdapters.backup_locationsTableAdapter backupAdapter = new firedumpdbDataSetTableAdapters.backup_locationsTableAdapter();
                            firedumpdbDataSet.backup_locationsDataTable backuptable = new firedumpdbDataSet.backup_locationsDataTable();
                            for (int i = 0; i < saveloctable.Count; i++)
                            {
                                firedumpdbDataSet.backup_locationsDataTable temp = backupAdapter.GetDataByID(saveloctable[i].backup_location_id);
                                locations.Add((int)temp[0].id);
                                //File.AppendAllText(@"servicelog.txt", "Addbackup_locationsRow " + temp[0].id + temp[0].name);
                            }
                            
                            locationAdapterManager = new LocationAdapterManager(locations, resultSet.fileAbsPath);
                            locationAdapterManager.SaveInit += onSaveInitHandler;
                            locationAdapterManager.InnerSaveInit += onInnerSaveInitHandler;
                            locationAdapterManager.LocationProgress += onLocationProgressHandler;
                            locationAdapterManager.SaveProgress += setSaveProgressHandler;
                            locationAdapterManager.SaveComplete += onSaveCompleteHandler;
                            locationAdapterManager.SaveError += onSaveErrorHandler;
                            locationAdapterManager.setProgress();

                            //File.AppendAllText(@"servicelog.txt", "locationAdapterManager.startSave");
                            locationAdapterManager.startSave();
                        }catch(Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            //File.AppendAllText(@"servicelog.txt", "Exception "+ex.ToString());
                        }
                    }
                    
                }
            }

        }



        private void onSaveErrorHandler(string message)
        {
            
        }

        private void onSaveCompleteHandler(List<LocationResultSet> results)
        {
            File.AppendAllText(@"servicelog.txt", "onSaveCompleteHandler");
        }

        private void setSaveProgressHandler(int progress, int speed)
        {
           
        }

        private void onLocationProgressHandler(int progress, int speed)
        {
            
        }

        private void onInnerSaveInitHandler(string location_name, int location_type)
        {
           
        }

        private void onSaveInitHandler(int maxprogress)
        {
            File.AppendAllText(@"servicelog.txt", "onSaveInitHandler");
        }

        private void OnCancelled()
        {

        }

        
    }
}
