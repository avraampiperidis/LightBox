using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.utils.editor
{
    //fetch user prefs.like upper or lower, font's settings, auto commits
    // auto format and prettyfy and many others.
    public class EditorConfig
    {

        //if auto format is enabled for every new query tab, on every string send to editor by other component,
        // not on user keybord entry because that would be very annoying.
        internal static bool isAutoFormatConfigOn()
        {
            // fetch from user config
            return true;
        }

        // Change the case for every format,prettyfy?
        // user should choose between auto upper,auto lower
        // or default is nothing text stays the same.
        // Should refactor return type of method to Enum like eg( UPPER,LOWER,DEFAULT ...).
        // bool is not enough.
        internal static bool changeTextCase()
        {
            return true;
        }
    }
}
