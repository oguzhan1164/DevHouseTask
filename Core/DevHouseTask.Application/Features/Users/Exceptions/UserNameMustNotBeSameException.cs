using DevHouseTask.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Users.Exceptions
{
    public class UserNameMustNotBeSameException : BaseExceptions
    {
        public UserNameMustNotBeSameException(){  }
        public UserNameMustNotBeSameException(string message) : base("Kullanıcı adı zaten var"){  }
    }
}
