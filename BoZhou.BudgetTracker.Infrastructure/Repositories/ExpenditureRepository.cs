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
    public class ExpenditureRepository:EfRepository<Expenditure>,IExpenditureRepository
    {
        public ExpenditureRepository(BudgetTrackerDbContext dbContext) : base(dbContext) { 
        }
        public async Task<Expenditure> DeleteAsync(int id)
        {
            var target= await _dbContext.Expenditures.SingleOrDefaultAsync(m => m.Id == id);
            if (target == null) {
                throw new Exception("target does not exist");
            }
            _dbContext.Expenditures.Remove(target);
            await _dbContext.SaveChangesAsync();
            return target;
        }

        public async Task<List<Expenditure>> GetExpenditureByUserId(int UserId)
        {
            var res=await _dbContext.Expenditures.Where(m => m.UserId == UserId).ToListAsync();
            return res;
        }
    }
}
