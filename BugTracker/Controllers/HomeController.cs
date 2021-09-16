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
using BugTracker.Persistance.Models;

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
        public IActionResult Home(UserInformationDTO model)
        {
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO model)
        {
            var userLoggedIn = await DoUserLogin(model.Username, model.Password);
            if (userLoggedIn.Success)
            {
                return View("Home", new AppResult<UserLoginDTO>
                {
                    Result = model,
                    Message = userLoggedIn.Message
                });
            }
            return View(new AppResult<UserLoginDTO>
            {
                Message = userLoggedIn.Message,
                Success = false
            });
        }
        public async Task<AppResult> DoUserLogin(string username, string password)
        {
            var userInfo = await _service.GetAuthenticatedUserInformationAsync(username, password);
            if (userInfo.Success)
            {
                HttpContext.Session.SetInt32(HttpConstants.UserId, userInfo.Result.UserId);
                HttpContext.Session.SetString(HttpConstants.Username, userInfo.Result.Username);
                HttpContext.Session.SetString(HttpConstants.Name, userInfo.Result.Name);
                HttpContext.Session.SetString(HttpConstants.ProfilePicture, userInfo.Result.ProfilePicture ?? "");
            }
            return new AppResult { Message = userInfo.Message, Success = userInfo.Success };
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppResult<UserRegisterDTO> model)
        {
            if (ModelState.IsValid)
            {
                var userCreated = await _service.RegisterUser(model.Result);
                if (userCreated != default)
                {
                    await DoUserLogin(model.Result.Username,model.Result.Password);
                    return View("Home", new UserInformationDTO
                    {
                        Name = userCreated.Name,
                        ProfilePicture = userCreated.ProfilePicture,
                        UserId = userCreated.UserId,
                        Username = userCreated.Username
                    });
                }
            }
            model.Success = false;
            model.Message = string.Join(", ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            return View(model);
        }
    }
}
