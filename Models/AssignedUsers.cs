using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlannerApi.Models
{
    public class AssignedUsers
    {
        [Key]
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int NutriId { get; set; }
        public int ChefId { get; set; }
        public int PlannerId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("NutriId")]
        public User Nutritionist { get; set; }

        [ForeignKey("ChefId")]
        public User Chef { get; set; }

        [ForeignKey("PlannerId")]
        public User Planner { get; set; }
    }
}
