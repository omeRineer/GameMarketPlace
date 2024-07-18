namespace Models.Base.Cms.Inputs
{
    public class InputFile
    {
        public string FileName { get; set; }
        public string Base64 { get; set; }
        public byte[] Bytes { get; set; }
        public long Size { get; set; }
        public string ContentType { get; set; }
    }
}
