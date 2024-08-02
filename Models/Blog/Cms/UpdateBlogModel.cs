
using Models.Base.Cms.Inputs;

namespace Models.Blog.Cms
{
    public class UpdateBlogModel
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public InputFile Cover { get; set; }
    }
}
