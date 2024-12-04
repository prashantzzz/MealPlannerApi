using MealPlannerApi.Data;
using MealPlannerApi.Models;
using MealPlannerApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MealPlannerApi.Services
{
    public class AssignedUsersService
    {
        private readonly ApplicationDbContext _context;

        public AssignedUsersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AssignedUsers> GetAllAssignedUsers()
        {
            return _context.AssignedUsers
                .Include(a => a.User)
                .Include(a => a.Nutritionist)
                .Include(a => a.Chef)
                .Include(a => a.Planner)
                .ToList();
        }

        public AssignedUsers GetAssignedUserById(int id)
        {
            return _context.AssignedUsers
                .Include(a => a.User)
                .Include(a => a.Nutritionist)
                .Include(a => a.Chef)
                .Include(a => a.Planner)
                .FirstOrDefault(a => a.UserRoleId == id);
        }

        public bool AddAssignedUser(AssignedUsersDto model)
        {
            var assignedUser = new AssignedUsers
            {
                UserId = model.UserId,
                NutriId = model.NutriId,
                ChefId = model.ChefId,
                PlannerId = model.PlannerId
            };

            _context.AssignedUsers.Add(assignedUser);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateAssignedUser(int id, AssignedUsersDto model)
        {
            var existing = _context.AssignedUsers.FirstOrDefault(a => a.UserRoleId == id);
            if (existing == null) return false;

            existing.UserId = model.UserId;
            existing.NutriId = model.NutriId;
            existing.ChefId = model.ChefId;
            existing.PlannerId = model.PlannerId;

            _context.AssignedUsers.Update(existing);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteAssignedUser(int id)
        {
            var assignedUser = _context.AssignedUsers.FirstOrDefault(a => a.UserRoleId == id);
            if (assignedUser == null) return false;

            _context.AssignedUsers.Remove(assignedUser);
            return _context.SaveChanges() > 0;
        }
    }
}
