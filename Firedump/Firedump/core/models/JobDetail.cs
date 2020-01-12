using System.Collections.Generic;

namespace Firedump.models
{
    public class JobDetail
    {

        public JobDetail() { }

        public string Name { get; set; }

        public firedumpdbDataSet.sql_serversRow Server { get; set; }

        public List<string> Tables { get; set; }

        public string Database { get; set; }

        public int DayOfWeek { get; set; }

        public int Hour { get; set; }

        public int Minute { get; set; }

        public int Second { get; set; }

        public object Tag { get; set; }

        public string LocationName { get; set; }

        public int LocationId { get; set; }

        public int Activate { get; set; }

    }
}
