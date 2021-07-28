using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoZhou.BudgetTracker.ApplicationCore.Entities;

namespace BoZhou.BudgetTracker.ApplicationCore.RepositoryInterfaces
{
    public interface IExpenditureRepository:IAsyncRepository<Expenditure>
    {
        public Task<Expenditure> DeleteAsync(int id);

        public Task<List<Expenditure>> GetExpenditureByUserId(int UserId);
    }
}
