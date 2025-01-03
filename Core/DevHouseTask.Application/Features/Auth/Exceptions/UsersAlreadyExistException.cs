using DevHouseTask.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Auth.Exceptions
{
    public class UsersAlreadyExistException : BaseExceptions
    {
        public UsersAlreadyExistException() : base("Böyle bir kullanıcı zaten var") { }
    }
}
