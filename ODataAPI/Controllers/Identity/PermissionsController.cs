using AutoMapper;
using MeArch.Module.Security.Model.UserIdentity;
using Microsoft.EntityFrameworkCore;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers.Identity
{
    public class PermissionsController : BaseODataController<Permission, int>
    {
        public PermissionsController(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
