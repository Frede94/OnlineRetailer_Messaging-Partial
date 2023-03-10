using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Data
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly CustomerApiContext db;
        public CustomerRepository(CustomerApiContext contex) { db = contex; }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers.ToList();
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

        void IRepository<Customer>.Remove(int customerId)
        {
            var customer = db.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            db.Customers.Remove(customer);
            db.SaveChanges(); ;
        }
    }
}
