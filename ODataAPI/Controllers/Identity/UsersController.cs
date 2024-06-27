using AutoMapper;
using MeArch.Module.Security.Model.UserIdentity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers.Identity
{
    public class UsersController : BaseODataController<User, int>
    {
        public UsersController(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
