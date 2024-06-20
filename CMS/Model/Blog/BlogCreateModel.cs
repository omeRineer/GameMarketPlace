namespace CMS.Model.Blog
{
    public class BlogCreateModel
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public BlogCreateFileModel Cover { get; set; }
    }

    public class BlogCreateFileModel
    {
        public string FileName { get; set; }
        public string CoverBase64 { get; set; }
    }
}
