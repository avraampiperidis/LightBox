using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.tests
{
    public class TestMysql_serverDbSet : TestContext,IFireDumpContext
    {

        
        public TestMysql_serverDbSet() 
        {
            sqlservers = new TestDbSet<sqlservers>();
        }

        public DbSet<sqlservers> sqlservers
        {
            get; set;
        }
        

        public sqlservers Find(int id)
        {
            return sqlservers.SingleOrDefault(b => b.id == id);
        }

        public int SaveChangesCount
        {
            get; set;
        }

       
        public int SaveChanges()
        {
            this.SaveChangesCount++;
            return SaveChangesCount;
        }
    }


}

