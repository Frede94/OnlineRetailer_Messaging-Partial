using System;
using System.Collections.Generic;
using System.Linq;
using SharedModels;

namespace OrderApi.Data
{
    public class DbInitializer : IDbInitializer
    {
        // This method will create and seed the database.
        public void Initialize(OrderApiContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any Orders
            if (context.Orders.Any())
            {
                return;   // DB has been seeded
            }

            List<Order> orders = new List<Order>
            {
                new Order {
                    Date = DateTime.Today,
                    customerId = 1,
                    OrderLines = new List<OrderLine>{
                        new OrderLine { ProductId = 1, Quantity = 2, CustomerId = 1 } }
                }, new Order {
                    Date = DateTime.Today,
                    customerId = 1,
                    OrderLines = new List<OrderLine>{
                        new OrderLine { ProductId = 2, Quantity = 5, CustomerId = 1} }
                }, new Order {
                    Date = DateTime.Today,
                    customerId = 1,
                    OrderLines = new List<OrderLine>{
                        new OrderLine { ProductId = 1, Quantity = 11, CustomerId = 1 } }
                }
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}
