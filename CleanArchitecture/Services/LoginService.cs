using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common.Enums;
using CleanArchitecture.Domain.Entities;
using IdentityModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Api.Services
{
    public class LoginService: ILoginService
    {
        private readonly IConfiguration _configuration;

        public LoginService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateLoginToken(Customer customer)
        {
            var authClaim = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Subject, customer.Id.ToString()),
                    new Claim(JwtClaimTypes.Name, customer.Name),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtClaimTypes.Role, Enum.GetName(typeof(Role), customer.Role) ?? ""),
                };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Security.Bearer:Secret"]!));
            var token = new JwtSecurityToken(
               issuer: _configuration["Security.Bearer:Authority"],
               audience: _configuration["Security.Bearer:Audience"],
               expires: DateTime.UtcNow.AddDays(7),
               claims: authClaim,
               signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
               );
            var resultToken = new JwtSecurityTokenHandler().WriteToken(token);
            return resultToken;
        }
    }
}
