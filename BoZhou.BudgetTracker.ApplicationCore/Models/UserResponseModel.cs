using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoZhou.BudgetTracker.ApplicationCore.Models
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String? Fullname { get; set; }
        public DateTime? JoinOn { get; set; }
    }
}
