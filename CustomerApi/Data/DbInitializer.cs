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
                    CustomerId = 1,
                    Name = "Byggemand Bob",
                    BillingAdress = "Langtbortevej 69, StorByén 42069",
                    CreditStanding = false,
                    EMail = "StorFed@ogsingle.dk",
                    PhoneNumber = 42069420,
                    ShippingAdress = "Langtbortevej 69, StorByén 42069"
                }
            };

            context.Customers.AddRange(orders);
            context.SaveChanges();
        }
    }
}
