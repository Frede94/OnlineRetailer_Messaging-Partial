using EasyNetQ;

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
    
    /*
    public void PublishOrderStatusChangedMessage(int? customerId, IList<OrderLine> orderLines, string topic)
    {
        var message = new OrderStatusChangedMessage
        { 
            CustomerId = customerId,
            OrderLines = orderLines 
        };

        bus.PubSub.Publish(message, topic);
    }
    */
    
}