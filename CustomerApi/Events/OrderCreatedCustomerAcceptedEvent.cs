using RabbitMQ.Eventing;

namespace CustomerApi.Events
{
    public class OrderCreatedCustomerAcceptedEvent : Event
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime? Date { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
