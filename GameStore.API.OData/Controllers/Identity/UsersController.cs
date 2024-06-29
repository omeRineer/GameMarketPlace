using AutoMapper;
using MeArch.Module.Security.Model.UserIdentity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStore.API.OData.Controllers.Base;

namespace GameStore.API.OData.Controllers.Identity
{
    public class UsersController : BaseODataController<User, int>
    {
        public UsersController(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
