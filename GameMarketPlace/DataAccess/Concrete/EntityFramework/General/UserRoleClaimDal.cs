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
    public interface IUserRoleClaimDal : IEntityRepository<UserRoleClaim>
    {

    }
    public class UserRoleClaimDalDal : EfRepositoryBase<UserRoleClaim>, IUserRoleClaimDal
    {
        public UserRoleClaimDalDal(DbContext context) : base(context)
        {
        }
    }
}
