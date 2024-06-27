using Business.Services.Abstract;
using Entities.Dto.Auth.Login;
using Entities.Dto.Auth.Register;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UserInterface.Controllers
{
    public class AuthController : Controller
    {
        readonly IAuthService _authService;
        readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
        {
            var userResult = await _userService.GetByLoginModelAsync(userLoginRequest);

            if (!userResult.Success)
                return Unauthorized(userResult);

            var user = userResult.Data;
            List<Claim> userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim(ClaimTypes.Role, user.UserRoleClaims.First().RoleClaim.Name)
            };
            var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                          new ClaimsPrincipal(claimsIdentity));

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
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
