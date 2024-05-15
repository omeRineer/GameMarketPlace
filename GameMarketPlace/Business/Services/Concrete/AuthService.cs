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
        readonly IUserService _userService;
        readonly ITokenService _tokenService;

        public AuthService(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        public async Task<IDataResult<UserLoginResponse>> Login(UserLoginRequest request)
        {
            var user = await _userService.GetByLoginModel(request);

            return new SuccessDataResult<UserLoginResponse>();
        }
    }
}
