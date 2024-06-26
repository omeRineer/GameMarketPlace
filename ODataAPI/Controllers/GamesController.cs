using AutoMapper;
using Entities.Main;
using Microsoft.EntityFrameworkCore;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers
{
    public class GamesController : BaseODataController<Game, Guid>
    {
        public GamesController(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
