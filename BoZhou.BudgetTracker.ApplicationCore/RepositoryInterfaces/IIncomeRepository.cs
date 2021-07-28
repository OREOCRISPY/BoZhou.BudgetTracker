using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoZhou.BudgetTracker.ApplicationCore.Entities;

namespace BoZhou.BudgetTracker.ApplicationCore.RepositoryInterfaces
{
    public interface IIncomeRepository:IAsyncRepository<Income>
    {
        public Task<List<Income>> GetIncomeByUserId(int UserId);
    }
}
