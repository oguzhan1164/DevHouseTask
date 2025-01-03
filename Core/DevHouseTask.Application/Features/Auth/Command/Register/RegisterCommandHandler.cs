using DevHouseTask.Application.Bases;
using DevHouseTask.Application.Features.Auth.Rules;
using DevHouseTask.Application.Interfaces.AutoMapper;
using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<Domain.Entities.Auth> userManager;
        private readonly RoleManager<Role> roleManager;
        public RegisterCommandHandler(AuthRules authRules, UserManager<DevHouseTask.Domain.Entities.Auth>userManager, RoleManager<Role> roleManager, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByNameAsync(request.UserName));

            DevHouseTask.Domain.Entities.Auth user = mapper.Map<DevHouseTask.Domain.Entities.Auth, RegisterCommandRequest>(request);
            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync("user"))
                    await roleManager.CreateAsync(new Role
                    {
                        Id = user.Id,
                        Name = "user",
                        NormalizedName = "USER"
                    });
                await userManager.AddToRoleAsync(user, "user");

                User users = new User(request.UserName, request.Password, false, 3);
                await unitOfWork.GetWriteRepository<User>().AddAsync(users);
                await unitOfWork.SaveAsync();
            }
            return Unit.Value;
        }
    }
}
