using Entities.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers
{
    public class MediasController : BaseODataController<Media, int>
    {
        public MediasController(DbContext context) : base(context)
        {
        }
    }
}
