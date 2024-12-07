namespace MealPlannerApi.DTOs
{
    public class MealPrepDto
    {
        public int RecipeId { get; set; }

        public string PortionSize { get; set; }

        public string IngredientsRequired { get; set; }

        public int PrepTime { get; set; }

        // Optional if related Recipe details are needed
        public RecipeDto Recipe { get; set; }
    }
}
