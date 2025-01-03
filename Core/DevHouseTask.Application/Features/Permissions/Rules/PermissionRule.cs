using DevHouseTask.Application.Bases;
using DevHouseTask.Application.Features.Permissions.Exceptions;
using DevHouseTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Permissions.Rules
{
    public class PermissionRule : BaseRules
    {
        public Task PermissionCodeMustNotBeSame(IList<Permission> permissions, string requestName)
        {
            if (permissions.Any(x => x.Name == requestName)) throw new PermissionNameMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
