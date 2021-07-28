using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoZhou.BudgetTracker.ApplicationCore.Models;
using BoZhou.BudgetTracker.ApplicationCore.ServiceInterfaces;

namespace BoZhou.BudgetTrackerMVC.Controllers
{
    public class ExpenditureController : Controller
    {
        private readonly IExpenditureService _ExpenditureService;
        private readonly ICurrentUser _CurrentUser;
        public ExpenditureController(IExpenditureService ExpenditureService, ICurrentUser currentUser)
        {
            _ExpenditureService = ExpenditureService;
            _CurrentUser = currentUser;
        }
        [HttpGet]
        public async Task<IActionResult> ListExpenditureInfo() {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            var res=await _ExpenditureService.GetExpenditureInfo();
            return View(res);
        }
        [HttpGet]
        public IActionResult ModifyExpenditure() {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ModifyExpenditure(ExpenditureRequestModel request)
        {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            await _ExpenditureService.UpdateExpenditure(request);
            return RedirectToAction("index", "user");
        }
        [HttpGet]
        public IActionResult AddExpenditure() {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddExpenditure(ExpenditureRequestModel request) {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            await _ExpenditureService.AddExpenditure(request);
            return RedirectToAction("index", "user");
        }

        [HttpGet]
        public IActionResult DeleteExpenditure() {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteExpenditure(ExpenditureRequestModel request) {
            if (_CurrentUser.IsAuth == false)
            {
                return RedirectToAction("Login", "Account");
            }
            await _ExpenditureService.DeleteExpenditure(request);
            return RedirectToAction("index", "user");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteExpenditureInTable(int Id) {
            var request = new ExpenditureRequestModel() {
                Id = Id
            };
            await _ExpenditureService.DeleteExpenditure(request);
            return RedirectToAction("ListExpenditureInfo");
        }

    }
}
