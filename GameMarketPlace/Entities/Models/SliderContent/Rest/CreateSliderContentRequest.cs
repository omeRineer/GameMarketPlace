using Core.Entities.DTO.File;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.SliderContent.Rest
{
    public class CreateSliderContentRequest
    {
        public int SliderTypeId { get; set; }
        public string Header { get; set; }
        public string To { get; set; }
        public bool IsActive { get; set; }
        public File Image { get; set; }
    }

}
