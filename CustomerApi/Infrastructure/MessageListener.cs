using System;
using System.Threading;
using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerApi.Infrastructure;

public class MessageListener
{


    public async Task Handle(OrderCreatedEvent @event)
    {
        var customer = _repository.Get(@event.CustomerId);
        var alldasd = _repository.GetAll();

        if (customer != null)
        {
            //TODO: check the customer’s credit standing
            //TODO: check if the customer has outstanding bills

        }
    }
}