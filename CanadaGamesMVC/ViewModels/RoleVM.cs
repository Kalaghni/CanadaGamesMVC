using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGamesMVC.ViewModels
{
    public class RoleVM
    {
        public string RoleId { get; set; }

        public string RoleName { get; set; }

        public bool Assigned { get; set; }
    }
}
