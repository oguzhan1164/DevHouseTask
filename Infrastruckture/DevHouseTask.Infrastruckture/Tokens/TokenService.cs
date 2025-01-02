using DevHouseTask.Application.Interfaces.Tokens;
using DevHouseTask.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Infrastruckture.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<Auth> userManager;
        private readonly TokenSettings tokenSettings;

        public TokenService(IOptions<TokenSettings> options,UserManager<Auth> userManager)
        {
            this.userManager = userManager;
            tokenSettings = options.Value;
        }
        public async Task<JwtSecurityToken> CreateToken(Auth user, IList<Role> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,user.Id.ToString())
            };
            foreach (var role in roles) 
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret));

            var token = new JwtSecurityToken(
                issuer: tokenSettings.Issuer,
                audience: tokenSettings.Audience,
                claims:claims,
                signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha256)
                );

            await userManager.AddClaimsAsync(user,claims);

            return token;
        }
    }
}
