using AutoMapper;
using MeArch.Module.Security.Model.UserIdentity;
using Microsoft.EntityFrameworkCore;
using GameStore.API.OData.Controllers.Base;

namespace GameStore.API.OData.Controllers.Identity
{
    public class RoleClaimsController : BaseODataController<RoleClaim, int>
    {
        public RoleClaimsController(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
