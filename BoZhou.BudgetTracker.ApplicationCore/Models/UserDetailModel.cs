using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoZhou.BudgetTracker.ApplicationCore.Entities;

namespace BoZhou.BudgetTracker.ApplicationCore.Models
{
    public class UserDetailModel
    {
        public int UserId { get; set; }
        public List<Expenditure> expenditures { get; set; }
        public List<Income> Incomes { get; set; }
        public int TotalIncome;
        public int TotalExpenditure;

    }
}
