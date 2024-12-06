using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MealPlannerApi.Services;
using MealPlannerApi.DTOs;

namespace MealPlannerApi.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllReviews()
        {
            return Ok(new { data = _reviewService.GetAllReviews() });
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetReviewById(int id)
        {
            var review = _reviewService.GetReviewById(id);
            return review != null
                ? Ok(new { data = review })
                : NotFound(new { message = "Review not found" });
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddReview(ReviewDto model)
        {
            var result = _reviewService.AddReview(model);
            return result
                ? Ok(new { message = "Review added successfully" })
                : BadRequest(new { message = "Failed to add review" });
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateReview(int id, ReviewDto model)
        {
            var result = _reviewService.UpdateReview(id, model);
            return result
                ? Ok(new { message = "Review updated successfully" })
                : NotFound(new { message = "Review not found" });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            var result = _reviewService.DeleteReview(id);
            return result
                ? Ok(new { message = "Review deleted successfully" })
                : NotFound(new { message = "Review not found" });
        }
    }
}
