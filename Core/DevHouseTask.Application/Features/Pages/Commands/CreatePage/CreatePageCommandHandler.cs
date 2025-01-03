using DevHouseTask.Application.Bases;
using DevHouseTask.Application.Features.Pages.Rules;
using DevHouseTask.Application.Interfaces.AutoMapper;
using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Pages.Commands.CreatePage
{
    public class CreatePageCommandHandler :BaseHandler, IRequestHandler<CreatePageCommandRequest,Unit>
    {
        private readonly PageRules pageRules;

        public CreatePageCommandHandler(PageRules pageRules,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.pageRules = pageRules;
        }

        public async Task<Unit> Handle(CreatePageCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Page> pages = await unitOfWork.GetReadRepository<Page>().GetAllAsync();

            var userClaims=httpContextAccessor.HttpContext.User.Claims;
            var roleClaims = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            

            await pageRules.PageCodeMustNotBeSame(pages,request.Code);

            Page page = new(request.Code);
            await unitOfWork.GetWriteRepository<Page>().AddAsync(page);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
