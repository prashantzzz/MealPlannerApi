namespace MealPlannerApi.DTOs
{
    public class DietaryPreferenceDto
    {
        public int PreferenceId { get; set; }
        public int UserId { get; set; }
        public string PreferenceType { get; set; }
        public string Description { get; set; }
    }
}
