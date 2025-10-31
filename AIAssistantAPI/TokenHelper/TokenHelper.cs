using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AIAssistantAPI.TokenHelper
{
    public class TokenHelper
    {
        public static ClaimsPrincipal? GetPrincipalFromToken(string token, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secret);
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false, // allow expired token (if needed)
                IssuerSigningKey = new SymmetricSecurityKey(key),
            };

            return tokenHandler.ValidateToken(token, parameters, out _);
        }

        public static string GenerateAccessToken(Dictionary<string, object> payload, string secret)
        {
            var claims = payload.Select(p => new Claim(p.Key, p.Value?.ToString() ?? "")).ToList();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
