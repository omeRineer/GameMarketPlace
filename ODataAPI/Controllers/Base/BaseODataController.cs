using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ODataAPI.Controllers.Base
{
    [Route("odata/[controller]")]
    public class BaseODataController : ODataController
    {
        protected readonly CoreContext Context;

        protected BaseODataController(CoreContext context)
        {
            Context = context;
        }
    }
}
