using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoZhou.BudgetTracker.ApplicationCore.ServiceInterfaces;
using BoZhou.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using BoZhou.BudgetTracker.ApplicationCore.Models;
using BoZhou.BudgetTracker.ApplicationCore.Entities;

namespace BoZhou.BudgetTracker.Infrastructure.Services
{
    public class IncomeService:IIncomeService
    {
        private readonly IIncomeRepository _IIncomeRepository;
        public IncomeService(IIncomeRepository IncomeRepository)
        {
            _IIncomeRepository = IncomeRepository;
        }
        public async Task<string> UpdateIncome(IncomeRequestModel request)
        {
            var target=await _IIncomeRepository.GetByIdAsync(request.Id);
            if (target == null) {
                throw new Exception("Target does not exist");
            }
            target.Amount = request.Amount==0? target.Amount: request.Amount;
            target.Description = request.Description==null? target.Description: request.Description;
            target.IncomeDate = request.IncomeDate==null? target.IncomeDate: request.IncomeDate;
            target.Remarks = request.Remarks==null? target.Remarks: request.Remarks;
            target.UserId = request.UserId==0? target.UserId: request.UserId;
            await _IIncomeRepository.UpDateAsync(target);
            return "successed";
        }

        public async Task<string> AddIncome(IncomeRequestModel request)
        {
            request.IncomeDate = DateTime.Now;
            var income = new Income() {
                Amount = request.Amount, Description = request.Description,
                IncomeDate = request.IncomeDate, Remarks = request.Remarks,
                UserId = request.UserId
            };
            await _IIncomeRepository.AddAsync(income);
            return "successed";
        }

        public async Task<string> DeleteIncome(IncomeRequestModel request)
        {
            var target=await _IIncomeRepository.GetByIdAsync(request.Id);
            if (target == null) {
                throw new Exception("Target does not exist");
            }
            await _IIncomeRepository.DeleteAsync(target);
            return "successed";
        }

        public async Task<List<IncomeResponseModel>> GetIncomeInfo()
        {
            var Incomes=await _IIncomeRepository.ListAllAsync();
            var res = new List<IncomeResponseModel>();
            foreach (var income in Incomes) {
                var temp = new IncomeResponseModel()
                {
                    Amount = income.Amount,
                    Description = income.Description,
                    Id = income.Id,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks,
                    UserId = income.UserId
                };
                res.Add(temp);
            }
            return res;
        }
    }
}
