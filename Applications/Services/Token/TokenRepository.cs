using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using RiwiEmplea.Applications.Interfaces.Repositories.Token;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Services.Token
{
    public class TokenRepository : ITokenRepository
    {
        private readonly string Key;
        private readonly string Issuer;
        private readonly string Audience;
        public TokenRepository(IConfiguration configuration)
        {
            Key = configuration["Jwt:Key"];
            Issuer = configuration["Jwt:Issuer"];
            Audience = configuration["Jwt:Audience"];
        }

        public string GetToken(User user)
        {
             var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email)
            };

            var tokenOptions = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = Issuer,
                Audience = Audience,
                SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
                
            };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenOptions);
                var tokenString = tokenHandler.WriteToken(securityToken);

                return tokenString;
        }
    }
}