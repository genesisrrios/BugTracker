using BugTracker.Persistance.DTO;
using BugTracker.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Persistance;
namespace BugTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _service;
        public HomeController(ILogger<HomeController> logger,UserService userService)
        {
            _logger =logger;
            _service = userService;
        }

        public IActionResult Register()
        {
            return View(new AppResult<UserRegisterDTO>());
        }
        public IActionResult Login()
        {
            return View(new AppResult<UserLoginDTO>());
        }
        public IActionResult Home(AppResult<UserLoginDTO> model)
        {
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO model)
        {
            var userInfo = await _service.GetAuthenticatedUserInformationAsync(model.Username, model.Password);
            if (userInfo.Success)
            {
                HttpContext.Session.SetInt32(HttpConstants.UserId, userInfo.Result.UserId);
                HttpContext.Session.SetString(HttpConstants.Username, userInfo.Result.UserName);
                HttpContext.Session.SetString(HttpConstants.Name, userInfo.Result.Name);
                HttpContext.Session.SetString(HttpConstants.ProfilePicture, userInfo.Result.ProfilePicture ?? "");
                return View("Home", new AppResult<UserLoginDTO>
                {
                    Message = userInfo.Message,
                    Success = userInfo.Success,
                    Result = model
                });
            }
            return View(new AppResult<UserLoginDTO>
            {
                Message = userInfo.Message,
                Success = false
            });
        }
    }
}
