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
    public interface IRoleClaimRepository : IEntityRepository<RoleClaim>
    {

    }
    public class RoleClaimRepository : EfRepositoryBase<RoleClaim>, IRoleClaimRepository
    {
        public RoleClaimRepository(DbContext context) : base(context)
        {
        }
    }
}
