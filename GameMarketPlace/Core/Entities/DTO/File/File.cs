using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.DTO.File
{
    public class File
    {
        public string FileName { get; set; }
        public string? Base64 { get; set; }
        public byte[]? Bytes { get; set; }
        public long Size { get; set; }
        public string ContentType { get; set; }
    }
}
