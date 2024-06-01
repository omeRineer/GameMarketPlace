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
    public interface IPermissionRepository : IEntityRepository<Permission>
    {

    }
    public class PermissionRepository : EfRepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(DbContext context) : base(context)
        {
        }
    }
}
