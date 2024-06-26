using AutoMapper;
using Core.Entities.Concrete.Menu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers
{
    public class MenusController : BaseODataController<Menu, Guid>
    {
        public MenusController(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
