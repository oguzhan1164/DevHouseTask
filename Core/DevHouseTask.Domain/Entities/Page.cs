using DevHouseTask.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Domain.Entities
{
    public class Page : EntityBase
    {
        public Page()
        {
                
        }
        public Page(string code)
        {
                Code = code;
        }
        public string  Code{ get; set; }
        public ICollection<PermissionDetail> PermissionDetail{ get; set; }
    }
}
