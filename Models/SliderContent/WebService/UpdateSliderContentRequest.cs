using DTO = Core.Entities.DTO.File;
using System;

namespace Models.SliderContent.WebService
{
    public class UpdateSliderContentRequest
    {
        public Guid Id { get; set; }
        public int SliderTypeId { get; set; }
        public string Header { get; set; }
        public string To { get; set; }
        public bool IsActive { get; set; }
        public DTO.File Image { get; set; }
    }

}
