using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoZhou.BudgetTracker.ApplicationCore.Models;

namespace BoZhou.BudgetTracker.ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        public Task<String> RegisterUser(UserRequestModel request);
        public Task<String> UpdateUser(UserRequestModel request);
        public Task<String> DeleteUser(UserRequestModel request);
        public Task<List<UserResponseModel>> GetUserInfo();
        public Task<UserResponseModel> Login(UserRequestModel request);
        public Task<UserDetailModel> GetUserDetailById(int id);
    }
}
