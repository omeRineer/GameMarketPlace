using Rdz = Radzen;

namespace CMS.Model.SliderContent
{
    public class SliderContentCreateModel
    {
        public int SliderTypeId { get; set; }
        public string? Header { get; set; }
        public string? To { get; set; }
        public bool IsActive { get; set; }
        public SliderContentImageModel ImageFile { get; set; }
    }

    public class SliderContentImageModel
    {
        public string FileName { get; set; }
        public string Base64Image { get; set; }
    }
}
