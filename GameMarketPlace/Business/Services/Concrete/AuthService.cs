using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using Entities.Dto.Auth.Login;
using MeArch.Module.Security.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class AuthService : IAuthService
    {
        readonly ITokenService _tokenService;

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public Task<IDataResult<UserLoginResponse>> Login(UserLoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
