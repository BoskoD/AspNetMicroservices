using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistance
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seeding database with associated {DBContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order()
                {
                    UserName = "TestUser",
                    FirstName = "Bosko",
                    LastName = "Danilovic",
                    EmailAddress = "boskodamin1@tendancemusic.com",
                    AddressLine = "TestAddress",
                    Country = "Serbia",
                    State = "Serbia",
                    ZipCode = "11000",
                    CardName = "Visa",
                    CardNumber = "1234566789",
                    Expiration = "2023-12-12",
                    CVV = "900",
                    PaymentMethod = 1,
                    CreatedBy = "Bosko",
                    CreatedDate = DateTime.UtcNow,
                    LastModifiedBy = "Bosko",
                    LastModifiedAt = DateTime.UtcNow,
                    TotalPrice = 350
                }
            };
        }
    }
}