namespace Adapters.ServiceBus.Consumer;

public interface IServiceBusQueueConsumer
{
    Task<string> GetMessageAsync(string queueName);
}