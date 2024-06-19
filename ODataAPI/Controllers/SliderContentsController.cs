using Entities.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers
{
    public class SliderContentsController : BaseODataController<SliderContent, Guid>
    {
        public SliderContentsController(DbContext context) : base(context)
        {
        }
    }
}
