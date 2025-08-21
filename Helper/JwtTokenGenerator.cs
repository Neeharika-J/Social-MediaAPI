using Microsoft.IdentityModel.Tokens;
using SMApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SMApi.Helper
{
    public class JwtTokenGenerator
    {
        private readonly IConfiguration _configuration;
        
        public JwtTokenGenerator(IConfiguration config)
        {
            _configuration = config;
        }

        public (string Token, DateTime Expiry) GenerateToken(SMUser user)
        {
            var jwtsettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsettings["secretKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.userId.ToString()),
                new Claim(ClaimTypes.Name,user.userName),
                new Claim(ClaimTypes.Email,user.email)
            };
            var expires = DateTime.UtcNow.AddMinutes(int.Parse(jwtsettings["expiryMinutes"]!));

            var token=new JwtSecurityToken(
                issuer: jwtsettings["issuer"],
                audience: jwtsettings["audience"],
                claims:claims,
                expires: expires,
                signingCredentials: creds
            );
            string tokenstring= new JwtSecurityTokenHandler().WriteToken(token);
            return (tokenstring, expires); //tuple

        }
    }
}
