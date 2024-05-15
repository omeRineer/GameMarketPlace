using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Model.UserIdentity
{
    public class User : BaseEntity<int>, IEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public IEnumerable<UserRoleClaim> UserRoleClaims { get; set; }
        public IEnumerable<UserPermission> UserPermissions { get; set; }
    }
}
