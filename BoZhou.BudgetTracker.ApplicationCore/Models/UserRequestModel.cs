using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BoZhou.BudgetTracker.ApplicationCore.Models
{
    public class UserRequestModel
    {
        public int Id { get; set; }
        [EmailAddress]
        public String Email { get; set; }
        [StringLength (10,ErrorMessage ="PassWord length should be minimum 5 characters",MinimumLength =5)]
        public String Password { get; set; }
        public String? Fullname { get; set; }
        public DateTime? JoinOn { get; set; }
    }
}
