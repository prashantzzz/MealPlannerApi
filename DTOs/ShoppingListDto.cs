namespace MealPlannerApi.DTOs
{
    public class ShoppingListDto
    {
        public int MealPlanId { get; set; }
        public string IngredientName { get; set; }
        public double Quantity { get; set; } // Changed to double
        public string Status { get; set; } // Pending, Purchased
    }
}
