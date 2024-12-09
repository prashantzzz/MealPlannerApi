namespace MealPlannerApi.DTOs
{
    public class ReviewDto
    {
        public int ReviewId { get; set; } 
        public int RecipeId { get; set; }
        public int UserId { get; set; } 
        public int Rating { get; set; } 
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
