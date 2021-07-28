using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoZhou.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using BoZhou.BudgetTracker.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using BoZhou.BudgetTracker.Infrastructure.Data;
using BoZhou.BudgetTracker.ApplicationCore.Models;

namespace BoZhou.BudgetTracker.Infrastructure.Repositories
{
    public class UserRepository:EfRepository<User>,IUserRepository
    {
        public UserRepository(BudgetTrackerDbContext dbContext) : base(dbContext) { 
        }

        public async Task<User> GetUserByEmail(String Email) {
            var user = await _dbContext.Users.Where(u => u.Email == Email).FirstOrDefaultAsync();
            return user;
        }
        /*
        public async Task<User> UpDateAsync(User entity) {
            var entry=await _dbContext.Users.FirstOrDefaultAsync(m => m.Id == entity.Id);
            entry.Email = entity.Email;
            entry.Fullname = entity.Fullname;
            entry.Password = entity.Password;
            _dbContext.Users.Update(entry);
            await _dbContext.SaveChangesAsync();
            return null;
        }
        */

    }
}
