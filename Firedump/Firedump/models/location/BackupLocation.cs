using System;

namespace Firedump.models.location
{
    public class BackupLocation
    {
        public int id { set; get; }
        public string path { set; get; }

        public object Tag { get; set; }

        public BackupLocation() { }
        public sealed override bool Equals(object obj) 
        {
            if (obj == null || !(obj is BackupLocation)) { return false; };
            return this.id == ((BackupLocation)obj).id;
        }
    }
}
