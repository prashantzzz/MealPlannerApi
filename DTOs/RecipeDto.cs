public class RecipeDto
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Ingredients { get; set; }
    public int PreparationSteps { get; set; }  // Change this to int to match the database column type
    public int CookingTime { get; set; }
    public int Servings { get; set; }
    public string NutritionalInfo { get; set; }
}
