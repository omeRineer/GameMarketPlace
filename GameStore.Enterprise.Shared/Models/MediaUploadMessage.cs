using Entities.Enum.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Enterprise.Shared.Models
{
    public class MediaUploadMessage
    {
        public MediaTypeEnum MediaType { get; set; }
        public string FileName { get; set; }
        public string Base64 { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
    }
}
