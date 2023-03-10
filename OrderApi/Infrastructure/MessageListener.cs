using EasyNetQ;
using OrderApi.Controllers;
using SharedModels;

namespace OrderApi.Infrastructure;

public class MessageListener
{
    private IServiceProvider _provider;
    private string _connectionString;
    
    // The service provider is passed as a parameter, because the class needs
    // access to the product repository. With the service provider, we can create
    // a service scope that can provide an instance of the product repository.
    public MessageListener(IServiceProvider provider, string connectionString)
    {
        _provider = provider;
        _connectionString = connectionString;
    }

    public void Start()
    {
        using (var bus = RabbitHutch.CreateBus(_connectionString))
        {
            bus.PubSub.Subscribe<EmptyMessage>("customerAPI",
                HandleCustomerVerified, x => x.WithTopic("verified"));
        }
        
        lock (this)
        {
            Monitor.Wait(this);
        }
        
    }

    private void HandleCustomerVerified(EmptyMessage message)
    {
        OrdersController.verified = message.verified;
    }
}