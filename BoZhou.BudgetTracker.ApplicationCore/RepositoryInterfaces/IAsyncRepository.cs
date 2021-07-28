using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoZhou.BudgetTracker.ApplicationCore.RepositoryInterfaces
{
    public interface IAsyncRepository<T> where T:class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> DeleteAsync(T entity);
        Task<T> AddAsync(T entity);
        Task<List<T>> ListAllAsync();
        Task<T> UpDateAsync(T entity);
    }
}
