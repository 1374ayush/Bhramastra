using Confluent.Kafka;
using Domain.Models.ConumerModels;
using System.Text.Json;

namespace Cart.Service.Api.Consumer;

public class KafkaConsumer : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Yield(); // allow app to finish starting

        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            ClientId = "my-app",
            GroupId = "my-group",
            BrokerAddressFamily = BrokerAddressFamily.V4,
        };

        using var consumer = new ConsumerBuilder<Ignore,string>(config).Build();
        consumer.Subscribe("my-topic");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var consumeResult = consumer.Consume(TimeSpan.FromSeconds(5));
                if (consumeResult == null) continue;

                var result = JsonSerializer.Deserialize<User>(consumeResult.Message.Value);

                Console.WriteLine($"Message received from {consumeResult.TopicPartitionOffset}: {result?.Id}, {result?.Name}, {result?.Email}");
            }
            catch (OperationCanceledException)
            {
                // The consumer was stopped via cancellation token.
                break;
            }
        }
    }
}
