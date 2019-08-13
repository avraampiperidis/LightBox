

namespace Firedump.models
{
    public class ServiceType
    {
        public enum Type : int
        {
            Local = 0,
            Ftp = 1,
            DropBox = 2,
            GoogleDrive = 3
        };
    }
}
