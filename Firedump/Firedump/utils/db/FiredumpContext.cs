using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//While it can be fine to re-use a DbContext across multiple business transactions, its lifetime should still be kept short. 
namespace Firedump.models.databaseutils
{
    public class FiredumpContext
    {

        public FiredumpContext()
        {
        }

        ~FiredumpContext()
        {
            //??
        }

        public List<sqlservers> getAllMySqlServers()
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.sqlservers.ToList();
            }
        }

        public List<schedules> getSchedules()
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.schedules.ToList();
            }
        }

        public List<schedule_save_locations> getScheduleSaveLocations()
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.schedule_save_locations.ToList();
            }
        }

        public List<logs> getLogs()
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.logs.ToList();
            }
        }

        public List<userinfo> getUserinfo()
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.userinfo.ToList();
            }
        }

        public List<backup_locations> getBackupLocations()
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.backup_locations.ToList();
            }
        }
        
        //return the new id
        public int saveMysqlServer(sqlservers server)
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                contextdb.sqlservers.Add(server);
                contextdb.SaveChanges();
                return (int)server.id;
            }
        }


        public List<schedules> getSchedulesByServerId(int id)
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.schedules.Where(schedule => schedule.server_id == id).ToList();
            }
        }

        public List<schedule_save_locations> getScheduleSaveLocationByScheduleId(int id)
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.schedule_save_locations.Where(
                    scheduleS => scheduleS.schedule_id == id
                    ).ToList();
            }
        }

        public List<logs> getLogsByScheduleId(int id)
        {
            using (firedumpdbEntities1 context = new firedumpdbEntities1())
            {
                return context.logs.Where(
                    log => log.schedule_id == id
                    ).ToList();
            }
        }

        public List<userinfo> getUserinfoByScheduleId(int id)
        {
            using (firedumpdbEntities1 context = new firedumpdbEntities1())
            {
                return context.userinfo.Where(
                    usr => usr.schedule_id == id
                    ).ToList();
            }
        }

        public List<schedule_save_locations> getSheduleSaveLocationByBackupLocId(int id)
        {
            using (firedumpdbEntities1 context = new firedumpdbEntities1())
            {
                return context.schedule_save_locations.Where(
                    schedule_save => schedule_save.backup_location_id == id
                    ).ToList();
            }
        }


        public sqlservers getMysqlServerById(long id)
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                sqlservers server = contextdb.sqlservers.Find(id);
                return server;
            }
        }

        //-------------------UPDATE METHODS---------------------------------

        public void updateMysqlServer(sqlservers mysqlserver)
        {
            using (firedumpdbEntities1 context = new firedumpdbEntities1())
            {
                sqlservers original = context.sqlservers.Find(mysqlserver.id);
                context.Entry(original).CurrentValues.SetValues(mysqlserver);
                context.SaveChanges();
            }
        }

        public void updateSchedule(schedules schedule)
        {
            using (firedumpdbEntities1 context = new firedumpdbEntities1())
            {
                schedules original = context.schedules.Find(schedule.id);
                context.Entry(original).CurrentValues.SetValues(schedule);
                context.SaveChanges();
            }
        }

        //-------------------DELETE METHODS---------------------------------
        public void deleteMysqlServer(sqlservers server)
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                contextdb.sqlservers.Remove(server);
                contextdb.SaveChanges();
            }
        }

        public void deleteSchedule(schedules schedule)
        {
            using (firedumpdbEntities1 context = new firedumpdbEntities1())
            {
                context.schedules.Remove(schedule);
                context.SaveChanges();
            }
        }

        public void deleteScedulesaveLocation(schedule_save_locations scl)
        {
            using (firedumpdbEntities1 context = new firedumpdbEntities1())
            {
                context.schedule_save_locations.Remove(scl);
                context.SaveChanges();
            }
        }

        public void deleteBackupLocation(backup_locations bloc)
        {
            using (firedumpdbEntities1 context = new firedumpdbEntities1())
            {
                context.backup_locations.Remove(bloc);
                context.SaveChanges();
            }
        }

        public void deleteLogs(logs log)
        {
            using (firedumpdbEntities1 context = new firedumpdbEntities1())
            {
                context.logs.Remove(log);
                context.SaveChanges();
            }
        }

        public void deleteUserinfo(userinfo usrinfo)
        {
            using (firedumpdbEntities1 context = new firedumpdbEntities1())
            {
                context.userinfo.Remove(usrinfo);
                context.SaveChanges();
            }
        }

    }
}
