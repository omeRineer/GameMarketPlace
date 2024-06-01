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
    public interface IUserPermissionRepository : IEntityRepository<UserPermission>
    {

    }
    public class UserPermissionRepository : EfRepositoryBase<UserPermission>, IUserPermissionRepository
    {
        public UserPermissionRepository(DbContext context) : base(context)
        {
        }
    }
}
