using GameStore.Cms.Model.Base;

namespace GameStore.Cms.Model.Blog
{
    public class BlogCreateModel
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public InputFile Cover { get; set; }
    }
}
