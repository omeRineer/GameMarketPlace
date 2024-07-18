using Business.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;
using Models.Auth.Login;
using Models.Auth.Register;

namespace GameStore.API.Web.Controllers.Auth
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
