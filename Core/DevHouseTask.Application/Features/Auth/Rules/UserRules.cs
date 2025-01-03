using DevHouseTask.Application.Bases;
using DevHouseTask.Application.Features.Auth.Exceptions;
using DevHouseTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Auth.Rules
{
    public class UserRules : BaseRules
    {
        public Task UserShouldNotBeExist(User user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }
    }
}
