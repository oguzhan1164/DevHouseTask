using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Pages.Commands.DeletePage
{
    public class DeletePageCommandRequest : IRequest
    {
        public int Id{ get; set; }
    }
}
