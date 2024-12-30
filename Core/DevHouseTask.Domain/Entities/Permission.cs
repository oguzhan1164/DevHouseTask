using DevHouseTask.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Domain.Entities
{
    public  class Permission : EntityBase
    {
        public Permission()
        {
          
        }
        public Permission(string name)
        {
                Name = name;
        }
        public string Name { get; set; }
        public ICollection<PermissionDetail> PermissionDetail { get; set; }
    }
}
