using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Pages.Commands.CreatePage
{
    public class CreatePageCommandRequest : IRequest<Unit>
    {
        public string Code { get; set; }
    }
}
