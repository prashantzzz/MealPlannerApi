using MealPlannerApi.Data;
using MealPlannerApi.DTOs;
using MealPlannerApi.Models;

namespace MealPlannerApi.Services
{
    public class SubscriptionService
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Subscription> GetSubscriptionsForUser(string userId)
        {
            if (!int.TryParse(userId, out var userIdInt))
                return new List<Subscription>(); // Return empty if userId is not valid

            return _context.Subscriptions.Where(s => s.UserId == userIdInt).ToList();
        }

        public bool CreateSubscription(SubscriptionDto model)
        {
            if (!int.TryParse(model.UserId, out var userIdInt))
                return false; // Invalid UserId

            var subscription = new Subscription
            {
                UserId = userIdInt,
                SubscriptionType = model.SubscriptionType,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                PaymentStatus = model.PaymentStatus
            };
            _context.Subscriptions.Add(subscription);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateSubscription(int id, SubscriptionDto model)
        {
            var subscription = _context.Subscriptions.Find(id);
            if (subscription == null) return false;

            subscription.SubscriptionType = model.SubscriptionType;
            subscription.StartDate = model.StartDate;
            subscription.EndDate = model.EndDate;
            subscription.PaymentStatus = model.PaymentStatus;
            return _context.SaveChanges() > 0;
        }

        public bool CancelSubscription(int id)
        {
            var subscription = _context.Subscriptions.Find(id);
            if (subscription == null) return false;

            _context.Subscriptions.Remove(subscription);
            return _context.SaveChanges() > 0;
        }
    }
}
