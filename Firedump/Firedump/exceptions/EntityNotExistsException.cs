using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.exceptions
{
    public class EntityNotExistsException : AppException
    {
        public Type Entity;
        public long ID;

        public EntityNotExistsException(Type t,long id) : base()
        {
            this.Entity = t;
            this.ID = id;
        }
    }
}
