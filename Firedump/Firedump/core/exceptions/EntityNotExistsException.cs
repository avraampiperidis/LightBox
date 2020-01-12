using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.core.exceptions
{
    public class EntityNotExistsException : AppException
    {
        public Type Entity;
        public long ID;

        public EntityNotExistsException(Type t, long id) : base()
        {
            Entity = t;
            ID = id;
        }
    }
}
