using Adapters.ServiceBus.Utils;
using Azure.Messaging.ServiceBus;

namespace Adapters.ServiceBus.Consumer;

public class ServiceBusQueueConsumer : IServiceBusQueueConsumer
{
    ServiceBusClient? client;
    ServiceBusProcessor? processor;
    private string body =  string.Empty;

    public async Task<string> GetMessageAsync(string queueName)
    {
        if (string.IsNullOrEmpty(queueName))
        {
            throw new ArgumentNullException(nameof(queueName));
        }

        var clientOptions = new ServiceBusClientOptions
        {
            TransportType = ServiceBusTransportType.AmqpTcp
        };

        client = new ServiceBusClient(ServiceBusUtils.ConnectionString, clientOptions);
        processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());

        try
        {
            processor.ProcessMessageAsync += MessageHandler;
            processor.ProcessErrorAsync += ErrorHandler;
            
            await processor.StartProcessingAsync();
            return await Task.FromResult(body);
        }
        finally
        {
            await processor.DisposeAsync();
            await client.DisposeAsync();
        }

    }

    Task ErrorHandler(ProcessErrorEventArgs arg)
    {
        return Task.CompletedTask;
    }

    async Task<string> MessageHandler(ProcessMessageEventArgs args)
    {
        body = args.Message.Body.ToString();
        
        await args.CompleteMessageAsync(args.Message);
        return body;
    }
}