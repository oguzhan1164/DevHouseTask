using DevHouseTask.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Auth.Exceptions
{
    public class UsersNameOrPasswordShouldNotBeInvalidException : BaseExceptions
    {
        public UsersNameOrPasswordShouldNotBeInvalidException() : base("Kullanıcı Adı veya şifre yanlıştır.") { }
    }
}
