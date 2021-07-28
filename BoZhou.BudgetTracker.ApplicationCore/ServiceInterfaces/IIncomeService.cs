using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoZhou.BudgetTracker.ApplicationCore.Models;

namespace BoZhou.BudgetTracker.ApplicationCore.ServiceInterfaces
{
    public interface IIncomeService
    {
        public Task<String> UpdateIncome(IncomeRequestModel request);
        public Task<String> AddIncome(IncomeRequestModel request);
        public Task<String> DeleteIncome(IncomeRequestModel request);
        public Task<List<IncomeResponseModel>> GetIncomeInfo();
    }
}
