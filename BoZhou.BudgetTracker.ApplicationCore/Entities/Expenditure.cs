using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoZhou.BudgetTracker.ApplicationCore.Entities
{
    public class Expenditure
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int Amount { get; set; }
        public String? Description { get; set; }
        public DateTime? ExpDate { get; set; }
        public String? Remarks { get; set; }

        //Navigation property
        public User User { get; set; }
    }
}
