//AuthService.cs
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MealPlannerApi.Models;
using MealPlannerApi.Data;
using MealPlannerApi.DTOs;
using MealPlannerApi.Helpers;

namespace MealPlannerApi.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly JwtHelper _jwtHelper;
        public AuthService(IConfiguration config, ApplicationDbContext context, JwtHelper jwtHelper)
        {
            _config = config;
            _context = context;
            _jwtHelper = jwtHelper;
        }

        public AuthResponseDto Login(AuthRequestDto model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == model.Username && u.IsActive);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                return null;

            var token = _jwtHelper.GenerateToken(user);
            return new AuthResponseDto
            {
                Username = user.Username,
                Role = user.Role,
                Token = token
            };
        }

        public void Logout()
        {
            // For stateless JWT, logout is managed client-side.
            // Implement token revocation logic if needed (e.g., token blacklist).
        }

        // Register customer or role-based user
        public bool Register(RegisterRequestDto model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == model.Username || u.Email == model.Email);
            if (user != null)
                return false; 
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var newUser = new User
            {
                Username = model.Username,
                PasswordHash = hashedPassword,
                Role = "Customer", // Default role 
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                IsActive = true
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return true;
        }

        // Overload for role-based user registration (Admin-only)
        public bool Register(RegisterRoleRequestDto model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == model.Username || u.Email == model.Email);
            if (user != null)
                return false;

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            if (!new[] { "Chef", "Nutritionist", "Meal Planner" }.Contains(model.Role))
                return false;

            var newUser = new User
            {
                Username = model.Username,
                PasswordHash = hashedPassword,
                Role = model.Role,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                IsActive = true
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

                if (user == null)
                    return false;

                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
