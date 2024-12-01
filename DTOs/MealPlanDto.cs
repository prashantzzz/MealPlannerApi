namespace MealPlannerApi.DTOs
{
    public class MealPlanDto
    {
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MealType { get; set; } // e.g., Breakfast, Lunch, Dinner
        public int RecipeId { get; set; }
    }
}
