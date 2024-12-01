using MealPlannerApi.Data;
using MealPlannerApi.DTOs;
using MealPlannerApi.Models;

namespace MealPlannerApi.Services
{
    public class ReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Review> GetAllReviews()
        {
            return _context.Reviews.ToList();
        }

        public Review GetReviewById(int id)
        {
            return _context.Reviews.Find(id);
        }

        public bool AddReview(ReviewDto model)
        {
            var review = new Review
            {
                RecipeId = model.RecipeId,
                UserId = model.UserId, // Directly set as int
                Rating = model.Rating,
                ReviewText = model.ReviewText, // Aligned with database and model
                ReviewDate = DateTime.Now
            };
            _context.Reviews.Add(review);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateReview(int id, ReviewDto model)
        {
            var review = _context.Reviews.Find(id);
            if (review == null) return false;

            review.Rating = model.Rating;
            review.ReviewText = model.ReviewText; // Aligned with database and model
            review.ReviewDate = DateTime.Now;
            return _context.SaveChanges() > 0;
        }

        public bool DeleteReview(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review == null) return false;

            _context.Reviews.Remove(review);
            return _context.SaveChanges() > 0;
        }
    }
}
