using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.DTO.File
{
    public class File
    {
        public string FileName { get; set; }
        public string? Base64 { get; set; }
        public long Size { get; set; }
        public string ContentType { get; set; }
        public string Extension { get => Path.GetExtension(FileName).ToUpper(); }

        public string GenerateFileName()
        {
            FileName = $"{Guid.NewGuid()}{Extension}";
            return FileName;
        }
    }
}
