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
    IBus _bus;

    // The service provider is passed as a parameter, because the class needs
    // access to the product repository. With the service provider, we can create
    // a service scope that can provide an instance of the product repository.
    public MessageListener(IServiceProvider provider, string connectionString)
    {
        this.provider = provider;
        this.connectionString = connectionString;
        _bus = RabbitHutch.CreateBus(connectionString);
    }
    
    public void Start()
    {
        using (var bus = RabbitHutch.CreateBus(connectionString))
        {
            bus.PubSub.Subscribe<CustomerVerificationMessage>(
                "customerApiVerified",
                HandleCustomerVerification,
                x => x.WithTopic("verified"));
        }

        lock (this)
        {
            Monitor.Wait(this);
        }
    }
    
    public void HandleCustomerVerification(CustomerVerificationMessage orderMessage)
    {
        using (var scope = provider.CreateScope())
        {
            var services = scope.ServiceProvider;
            var customerRepos = services.GetService<IRepository<Customer>>();
            if(orderMessage.CustomerId != null)
            {
                var customer = customerRepos.Get(orderMessage.CustomerId.Value);
                if (customer != null)
                {
                    var message = new EmptyMessage
                    {
                        verified = true
                    };

                    _bus.PubSub.Publish(message, "verified");
                }
                else
                {
                    var message = new EmptyMessage
                    {
                        verified = false
                    };

                    _bus.PubSub.Publish(message, "verified");
                }
                
            }
        }
    }
}