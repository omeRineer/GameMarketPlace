using Entities.Main;
using Microsoft.EntityFrameworkCore;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers
{
    public class SystemRequirementsController : BaseODataController<SystemRequirement, Guid>
    {
        public SystemRequirementsController(DbContext context) : base(context)
        {
        }
    }
}
