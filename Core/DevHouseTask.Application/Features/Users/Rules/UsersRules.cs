using DevHouseTask.Application.Bases;
using DevHouseTask.Application.Features.Users.Exceptions;
using DevHouseTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Users.Rules
{
    public class UsersRules : BaseRules
    {
         public Task UserNameMustNotBeSame(IList<User> users,string requestUserName)
        {
            if (users.Any(x => x.UserName == requestUserName)) throw new UserNameMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
