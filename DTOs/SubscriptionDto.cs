namespace MealPlannerApi.DTOs
{
    public class SubscriptionDto
    {
        public string UserId { get; set; }
        public string PlanName { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
