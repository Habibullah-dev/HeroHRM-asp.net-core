using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class GroupedUserViewModel
    {
        public List<UserViewModel> Employees { get; set; }
        public List<UserViewModel> Admins { get; set; }
    }
}
