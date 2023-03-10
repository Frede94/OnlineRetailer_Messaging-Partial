//using CustomerApi.Data;
//using CustomerApi.Events;
//using CustomerApi.Models;
//using System;

//namespace CustomerApi.EventHandlers
//{
//    public class OrderCreatedEventHandler : IEventHandler<OrderCreatedEvent>
//    {
//        private readonly IRepository<Customer> _repository;
//        private readonly IRabbitMQBus _Bus;

//        public OrderCreatedEventHandler (IRepository<Customer> repository, IRabbitMQBus bus)
//        {
//            _repository = repository;
//            _bus = bus;
//        }

//        public async Task Handler(OrderCreatedEvent @event)
//        {
//            var customer = _repository.Get(@event.CustomerId);
//            var alldasd = _repository.GetAll();

//            if (customer != null)
//            {
//                //TODO: check the customer’s credit standing
//                //TODO: check if the customer has outstanding bills

//                // publish to ProductApi to check if order is in stock (ProductApi.EventHandlers.OrderAcceptedEventHandler.cs)
//                _bus.Publish(new OrderCreatedCustomerAcceptedEvent
//                {
//                    Id = @event.Id,
//                    CustomerId = @event.CustomerId,
//                    Date = @event.Date,
//                    ProductId = @event.ProductId,
//                    Quantity = @event.Quantity
//                });
//            }
//    }
//}
