using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoZhou.BudgetTracker.ApplicationCore.Entities;
using BoZhou.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using BoZhou.BudgetTracker.Infrastructure.Data;

namespace BoZhou.BudgetTracker.Infrastructure.Repositories
{
    public class IncomeRepository : EfRepository<Income>,IIncomeRepository
    {
        public IncomeRepository(BudgetTrackerDbContext dbContext) : base(dbContext) { 
        }

        public async Task<List<Income>> GetIncomeByUserId(int UserId)
        {
            var res=await _dbContext.Incomes.Where(m => m.UserId == UserId).ToListAsync();
            return res;
        }
    }
}
