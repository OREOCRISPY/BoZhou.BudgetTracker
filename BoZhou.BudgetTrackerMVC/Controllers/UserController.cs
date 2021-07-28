using BoZhou.BudgetTracker.ApplicationCore.ServiceInterfaces;
using BoZhou.BudgetTracker.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoZhou.BudgetTrackerMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _UserService;
        private readonly ICurrentUser _CurrentUser;
        public UserController(IUserService UserService,ICurrentUser currentUser)
        {
            _UserService = UserService;
            _CurrentUser = currentUser;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (_CurrentUser.IsAuth == false) {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ViewUserInfo(){
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            var res=await _UserService.GetUserInfo();
            return View(res);
        }
        [HttpGet]
        public  IActionResult ModifyUserInfo() {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ModifyUserInfo(UserRequestModel request)
        {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            if (!ModelState.IsValid) {
                return View();
            }
            await _UserService.UpdateUser(request);
            return Redirect("Index");
        }
        [HttpGet]
        public IActionResult DeleteUser() {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(UserRequestModel request)
        {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            await _UserService.DeleteUser(request);
            return Redirect("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUserInTable(int Id) 
        {
            var request = new UserRequestModel()
            {
                Id = Id
            };
            await _UserService.DeleteUser(request);
            return Redirect("ViewUserInfo");
        }
        [HttpGet]
        public IActionResult AddUser() {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            return RedirectToAction("Register", "Account");
        }
        [HttpGet]
        public async Task<IActionResult> UserDetails(int id) {
           var res= await _UserService.GetUserDetailById(id);
           return View(res);
        }
        
    }
}
