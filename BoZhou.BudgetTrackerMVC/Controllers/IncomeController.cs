using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoZhou.BudgetTracker.ApplicationCore.ServiceInterfaces;
using BoZhou.BudgetTracker.ApplicationCore.Models;

namespace BoZhou.BudgetTrackerMVC.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeService _IncomeService;
        private readonly ICurrentUser _CurrentUser;
        public IncomeController(IIncomeService IncomeService, ICurrentUser currentUser)
        {
            _IncomeService = IncomeService;
            _CurrentUser = currentUser;
        }
        [HttpGet]
        public async Task<IActionResult> ListIncomeInfo() {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            var res =await _IncomeService.GetIncomeInfo();
            return View(res);
        }
        [HttpGet]
        public  IActionResult AddIncome() {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddIncome(IncomeRequestModel request) {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            await _IncomeService.AddIncome(request);
            return RedirectToAction("index","user");
        }
        [HttpGet]
        public IActionResult ModifyIncome()
        {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ModifyIncome(IncomeRequestModel request)
        {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            await _IncomeService.UpdateIncome(request);
            return RedirectToAction("index", "user");
        }
        [HttpGet]
        public IActionResult DeleteIncome()
        {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteIncome(IncomeRequestModel request)
        {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            await _IncomeService.DeleteIncome(request);
            return RedirectToAction("index", "user");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteIncomeInTable(int id) {
            var request = new IncomeRequestModel()
            {
                Id = id
            };
            await _IncomeService.DeleteIncome(request);
            return RedirectToAction("ListIncomeInfo");
        }

    }
}
