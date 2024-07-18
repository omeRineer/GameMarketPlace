
using Models.Base.Cms.Inputs;

namespace Models.Game.Cms
{
    public class UploadGameImagesModel
    {
        public Guid EntityId { get; set; }
        public List<InputFile> Images { get; set; }
    }
}
