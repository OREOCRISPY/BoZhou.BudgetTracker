using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoZhou.BudgetTracker.ApplicationCore.ServiceInterfaces;
using BoZhou.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using BoZhou.BudgetTracker.ApplicationCore.Models;
using BoZhou.BudgetTracker.ApplicationCore.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace BoZhou.BudgetTracker.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _IUserRepository;
        private readonly IIncomeRepository _IncomeRepository;
        private readonly IExpenditureRepository _ExpenditureRepository;
        public UserService(IUserRepository UserRepository, IIncomeRepository IncomeRepository, 
            IExpenditureRepository ExpenditureRepository) {
            _IUserRepository = UserRepository;
            _IncomeRepository = IncomeRepository;
            _ExpenditureRepository = ExpenditureRepository;
        }

        public async Task<string> DeleteUser(UserRequestModel request)
        {
            var target =await _IUserRepository.GetByIdAsync(request.Id);
            await _IUserRepository.DeleteAsync(target);
            return "successed";
        }

        public async Task<List<UserResponseModel>> GetUserInfo()
        {
            var Users=await _IUserRepository.ListAllAsync();
            var res = new List<UserResponseModel>();
            foreach (var user in Users) {
                var temp = new UserResponseModel()
                {
                    Email = user.Email,
                    Fullname = user.Fullname,
                    Id = user.Id,
                    JoinOn = user.JoinOn
                };
                res.Add(temp);
            }
            return res;
        }

        public async Task<UserResponseModel> Login(UserRequestModel request)
        {
            var User = await _IUserRepository.GetUserByEmail(request.Email);
            if (User == null)
            {
                return null;
            }
            var pw = HashPassword(request.Password, User.Salt);
            if (User.Password!=pw) {
                return null;
            }
            var response = new UserResponseModel()
            {
                Email = User.Email,
                Fullname = User.Fullname,
                Id = User.Id,
                JoinOn = User.JoinOn
            };
            return response;
        }

        public async Task<String> RegisterUser(UserRequestModel request) {
            var check = await _IUserRepository.GetUserByEmail(request.Email);
            if (check != null) {
                throw new Exception("Email already exist try another one");
            }
            var salt = CreateSalt();
            var pw = HashPassword(request.Password, salt);
            User user = new User { 
            Email=request.Email,Fullname=request.Fullname,Password=pw,JoinOn=DateTime.Now,Salt=salt};
            await _IUserRepository.AddAsync(user);
            return "successed";
        }
        private string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string HashPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                                     password: password,
                                                                     salt: Convert.FromBase64String(salt),
                                                                     prf: KeyDerivationPrf.HMACSHA512,
                                                                     iterationCount: 10000,
                                                                     numBytesRequested: 256 / 8));
            return hashed;
        }



        public async Task<string> UpdateUser(UserRequestModel request)
        {
            var target =await _IUserRepository.GetUserByEmail(request.Email);
            if (target.Email != request.Email && request.Email != null) {
                var check =await _IUserRepository.GetUserByEmail(request.Email);
                if (check != null) {
                    throw new Exception("email already exist change one");
                }
            }
            if (target == null) {
                throw new Exception("target does not exist");
            }
            target.Email = request.Email == null ? target.Email : request.Email;
            target.Fullname = request.Fullname==null? target.Fullname : request.Fullname;
            target.JoinOn = request.JoinOn==null?target.JoinOn:request.JoinOn;
            if (request.Password != null) {
                if (HashPassword(request.Password, target.Salt) != target.Password) {
                    var salt = CreateSalt();
                    var newpw = HashPassword(request.Password, salt);
                    target.Salt = salt;
                    target.Password = newpw;
                }
            }
            await _IUserRepository.UpDateAsync(target);
            return "successed";
        }

        public async Task<UserDetailModel> GetUserDetailById(int id) {
            var Expenditures = await _ExpenditureRepository.GetExpenditureByUserId(id);
            var Incomes = await _IncomeRepository.GetIncomeByUserId(id);
            var TotalIncome = 0;
            var TotalExpenditure = 0;
            foreach(var income in Incomes)
            {
                TotalIncome += income.Amount;
            }
            foreach (var Expenditure in Expenditures) {
                TotalExpenditure += Expenditure.Amount;
            }
            var res = new UserDetailModel()
            {
                UserId = id,
                expenditures = Expenditures,
                Incomes = Incomes,
                TotalExpenditure = TotalExpenditure,
                TotalIncome = TotalIncome
            };
            return res;
        }

    }
}
