using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoZhou.BudgetTracker.ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Salt { get; set; }
        public String? Fullname { get; set; }
        public DateTime? JoinOn { get; set; }

        //Navigation property
        public ICollection<Expenditure> Expenditures { get; set; }
        public ICollection<Income> Incomes { get; set; }
    }
}
