namespace CustomerApi.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public int PhoneNumber { get; set; }
        public string BillingAdress { get; set; }
        public string ShippingAdress { get; set; }
        public string CreditStanding { get; set; }
    }
}
