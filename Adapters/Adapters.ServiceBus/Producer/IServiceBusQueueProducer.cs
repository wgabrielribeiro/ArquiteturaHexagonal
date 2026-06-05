namespace Adapters.ServiceBus.Producer;

public interface IServiceBusQueueProducer
{
    Task SendMessageAsync(string queueName, string body);
}