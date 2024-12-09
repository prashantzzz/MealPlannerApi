namespace MealPlannerApi.DTOs
{
    public class NutritionDto
    {
        public int RecipeId { get; set; }
        public int Calories { get; set; }  // Keep as int
        public int Protein { get; set; }   // Change to int
        public int Carbs { get; set; }     // Change to int
        public int Fat { get; set; }       // Change to int
        public string Vitamins { get; set; }
    }

    public class NutritionResponseDto
    {
        public int NutritionId { get; set; }
        public int RecipeId { get; set; }
        public int Calories { get; set; }  // Keep as int
        public int Protein { get; set; }   // Change to int
        public int Carbs { get; set; }     // Change to int
        public int Fat { get; set; }       // Change to int
        public string Vitamins { get; set; }
    }
}
