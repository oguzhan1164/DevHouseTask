using DevHouseTask.Application.Bases;
using DevHouseTask.Application.Features.Auth.Exceptions;
using DevHouseTask.Domain.Entities;


namespace DevHouseTask.Application.Features.Auth.Rules
{
    public class UserRules : BaseRules
    {
        public Task UsersShouldNotBeExist(User user)
        {
            if (user is not null) throw new UsersAlreadyExistException();
            return Task.CompletedTask;
        }
        public Task UsersNameOrPasswordShouldNotBeInvalid(User user, bool checkPswd)
        {
            if (user is null || !checkPswd) throw new UsersNameOrPasswordShouldNotBeInvalidException();
            return Task.CompletedTask;
        }
    }
}
