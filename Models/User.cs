using System.ComponentModel.DataAnnotations;

namespace MealPlannerApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        [MaxLength(20)]
        public string Role { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        [MaxLength(12)]
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
