using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePattern.Core
{
    public class UplodadedFile : IUploadedFile
    {
        public string FileName { get; set; }
        public long Size { get; set; }
        public string ContentType { get; set; }
        public DateTime TimeStamp { get; set; }
        public byte[] FileContent { get; set; }

        public IUploadedFile Clone()
        {
            return (IUploadedFile)this.MemberwiseClone();
        }
    }
}
