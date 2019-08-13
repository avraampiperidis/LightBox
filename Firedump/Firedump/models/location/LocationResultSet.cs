

using Firedump.models.pojos;

namespace Firedump.models.location
{
    public class LocationResultSet : BaseStatus
    {
        public LocationResultSet() : base()
        {
        }
        public string path { set; get; }
    }
}
