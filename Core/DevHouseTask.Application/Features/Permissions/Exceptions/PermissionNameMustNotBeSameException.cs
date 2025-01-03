using DevHouseTask.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Permissions.Exceptions
{
    public class PermissionNameMustNotBeSameException :BaseExceptions
    {
        public PermissionNameMustNotBeSameException()
        {
            
        }
        public PermissionNameMustNotBeSameException(string message) : base("Sayfa kodu zaten var")
        {
            
        }
    }
}
