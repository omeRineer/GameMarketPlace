using GameStore.Cms.Model.Base;

namespace GameStore.Cms.Model.Game
{
    public class UploadGameImagesModel
    {
        public Guid EntityId { get; set; }
        public List<InputFile> Images { get; set; }
    }
}
