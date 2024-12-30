using DevHouseTask.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Domain.Entities
{
    public class User : EntityBase
    {
        public User()
        {
                
        }
        public User(string userName,string password,bool isAdmin, int permissionId)
        {
            UserName = userName;
            Password = password;
            IsAdmin = isAdmin;
            PermissionId = permissionId;
        }
        public string UserName{ get; set; }
        public string Password{ get; set; }
        public bool IsAdmin{ get; set; }
        public int ?PermissionId{ get; set; }
        public Permission Permission { get; set; }
    }
}
