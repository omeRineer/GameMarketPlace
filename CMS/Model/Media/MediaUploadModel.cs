namespace CMS.Model.Media
{
    public class MediaUploadModel
    {
        public Guid EntityId { get; set; }
        public List<MediaUploadFile> MediaList { get; set; }
    }

    public class MediaUploadFile
    {
        public byte[] Bytes { get; set; }
        public string FileName { get; set; }
    }
}
