using CustomerApi.Models;

namespace CustomerApi.Data
{
    public class DbInitializer : IDbInitializer
    {
        public void Initialize(CustomerApiContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        
            // Look for any Orders
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            List<Customer> orders = new List<Customer>
            {
                new Customer {
                    
                }
            };

            context.Customers.AddRange(orders);
            context.SaveChanges();
        }
    }
}
