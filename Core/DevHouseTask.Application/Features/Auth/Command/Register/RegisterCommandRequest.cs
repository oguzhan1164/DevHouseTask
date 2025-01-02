using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Auth.Command.Register
{
    public class RegisterCommandRequest : IRequest
    {
        public string UserName{ get; set; }
        public string Password{ get; set; }
        public string ConfirmPassword{ get; set; }
    }
}
