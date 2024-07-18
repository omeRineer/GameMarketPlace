namespace Models.Media.Cms
{
    public class UploadMediaModel
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
