using MeArch.Module.Security.Model;
using MeArch.Module.Security.Model.UserIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Service
{
    public interface ITokenService
    {
        AccessToken GenerateToken(User user, List<RoleClaim> roleClaims);
    }
}
