using DevHouseTask.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Domain.Entities
{
    public class PermissionDetail : EntityBase
    {
        public PermissionDetail()
        {
                
        }
        public PermissionDetail(int permissionId,int pageId, bool canList, bool canCreate,bool canUpdate,bool canDelete)
        {
            PermissionId = permissionId;
            PageId = pageId;
            CanList = canList;
            CanCreate = canCreate;
            CanUpdate = canUpdate;
            CanDelete = canDelete;
        }
        public int PermissionId{ get; set; }
        public int PageId{ get; set; }
        public bool CanList{ get; set; }
        public bool CanCreate{ get; set; }
        public bool CanUpdate{ get; set; }
        public bool CanDelete{ get; set; }
        public Permission Permission{ get; set; }
        public Page Page{ get; set; }
    }
}
