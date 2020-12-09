using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAK_www.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PAK_www.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User?.Identity.IsAuthenticated ?? false)
            {
                return Panel();
            }
            return Login();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginForm login)
        {
            var user = login.ValidateCredentials();
            if ((user?.UserId ?? 0) > 0)
            {
                var claims = new List<Claim>
                    {
                      new Claim(ClaimTypes.Name, user.Username)
                    };

                var claimsIdentity = new ClaimsIdentity(
                  claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties();
                authProperties.IsPersistent = true;

                await HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme,
                  new ClaimsPrincipal(claimsIdentity),
                  authProperties);

                return Panel();
            }
            return Login();
        }

        public IActionResult Panel()
        {
            return View();
        }
    }
}
