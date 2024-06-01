using Business.Services.Abstract;
using Entities.Dto.Auth.Login;
using Entities.Dto.Auth.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers.Auth
{
    public class AuthController : BaseController
    {
        readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var result = await _authService.LoginAsync(request);

            return Result(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);

            return Result(result);
        }
    }
}
