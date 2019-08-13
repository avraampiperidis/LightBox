using Firedump.models.pojos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dump
{
    public class DumpResultSet : BaseStatus
    {
        /// <summary>
        /// wether the dump was successful or not
        /// </summary>
        /// <summary>
        /// absolute path of the temporal dump file (use if the dump was successful to get the path to the saved file)
        /// </summary>
        public string fileAbsPath { set; get; }
        /// <summary>
        /// -1 - obvious mistake in credentials (Message in errorMessage). -2 - mysqldump.exe exited with exit
        /// code diffent from 0 (use mysqldumpexeStandardError). -3 compression failed mysqldumpexeStandardError
        /// has the compression standardError output
        /// </summary>
        public int errorNumber { set; get; }
        /// <summary>
        /// The error message (use if errorNumber is -1)
        /// </summary>
        /// <summary>
        /// standard error of mysqldump.exe (use if errorNumber is -2)
        /// </summary>
        public string mysqldumpexeStandardError { set; get; }

        public DumpResultSet():base() { }


        public override string ToString()
        {
            return "wasSuccessful:" + wasSuccessful + ",fileAbsPath:" + fileAbsPath + ",errorNumber:" + errorNumber
                + ",errorMessage" + errorMessage + ",mysqldumpexeStandardError:" + mysqldumpexeStandardError;
        }
    }
}
