namespace MealPlannerApi.DTOs
{
    public class RegisterRoleRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; } // "Chef", "Nutritionist", or "Meal Planner"
    }
}
