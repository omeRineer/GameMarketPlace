using Core.Utilities.ResultTool;
using Entities.Dto.Auth.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<UserLoginResponse>> Login(UserLoginRequest request);
    }
}
