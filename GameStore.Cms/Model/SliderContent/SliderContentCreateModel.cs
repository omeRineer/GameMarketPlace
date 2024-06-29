using GameStore.Cms.Model.Base;
using Rdz = Radzen;

namespace GameStore.Cms.Model.SliderContent
{
    public class SliderContentCreateModel
    {
        public int SliderTypeId { get; set; }
        public string? Header { get; set; }
        public string? To { get; set; }
        public bool IsActive { get; set; }
        public InputFile Image { get; set; }
    }

}
