using Core.Entities.DTO.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Blog.Rest
{
    public class CreateBlogRequest
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public File Cover { get; set; }
    }
}
