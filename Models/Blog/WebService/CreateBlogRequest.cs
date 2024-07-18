using DTO = Core.Entities.DTO.File;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Blog.WebService
{
    public class CreateBlogRequest
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public DTO.File Cover { get; set; }
    }
}
