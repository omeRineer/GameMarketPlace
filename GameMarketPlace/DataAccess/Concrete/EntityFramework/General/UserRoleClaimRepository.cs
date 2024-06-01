using Core.DataAccess.EntityFramework;
using Core.DataAccess;
using MeArch.Module.Security.Model.UserIdentity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General
{
    public interface IUserRoleClaimRepository : IEntityRepository<UserRoleClaim>
    {

    }
    public class UserRoleClaimRepository : EfRepositoryBase<UserRoleClaim>, IUserRoleClaimRepository
    {
        public UserRoleClaimRepository(DbContext context) : base(context)
        {
        }
    }
}
