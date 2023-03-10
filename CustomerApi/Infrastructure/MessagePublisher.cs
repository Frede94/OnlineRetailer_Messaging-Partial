using EasyNetQ;
using SharedModels;

namespace CustomerApi.Infrastructure;

public class MessagePublisher : IMessagePublisher, IDisposable
{
    private IBus bus;
    
    public MessagePublisher(string connectionString)
    {
        bus = RabbitHutch.CreateBus(connectionString);
    }
    
    public void Dispose()
    {
        bus.Dispose();
    }

    public void PublishCustomerVerificationMessage(bool verification, string topic)
    {
        var message = new EmptyMessage
        {
            verified = verification
        };
        
        bus.PubSub.Publish(message, topic);
    }

}