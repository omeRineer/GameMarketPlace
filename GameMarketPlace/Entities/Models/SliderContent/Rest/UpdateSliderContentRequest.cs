using Core.Entities.DTO.File;
using System;

namespace Entities.Models.SliderContent.Rest
{
    public class UpdateSliderContentRequest
    {
        public Guid Id { get; set; }
        public int SliderTypeId { get; set; }
        public string Header { get; set; }
        public string To { get; set; }
        public bool IsActive { get; set; }
        public File Image { get; set; }
    }

}
