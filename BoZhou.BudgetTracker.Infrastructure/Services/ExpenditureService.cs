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
    public class ExpenditureService:IExpenditureService
    {
        private readonly IExpenditureRepository _IExpenditureRepository;
        public ExpenditureService(IExpenditureRepository ExpenditureRepository) {
            _IExpenditureRepository = ExpenditureRepository;
        }
        public async Task<String> UpdateExpenditure(ExpenditureRequestModel request) {
            var targer=await _IExpenditureRepository.GetByIdAsync(request.Id);
            if (targer == null) {
                throw new Exception("target does not exist");
            }
            targer.Amount = request.Amount==0? targer.Amount: request.Amount;
            targer.Description = request.Description==null? targer.Description: request.Description;
            targer.ExpDate = request.ExpDate==null? targer.ExpDate: request.ExpDate;
            targer.Remarks = request.Remarks==null? targer.Remarks:request.Remarks;
            targer.UserId = request.UserId==null?targer.UserId: request.UserId;
            await _IExpenditureRepository.UpDateAsync(targer);
            return "sucess";
        }
        public async Task<String> AddExpenditure(ExpenditureRequestModel request) {
            request.ExpDate = DateTime.Now;
            var expenditure = new Expenditure() {
                Amount = request.Amount, Description = request.Description,
                ExpDate = DateTime.Now, Remarks = request.Remarks,
                UserId = request.UserId
            };
            await _IExpenditureRepository.AddAsync(expenditure);
            return "successed";
        }

        public async Task<String> DeleteExpenditure(ExpenditureRequestModel request)
        {
            await _IExpenditureRepository.DeleteAsync(request.Id);
            return "successed";
        }

        public async Task<List<ExpenditureResponseModel>> GetExpenditureInfo() {
            var Expenditures= await _IExpenditureRepository.ListAllAsync();
            var res = new List<ExpenditureResponseModel>();
            foreach (var expenditure in Expenditures) {
                var temp = new ExpenditureResponseModel()
                {
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Id = expenditure.Id,
                    Remarks = expenditure.Remarks,
                    UserId = expenditure.UserId
                };
                res.Add(temp);
            }
            return res;
        }
    }
}
