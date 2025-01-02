using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Domain.Entities
{
    public class Auth : IdentityUser <int>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
