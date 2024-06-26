using AutoMapper;
using Entities.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers
{
    public class MediasController : BaseODataController<Media, Guid>
    {
        public MediasController(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
