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
    public interface IUserService : IEntityService<User, int>
    {
        Task<IDataResult<User>> GetByLoginModel(UserLoginRequest request);
        Task<IDataResult<bool>> IsExistByLoginModel(UserLoginRequest request);
    }
}
