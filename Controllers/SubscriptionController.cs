using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MealPlannerApi.Services;
using MealPlannerApi.DTOs;

namespace MealPlannerApi.Controllers
{
    [ApiController]
    [Route("api/subscriptions")]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService;

        public SubscriptionController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetSubscriptions()
        {
            return Ok(new { data = _subscriptionService.GetSubscriptionsForUser(User.Identity.Name) });
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpPost("{id}")]
        public IActionResult CreateSubscription(SubscriptionDto model)
        {
            var result = _subscriptionService.CreateSubscription(model);
            return result
                ? Ok(new { message = "Subscription created successfully" })
                : BadRequest(new { message = "Creation failed" });
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpPut("{id}")]
        public IActionResult UpdateSubscription(int id, SubscriptionDto model)
        {
            var result = _subscriptionService.UpdateSubscription(id, model);
            return result
                ? Ok(new { message = "Subscription updated successfully" })
                : NotFound(new { message = "Subscription not found" });
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpDelete("{id}")]
        public IActionResult CancelSubscription(int id)
        {
            var result = _subscriptionService.CancelSubscription(id);
            return result
                ? Ok(new { message = "Subscription cancelled successfully" })
                : NotFound(new { message = "Subscription not found" });
        }
    }
}
