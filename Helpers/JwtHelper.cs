using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MealPlannerApi.Helpers
{
    public static class JwtHelper
    {
        /// <summary>
        /// Generates a JWT token for the specified user.
        /// </summary>
        /// <param name="username">The username of the user for whom the token is being generated.</param>
        /// <param name="role">The role of the user (e.g., Admin, Customer, Chef) for role-based access control.</param>
        /// <param name="secretKey">The secret key used for signing the JWT token.</param>
        /// <param name="issuer">The issuer of the JWT token, typically the application generating the token.</param>
        /// <param name="audience">The intended audience of the JWT token, usually the application or service the token is meant for.</param>
        /// <returns>A signed JWT token as a string.</returns>
        public static string GenerateJwtToken(string username, string role, string secretKey, string issuer, string audience)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
