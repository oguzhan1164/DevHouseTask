using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Domain.Entities
{
    public class Role : IdentityRole<int>
    {
        public string Name { get; set; }
        public ICollection<PermissionDetail> PermissionDetail { get; set; }
    }
}
