using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class SliderContentCreateDto
    {
        public int SliderTypeId { get; set; }
        public string? Header { get; set; }
        public string? To { get; set; }
        public bool IsActive { get; set; }
        public SliderContentImage ImageFile { get; set; }
    }

    public class SliderContentImage
    {
        public string FileName { get; set; }
        public string Base64Image { get; set; }
    }
}
