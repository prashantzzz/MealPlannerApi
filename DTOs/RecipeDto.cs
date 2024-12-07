using System.ComponentModel.DataAnnotations;

public class RecipeDto
{
    [Required]
    [StringLength(20, MinimumLength = 3)]
    public string Name { get; set; }
    [StringLength(15)]
    public string Category { get; set; }
    public string Ingredients { get; set; }
    public int PreparationSteps { get; set; }  // Change this to int to match the database column type
    public int CookingTime { get; set; }
    public int Servings { get; set; }
    public string NutritionalInfo { get; set; }
}
