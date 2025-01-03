using DevHouseTask.Application.Bases;
using DevHouseTask.Application.Features.Pages.Exceptions;
using DevHouseTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Pages.Rules
{
    public class PageRules : BaseRules
    {
        public Task PageCodeMustNotBeSame(IList<Page> pages,string requestCode)
        {
            if (pages.Any(x=>x.Code==requestCode)) throw new PageCodeMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
