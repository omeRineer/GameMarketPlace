using Models.Base.Cms.Inputs;

namespace Models.SliderContent.Cms
{
    public class CreateSliderContentModel
    {
        public int SliderTypeId { get; set; }
        public string? Header { get; set; }
        public string? To { get; set; }
        public bool IsActive { get; set; }
        public InputFile Image { get; set; }
    }

}
