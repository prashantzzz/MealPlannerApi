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

        [Authorize]
        [HttpGet]
        public IActionResult GetSubscriptions()
        {
            return Ok(_subscriptionService.GetSubscriptionsForUser(User.Identity.Name));
        }

        [Authorize]
        [HttpPost("{id}")]
        public IActionResult CreateSubscription(SubscriptionDto model)
        {
            var result = _subscriptionService.CreateSubscription(model);
            return result ? Ok("Subscription created successfully") : BadRequest("Creation failed");
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateSubscription(int id, SubscriptionDto model)
        {
            var result = _subscriptionService.UpdateSubscription(id, model);
            return result ? Ok("Subscription updated successfully") : NotFound("Subscription not found");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult CancelSubscription(int id)
        {
            var result = _subscriptionService.CancelSubscription(id);
            return result ? Ok("Subscription cancelled successfully") : NotFound("Subscription not found");
        }
    }
}
