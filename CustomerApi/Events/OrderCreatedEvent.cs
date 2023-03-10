using RabbitMQ.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace CustomerApi.Events
{
    public class OrderCreatedEvent : Event
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime? Date { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
