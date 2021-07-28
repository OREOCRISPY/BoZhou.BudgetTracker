using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoZhou.BudgetTracker.ApplicationCore.Entities;

namespace BoZhou.BudgetTracker.ApplicationCore.RepositoryInterfaces
{
    public interface IUserRepository:IAsyncRepository<User>
    {
        public Task<User> GetUserByEmail(String Email);
    }

}
