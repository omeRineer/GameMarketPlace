using Entities.Enum.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Enterprise
{
    public class UploadMediaMessage
    {
        public Guid EntityId { get; set; }
        public MediaTypeEnum MediaType { get; set; }
        public string FileName { get; set; }
        public string Base64 { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
    }
}
