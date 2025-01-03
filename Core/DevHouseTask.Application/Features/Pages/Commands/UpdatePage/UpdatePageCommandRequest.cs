using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Pages.Commands.UpdatePage
{
    public class UpdatePageCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Code{ get; set; }
    }
}
