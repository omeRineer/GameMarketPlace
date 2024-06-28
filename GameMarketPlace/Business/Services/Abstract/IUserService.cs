using Core.Business;
using Core.Utilities.ResultTool;
using Entities.Dto.Auth.Login;
using MeArch.Module.Security.Model.UserIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<RoleClaim>>> GetUserRoleClaimsAsync(int userId);
        Task<IDataResult<User>> GetByLoginModelAsync(UserLoginRequest request);
        Task<IDataResult<bool>> IsExistByLoginModelAsync(UserLoginRequest request);
        Task<IResult> IsExistByUserNameAsync(string userName);
        Task<IResult> IsExistByEmailAsync(string email);

    }
}
