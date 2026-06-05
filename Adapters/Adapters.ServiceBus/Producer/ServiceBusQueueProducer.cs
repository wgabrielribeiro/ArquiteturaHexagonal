using Adapters.ServiceBus.Utils;
using Azure.Messaging.ServiceBus;

namespace Adapters.ServiceBus.Producer;

public class ServiceBusQueueProducer : IServiceBusQueueProducer
{
    ServiceBusClient? client;
    ServiceBusSender? sender;
    
    public async Task SendMessageAsync(string queueName, string body)
    {
        client = new ServiceBusClient(ServiceBusUtils.ConnectionString);
        sender = client.CreateSender(queueName);

        using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();
        
        if (!messageBatch.TryAddMessage(new ServiceBusMessage(body)))
        {
            throw new Exception("This message is too large to fit in the batch!");
        }

        try
        {
            await sender.SendMessagesAsync(messageBatch);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"The message could not be sent: {e.Message}");
        }
        finally
        {
            await sender.DisposeAsync();
            await client.DisposeAsync();
        }
        
    }
}