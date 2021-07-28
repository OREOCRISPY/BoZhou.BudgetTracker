using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoZhou.BudgetTracker.ApplicationCore.ServiceInterfaces
{
    public interface ICurrentUser
    {
        int UserId { get; }
        bool IsAuth { get; }
        String Email { get; }
        String Fullname { get; }
    }
}
