using MealPlannerApi.Data;
using MealPlannerApi.Models;

namespace MealPlannerApi.Services
{
    public class DietaryPreferenceService
    {
        private readonly ApplicationDbContext _context;

        public DietaryPreferenceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public List<DietaryPreference> GetPreferencesForUser(int userId)
        {
            return _context.DietaryPreferences.Where(dp => dp.UserId == userId).ToList();
        }


        public DietaryPreference GetPreferenceById(int id)
        {
            return _context.DietaryPreferences.Find(id);
        }

        public List<DietaryPreference> GetAllPreferences()
        {
            return _context.DietaryPreferences.ToList();
        }

        public bool CreatePreference(DietaryPreference model)
        {
            var userExists = _context.Users.Any(u => u.UserId == model.UserId);
            if (!userExists)
            {
                throw new ArgumentException("The specified UserId does not exist.");
            }

            _context.DietaryPreferences.Add(model);
            return _context.SaveChanges() > 0;
        }


        public bool UpdatePreference(int id, DietaryPreference updatedModel)
        {
            var preference = _context.DietaryPreferences.Find(id);
            if (preference == null) return false;

            preference.PreferenceType = updatedModel.PreferenceType;
            preference.Description = updatedModel.Description;
            return _context.SaveChanges() > 0;
        }

        public bool DeletePreference(int id)
        {
            var preference = _context.DietaryPreferences.Find(id);
            if (preference == null) return false;

            _context.DietaryPreferences.Remove(preference);
            return _context.SaveChanges() > 0;
        }
    }
}
