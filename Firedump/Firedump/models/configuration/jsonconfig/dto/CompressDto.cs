using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.jsonconfig.dto
{
    public class CompressDto
    {
        //<!configuration fields section>
        /// <summary>
        /// Enables compression after dump
        /// </summary>
        public bool enableCompression { set; get; }
        /// <summary>
        /// false - use .NET 4.5 native compression
        /// true - use 7zip
        /// </summary>
        public bool use7zip { set; get; } = true;

        //<7zip configuration>
        /// <summary>
        /// If true run 32 bit 7zip otherwise run 64 bit
        /// </summary>
        public bool use32bit { set; get; }
        /// <summary>
        /// 0 - -mx1 : Low compression faster proccess
        /// 1 - -mx3 : Fast compression mode
        /// 2 - -mx5 : Normal compression mode
        /// 3 - -mx7 : Maximum compression mode
        /// 4 - -mx9 : Ultra compression mode
        /// </summary>
        public int compressionLevel { set; get; } = 4;
        /// <summary>
        /// Uses multithreading to zip faster (use if you have quad core procressor) -mmt
        /// </summary>
        public bool useMultithreading { set; get; } = true;
        /// <summary>
        /// 0 - -t7z : file.7z
        /// 1 - -tgzip : file.gzip
        /// 2 - -tzip : file.zip
        /// 3 - -tbzip2 : file.bzip2
        /// 4 - -ttar : file.tar (UNIX and LINUX)
        /// 5 - -tiso : file.iso
        /// 6 - -tudf : file.udf
        /// </summary>
        public int fileType { set; get; } = 0;

        //security
        /// <summary>
        /// Enable/disable password encryption
        /// </summary>
        public bool enablePasswordEncryption { set; get; }
        /// <summary>
        /// Password to encrypt with
        /// </summary>
        public string password { set; get; }
        /// <summary>
        /// Hides file names in the password protected archive
        /// Password must be enabled and only works for .7z type
        /// </summary>
        public bool encryptHeader { set; get; }
    }
}
