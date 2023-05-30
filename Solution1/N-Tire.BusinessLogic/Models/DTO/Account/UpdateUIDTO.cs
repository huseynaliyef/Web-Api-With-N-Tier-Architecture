using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tire.BusinessLogic.Models.DTO.Account
{
    public class UpdateUIDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
