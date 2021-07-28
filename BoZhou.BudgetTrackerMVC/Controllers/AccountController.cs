using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoZhou.BudgetTracker.Infrastructure.Services;
using BoZhou.BudgetTracker.ApplicationCore.ServiceInterfaces;
using BoZhou.BudgetTracker.ApplicationCore.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace BoZhou.BudgetTrackerMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _UserService;
        public AccountController(IUserService UserService) {
            _UserService = UserService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserRequestModel request)
        {
            if (!ModelState.IsValid) {
                return View();
            }
            var user = await _UserService.Login(request);
            if (user == null)
            {
                // wrong password
                ModelState.AddModelError(string.Empty, "Email or password wrong");
                return View();
            }
            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.Name, user.Fullname),
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return RedirectToAction("index","Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Register() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRequestModel request) {
            if (!ModelState.IsValid) {
                return View();
            }
            request.JoinOn = DateTime.Now;
            var res =await _UserService.RegisterUser(request);
            return RedirectToAction("Login");
        }
    }
}
