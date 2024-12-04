using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlannerApi.Models
{
    public class MealPrep
    {
        [Key]
        public int MealPrepId { get; set; }

        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }
        public string PortionSize { get; set; }
        public string IngredientsRequired { get; set; }
        public int PrepTime { get; set; }
        public Recipe Recipe { get; set; }
    }
}
