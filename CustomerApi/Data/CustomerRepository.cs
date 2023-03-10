using CustomerApi.Models;

namespace CustomerApi.Data
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly CustomerApiContext db;
        public CustomerRepository(CustomerApiContext context)
        {
            db = context;
        }

        Customer IRepository<Customer>.Add(Customer entity)
        {
            var newCustomer = db.Customers.Add(entity).Entity;
            db.SaveChanges();
            return newCustomer;
        }

        void IRepository<Customer>.Edit(Customer entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        Customer IRepository<Customer>.Get(int customerId)
        {
            return db.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        IEnumerable<Customer> IRepository<Customer>.GetAll()
        {
            return db.Customers.ToList();
        }

        void IRepository<Customer>.Remove(int customerId)
        {
            var customer = db.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            db.Customers.Remove(customer);
            db.SaveChanges(); ;
        }
    }
}
