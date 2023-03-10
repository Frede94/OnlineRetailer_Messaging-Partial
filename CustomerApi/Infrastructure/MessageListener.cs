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

    // The service provider is passed as a parameter, because the class needs
    // access to the product repository. With the service provider, we can create
    // a service scope that can provide an instance of the product repository.
    public MessageListener(IServiceProvider provider, string connectionString)
    {
        this.provider = provider;
        this.connectionString = connectionString;
    }

    public void HandleCustomerVerification(CustomerVerificationMessage message)
    {
        using (var scope = provider.CreateScope())
        {
            if(message.CustomerId != null)
            {

            }
        }
    }
}