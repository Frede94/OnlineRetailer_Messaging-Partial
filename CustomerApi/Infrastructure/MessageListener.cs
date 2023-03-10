using System;
using System.Threading;
using CustomerApi.Data;
using CustomerApi.Models;
using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;
using SharedModels;

namespace CustomerApi.Infrastructure;

public class MessageListener
{
    IServiceProvider provider;
    string connectionString;
    IBus bus;

    // The service provider is passed as a parameter, because the class needs
    // access to the product repository. With the service provider, we can create
    // a service scope that can provide an instance of the product repository.
    public MessageListener(IServiceProvider provider, string connectionString)
    {
        this.provider = provider;
        this.connectionString = connectionString;
        bus = RabbitHutch.CreateBus(connectionString);
    }

    public void HandleCustomerVerification(CustomerVerificationMessage orderMessage, bool verification)
    {
        using (var scope = provider.CreateScope())
        {
            if(orderMessage.CustomerId != null)
            {
                var message = new EmptyMessage
                {
                    verified = verification
                };

                bus.PubSub.Publish(message, "verified");
            }
        }
    }
}