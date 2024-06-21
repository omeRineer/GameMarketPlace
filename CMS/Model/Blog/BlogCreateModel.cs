using CMS.Model.Base;

namespace CMS.Model.Blog
{
    public class BlogCreateModel
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public InputFile Cover { get; set; }
    }
}
