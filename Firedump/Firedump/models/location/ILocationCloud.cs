

namespace Firedump.models.location
{
    interface ILocationCloud : ILocation
    {
        void setExtraCredentials();

        void doExtraStuff();
    }
}
