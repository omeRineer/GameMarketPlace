using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Model.UserIdentity
{
    public class Permission : BaseEntity<int>, IEntity
    {
        public string Name { get; set; }

        public IEnumerable<UserPermission> UserPermissions { get; set; }
    }
}
