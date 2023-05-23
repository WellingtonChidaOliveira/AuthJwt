using Application.Abstraction;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Security
{
    public sealed class JwtProvider : IJwtProvider
    {
        public Token GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                 //TODO: Add roles to claims 
                new Claim(ClaimTypes.Email, user.Email),
            };

            //TODO: Add secret to key vault or something
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123asdfn1234n1234h241h234j123gf14g"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                      issuer: "localhost",
                      audience: "localhost",
                      claims: claims,
                      expires: DateTime.Now.AddMinutes(30),
                      signingCredentials: creds);

            var response = new Token
            {
                Authenticated = true,
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Created = DateTime.Now.ToString(),
                Expiration = DateTime.Now.AddMinutes(30).ToString(),
                Message = "Success"
            };

            return response;
        }
    }
}
