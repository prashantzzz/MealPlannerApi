namespace MealPlannerApi.DTOs
{
    public class ReviewDto
    {
        public int RecipeId { get; set; }
        public int UserId { get; set; } // Changed to int
        public int Rating { get; set; } // Between 1 and 5
        public string ReviewText { get; set; } // Aligned with database and model
    }
}
