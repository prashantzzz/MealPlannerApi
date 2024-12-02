namespace MealPlannerApi.DTOs
{
    public class MealPlanDto
    {
        public int UserId { get; set; }  // Change to int
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MealType { get; set; }
        public int RecipeId { get; set; }
    }
}
