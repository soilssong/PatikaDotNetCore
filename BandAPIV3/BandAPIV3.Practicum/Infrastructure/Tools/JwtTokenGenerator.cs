using BandAPIV3.Practicum.Core.Application.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BandAPIV3.Practicum.Infrastructure.Tools
{
    public class JwtTokenGenerator
    {

        public static TokenResponseDto GenerateToken(CheckUserResponseDto dto)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrEmpty(dto.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, dto.Role));
            }
            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));
            if (!string.IsNullOrEmpty(dto.Role))
            {
                claims.Add(new Claim("Username", dto.UserName));
            }

          

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            SigningCredentials credentails = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                issuer: JwtTokenDefaults.ValidIssuer,
                audience: JwtTokenDefaults.ValidAudience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expireDate,
                signingCredentials: credentails

                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return new TokenResponseDto(handler.WriteToken(jwtToken), expireDate);

        }
    }
}
