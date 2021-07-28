using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoZhou.BudgetTracker.ApplicationCore.Models;

namespace BoZhou.BudgetTracker.ApplicationCore.ServiceInterfaces
{
    public interface IExpenditureService
    {
        public Task<String> UpdateExpenditure(ExpenditureRequestModel request);
        public Task<String> AddExpenditure(ExpenditureRequestModel request);
        public Task<String> DeleteExpenditure(ExpenditureRequestModel request);
        public Task<List<ExpenditureResponseModel>> GetExpenditureInfo();
    }
}
