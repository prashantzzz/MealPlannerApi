namespace MealPlannerApi.DTOs
{
    public class ShoppingListDto
    {
        public string UserId { get; set; }
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public string Status { get; set; } // Example: "Pending", "Purchased"
    }
}
