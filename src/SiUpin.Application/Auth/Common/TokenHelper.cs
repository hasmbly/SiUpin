using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SiUpin.Domain.Constants;
using SiUpin.Domain.Entities;

namespace SiUpin.Application.Auth.Common
{
    public static class TokenHelper
    {
        public static string GenerateToken(User user, string securityKey)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            if (string.IsNullOrEmpty(user.PictureURL))
            {
                user.PictureURL = "fortifex-user.png";
            }

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            claims.Add(new Claim(ClaimType.PictureUrl, user.PictureURL));
            claims.Add(new Claim(ClaimTypes.Role, user.Role.Name));
            claims.Add(new Claim(ClaimType.UserID, user.UserID));

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}