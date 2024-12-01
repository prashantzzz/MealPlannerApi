using System.ComponentModel.DataAnnotations;

namespace MealPlannerApi.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string SubscriptionType { get; set; } // e.g., Weekly, Monthly

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required, MaxLength(20)]
        public string PaymentStatus { get; set; } // Paid, Pending, etc.
    }
}
