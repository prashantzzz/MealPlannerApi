namespace MealPlannerApi.DTOs
{
    public class RegisterRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; } // Set to "Customer" by default for `/register/customer`
    }
}
