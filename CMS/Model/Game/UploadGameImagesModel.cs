using CMS.Model.Base;

namespace CMS.Model.Game
{
    public class UploadGameImagesModel
    {
        public Guid EntityId { get; set; }
        public List<InputFile> Images { get; set; }
    }
}
