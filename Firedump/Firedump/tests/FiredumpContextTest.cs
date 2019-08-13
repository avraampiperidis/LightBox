using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.tests
{
    public class FiredumpContextTest
    {
        private IFireDumpContext contextdb;

        public FiredumpContextTest(IFireDumpContext contextdb)
        {
            this.contextdb = contextdb;
        }


        public List<sqlservers> getAllMySqlServers()
        {        
            return contextdb.sqlservers.ToList();           
        }

        //return the new id
        public int saveMysqlServer(sqlservers server)
        {          
            contextdb.sqlservers.Add(server);
            contextdb.SaveChanges();
            return (int)server.id;          
        }

        public sqlservers getMysqlServerById(int id)
        {      
            sqlservers server = contextdb.sqlservers.Find(id);
            return server;
        }


        public void deleteMysqlServer(sqlservers server)
        {
            contextdb.sqlservers.Remove(server);
            contextdb.SaveChanges();
        }


        public List<schedules> getSchedules()
        {
            return contextdb.schedules.ToList();
        }

        public int saveSchedule(schedules schedule)
        {
            contextdb.schedules.Add(schedule);
            contextdb.SaveChanges();
            return (int)schedule.id;
        }
    }
}
