using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models
{
    // enum for image index usage Standard, so set/build the imageList in your component with this order!
    public enum FinalImageIndex : int
    {
        Table = 0,
        Field = 1,
        Function = 2,
        Sql = 3,
        InnerJoin = 4,
        LeftJoin = 5,
        RightJoin = 6,
        OuterJoin = 7,
        Other = 10
    }
}
