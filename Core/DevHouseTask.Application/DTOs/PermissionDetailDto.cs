using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.DTOs
{
    public class PermissionDetailDto
    {
        public int PermissionDetailId { get; set; }
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool CanList { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}
