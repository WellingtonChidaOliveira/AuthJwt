using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Auth.Authorization
{
    public static class AccessTokenResult
    {

        public static AccessToken ValidateToken(HttpRequestData req)
        {
            if (req.Headers.TryGetValues("Authorization", out var token))
            {
                var tokenString = token.FirstOrDefault().Replace("Bearer ", "");
                var secret = Environment.GetEnvironmentVariable("accessKey");

                var tokenHandler = new JwtSecurityTokenHandler();
                try
                {
                    var validationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    var claimsPrincipal = tokenHandler.ValidateToken(tokenString, validationParameters, out var validatedToken);

                    var email = claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.Email).Value;
                    var role = claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.Role).Value;

                    return new AccessToken { Email = email, Role = role};


                }
                catch (Exception)
                {
                    return null;

                }


            }
            else
            {
                return null;
            }

        }


    }
}
