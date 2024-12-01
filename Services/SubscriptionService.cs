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
            return _context.Subscriptions.Where(s => s.UserId == userId).ToList();
        }

        public bool CreateSubscription(SubscriptionDto model)
        {
            var subscription = new Subscription
            {
                UserId = model.UserId,
                PlanName = model.PlanName,
                Price = model.Price,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };
            _context.Subscriptions.Add(subscription);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateSubscription(int id, SubscriptionDto model)
        {
            var subscription = _context.Subscriptions.Find(id);
            if (subscription == null) return false;

            subscription.PlanName = model.PlanName;
            subscription.Price = model.Price;
            subscription.StartDate = model.StartDate;
            subscription.EndDate = model.EndDate;
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
