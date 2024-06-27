using AutoMapper;
using MeArch.Module.Security.Model.UserIdentity;
using Microsoft.EntityFrameworkCore;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers.Identity
{
    public class RoleClaimsController : BaseODataController<RoleClaim, int>
    {
        public RoleClaimsController(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
