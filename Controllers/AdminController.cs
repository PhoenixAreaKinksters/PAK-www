using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PAK_www.Models.Admin;
using PAK_www.Models.Shared;
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
        //[AllowAnonymous]
        public IActionResult Events()
        {
            return View();
        }

        [HttpPost]
        //[AllowAnonymous]
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
        public IActionResult EditEvent(int Id = 0)
        {
            //Update/Insert Failed
            if (Id < 0)
            {
                return Content("Something went wrong");
            }

            var model = new EditEvent(_configuration)
            {
                EventId = Id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditEvent(Event currentEvent)
        {
            var model = new EditEvent(_configuration)
            {
                CurrentEvent = currentEvent
            };
            var eventId = model.SaveEvent();
            return EditEvent(eventId);
        }

        public IActionResult DeleteEvent(int Id)
        {
            var model = new EditEvent(_configuration)
            {
                EventId = Id
            };
            model.DeleteEvent();
            return RedirectToAction("Events");
        }
    }
}
