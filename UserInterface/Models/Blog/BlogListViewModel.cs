namespace UserInterface.Models.Blog
{
    public class BlogListViewModel
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public int ReaderCount { get; set; }
        public string? CoverPath { get; set; }
    }
}
