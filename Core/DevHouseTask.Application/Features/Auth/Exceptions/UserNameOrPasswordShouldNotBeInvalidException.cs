using DevHouseTask.Application.Bases;

namespace DevHouseTask.Application.Features.Auth.Exceptions
{
    public class UserNameOrPasswordShouldNotBeInvalidException : BaseExceptions
    {
        public UserNameOrPasswordShouldNotBeInvalidException() : base("Kullanıcı Adı veya şifre yanlıştır.") { }
    }
}
