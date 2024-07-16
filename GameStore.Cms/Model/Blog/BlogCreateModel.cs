using GameStore.Cms.Model.Base.Inputs;

namespace GameStore.Cms.Model.Blog
{
    public class CreateBlogModel
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public InputFile Cover { get; set; }
    }
}
