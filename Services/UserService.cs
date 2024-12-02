using MealPlannerApi.Data;
using MealPlannerApi.DTOs;
using MealPlannerApi.Models;

namespace MealPlannerApi.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return _context.Users.Select(u => new UserDto
            {
                UserId = u.UserId, // Fixed from Id to UserId
                Username = u.Username,
                Role = u.Role,
                IsActive = u.IsActive
            }).ToList();
        }

        public UserDto GetUserById(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId); // Fixed from Id to UserId
            if (user == null) return null;

            return new UserDto
            {
                UserId = user.UserId, // Fixed from Id to UserId
                Username = user.Username,
                Role = user.Role,
                IsActive = user.IsActive
            };
        }

        public bool UpdateUser(int userId, UserDto model)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId); // Fixed from Id to UserId
            if (user == null) return false;

            user.Username = model.Username;
            user.Role = model.Role;
            user.IsActive = model.IsActive;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId); // Fixed from Id to UserId
            if (user == null) return false;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}
