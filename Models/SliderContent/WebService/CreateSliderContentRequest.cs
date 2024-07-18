using DTO = Core.Entities.DTO.File;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SliderContent.WebService
{
    public class CreateSliderContentRequest
    {
        public int SliderTypeId { get; set; }
        public string Header { get; set; }
        public string To { get; set; }
        public bool IsActive { get; set; }
        public DTO.File Image { get; set; }
    }

}
