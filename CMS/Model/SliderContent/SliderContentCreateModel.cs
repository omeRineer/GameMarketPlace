using CMS.Model.Base;
using Rdz = Radzen;

namespace CMS.Model.SliderContent
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
