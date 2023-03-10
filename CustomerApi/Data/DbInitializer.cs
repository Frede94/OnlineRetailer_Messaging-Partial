using CustomerApi.Models;

namespace CustomerApi.Data
{
    public class DbInitializer : IDbInitializer
    {
        //This method will create, seed the database.
        public void Initialize(CustomerApiContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //Check for customers
            if (context.Customers.Any())
            {
                return; //DB has been seeded.
            }

            List<Customer> customers = new List<Customer>
            {
                new Customer { CustomerId = 1, Name = "Alan Swong", EMail = "a.swong@hotmail.com", PhoneNumber = 50101010, BillingAdress = "NY, Main str. 12, 45a", ShippingAdress = "NY, Main str. 12, 45a", CreditStanding = "I don't know nothing about it"},
                new Customer { CustomerId = 2, Name = "Swong Alan", EMail = "s.alan@hotmail.com", PhoneNumber = 10505050, BillingAdress = "Tokio, Little str. 1, 4a", ShippingAdress = "Tokio, Little str. 1, 4a", CreditStanding = "I don't know nothing about it #2"},
                new Customer { CustomerId = 3, Name = "John Smith", EMail = "j.smith@hotmail.com", PhoneNumber = 12345678, BillingAdress = "Dallas, John Smith str 1. 1a", ShippingAdress = "Dallas, John Smith str 1. 1a", CreditStanding = "I don't know nothing about it #3"},
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
