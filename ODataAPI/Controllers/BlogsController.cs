using Entities.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers
{
    public class BlogsController : BaseODataController<Blog, Guid>
    {
        public BlogsController(DbContext context) : base(context)
        {
        }
    }
}
