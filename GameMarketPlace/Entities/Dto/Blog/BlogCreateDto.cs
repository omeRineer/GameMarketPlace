using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto.Blog
{
    public class BlogCreateDto
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public BlogCreateCoverDto Cover { get; set; }
    }

    public class BlogCreateCoverDto
    {
        public string Base64 { get; set; }
        public string FileName { get; set; }
    }
}
