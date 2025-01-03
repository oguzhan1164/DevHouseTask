using DevHouseTask.Application.Bases;
using DevHouseTask.Application.Features.Auth.Rules;
using DevHouseTask.Application.Interfaces.AutoMapper;
using DevHouseTask.Application.Interfaces.Tokens;
using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<DevHouseTask.Domain.Entities.Auth> userManager;
        private readonly AuthRules authRules;
        private readonly UserRules userRules;
        private readonly ITokenService tokenService;

        public LoginCommandHandler(UserManager<DevHouseTask.Domain.Entities.Auth> userManager,AuthRules authRules,UserRules userRules,ITokenService tokenService,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.authRules = authRules;
            this.userRules = userRules;
            this.tokenService = tokenService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            DevHouseTask.Domain.Entities.Auth user = await userManager.FindByNameAsync(request.UserName);
            bool checkPassword = await userManager.CheckPasswordAsync(user, request.Password);

            await authRules.UserNameOrPasswordShouldNotBeInvalid(user, checkPassword);
            IList<string> roles = await userManager.GetRolesAsync(user);

            await userManager.UpdateAsync(user);
            
            var userx = unitOfWork.GetReadRepository<User>().Find(x => x.UserName == request.UserName).First();
            bool checkPswd = (userx.Password == request.Password);

            await userRules.UsersNameOrPasswordShouldNotBeInvalid(userx, checkPswd);
            var rulx =  unitOfWork.GetReadRepository<Permission>().Find(x=>x.Id==userx.PermissionId);

            JwtSecurityToken token = await tokenService.CreateToken(user,roles);
            JwtSecurityToken tokenUser = await tokenService.CreateUserToken(userx, roles);

            var _token = new JwtSecurityTokenHandler().WriteToken(token);
            var _tokenUser = new JwtSecurityTokenHandler().WriteToken(tokenUser);
            await userManager.SetAuthenticationTokenAsync(user,"Default","AccessToken", _token);

            return new()
            {
                Token = _token,
            };
        }
    }
}
