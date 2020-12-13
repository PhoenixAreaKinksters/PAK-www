using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PAK_www.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PAK_www.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class AdminController : Controller
    {
        private IConfiguration _configuration;
        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Events()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Events([FromForm] EventSearchForm form)
        {
            var model = new EventSearch(_configuration)
            {
                Search = true,
                Form = form
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult EditEvent(int id = 0)
        {
            //Update/Insert Failed
            if (id < 0)
            {
                return Content("Something went wrong");
            }

            var model = new EditEvent(_configuration)
            {
                EventId = id
            };
            return View(model);
        }
    }
}
