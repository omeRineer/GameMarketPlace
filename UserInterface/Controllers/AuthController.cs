using Business.Services.Abstract;
using Entities.Dto.Auth.Login;
using Entities.Dto.Auth.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{   
    public class AuthController : Controller
    {
        readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
        {
            var result = await _authService.LoginAsync(userLoginRequest);

            if(!result.Success)
                return Unauthorized();

            Response.Cookies.Append("GameStore.Token", $"Bearer {result.Data.Token}");

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(UserRegisterRequest userRegisterRequest)
        {
            var result = await _authService.RegisterAsync(userRegisterRequest);

            if (!result.Success)
                return BadRequest();

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [Authorize]
        public IActionResult Test()
        {
            return View();
        }
    }
}
