namespace MealPlannerApi.DTOs
{
    public class SubscriptionDto
    {
        public string UserId { get; set; } // Accept as string, converted in service
        public string SubscriptionType { get; set; } // e.g., Weekly, Monthly
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PaymentStatus { get; set; } // Paid, Pending, etc.
    }
}
