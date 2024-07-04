using Core.Entities.DTO.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Media.Rest
{
    public class UploadMediaCollectionRequest
    {
        public Guid EntityId { get; set; }
        public int MediaTypeId { get; set; }
        public List<File> Medias { get; set; }
    }
}
