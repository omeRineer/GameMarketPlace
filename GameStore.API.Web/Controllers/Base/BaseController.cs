using MA = Core.Utilities.ResultTool;
using Core.Utilities.ResultTool.APIResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Web.Controllers.Base
{
    [Route("webapi/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Result(MA.IResult result) 
            => result.Success ? Ok(result) : BadRequest(result);
    }
}
