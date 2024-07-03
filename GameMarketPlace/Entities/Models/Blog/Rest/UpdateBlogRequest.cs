using Core.Entities.DTO.File;
using System;

namespace Entities.Models.Blog.Rest
{
    public class UpdateBlogRequest
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public bool? Status { get; set; }
        public File Cover { get; set; }
    }
}
