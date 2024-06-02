using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Model.UserIdentity
{
    public class RolePermission : BaseEntity<int>, IEntity
    {
        public int RoleClaimId { get; set; }
        public int PermissionId { get; set; }

        public RoleClaim RoleClaim { get; set; }
        public Permission Permission { get; set; }
    }
}
