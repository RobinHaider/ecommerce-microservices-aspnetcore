using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {UserName = "robin", FirstName = "Robin", LastName = "Haider", EmailAddress = "robin@gmail.com", AddressLine = "Chattogram", Country = "Bangladesh", TotalPrice = 350, CVV="654", CardName="RobinHaider", CardNumber="123456789", Expiration="2025", PaymentMethod=1, State="Chattogram", ZipCode="4443" }
            };
        }
    }
}
