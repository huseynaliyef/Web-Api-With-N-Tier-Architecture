using N_Tire.BusinessLogic.Models.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tire.BusinessLogic.Abstractions
{
    public interface IAccountLogic
    {
        Task<bool> CreateRole(CreateRoleUIDTO r);
        Task<bool> Register(RegisterUIDTO r);
        Task<bool> Login(LoginUIDTO l);
        Task Logout();
        Task<bool> Update(UpdateUIDTO u);
    }
}
