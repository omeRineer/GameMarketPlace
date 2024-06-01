using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using Entities.Dto.Auth.Login;
using Entities.Dto.Auth.Register;
using MeArch.Module.Security.Model.UserIdentity;
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
        readonly IMapper _mapper;

        public AuthService(ITokenService tokenService, IUserService userService, IMapper mapper)
        {
            _tokenService = tokenService;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IDataResult<UserLoginResponse>> LoginAsync(UserLoginRequest request)
        {
            var userResult = await _userService.GetByLoginModelAsync(request);

            if (userResult.Data == null)
                return new ErrorDataResult<UserLoginResponse>();

            var userRoleClaimsResult = await _userService.GetUserRoleClaimsAsync(userResult.Data.Id);
            var accessTokenResult = _tokenService.GenerateToken(userResult.Data, userRoleClaimsResult.Data);

            var result = new UserLoginResponse
            {
                ExpireDate = accessTokenResult.ExpireDate,
                Token = accessTokenResult.Token,
            };

            return new SuccessDataResult<UserLoginResponse>(result);
        }

        public async Task<IResult> RegisterAsync(UserRegisterRequest request)
        {
            var isExistUserNameResult = await _userService.IsExistByUserNameAsync(request.UserName);

            if (isExistUserNameResult.Success)
                return isExistUserNameResult;

            var isExistEmailResult = await _userService.IsExistByEmailAsync(request.Email);

            if (isExistEmailResult.Success)
                return isExistEmailResult;

            User user = _mapper.Map<User>(request);
            var userCreateResult = await _userService.AddAsync(user);

            return userCreateResult;
        }


    }
}
