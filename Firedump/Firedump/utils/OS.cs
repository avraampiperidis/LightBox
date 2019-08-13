using Firedump.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.utils
{
    [Deprecated("old method. to be removed after validating")]
    public class OS
    {
        const int OS_ANYSERVER = 29;
        public static bool IsWindowsServer()
        {
            return OS.IsOS(OS.OS_ANYSERVER);
        }

        [DllImport("shlwapi.dll", SetLastError = true, EntryPoint = "#437")]
        private static extern bool IsOS(int os);
    }
}
