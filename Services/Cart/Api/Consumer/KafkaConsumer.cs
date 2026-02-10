using Confluent.Kafka;

namespace Cart.Service.Api.Consumer;

public static class KafkaConsumer
{
    public static void ReadMessage()
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            ClientId = "my-app",
            GroupId = "my-group",
            BrokerAddressFamily = BrokerAddressFamily.V4,
        };
        using
        var consumer = new ConsumerBuilder<Ignore,
            string>(config).Build();
        consumer.Subscribe("my-topic");
        try
        {
            while (true)
            {
                var consumeResult = consumer.Consume();
                Console.WriteLine($"Message received from {consumeResult.TopicPartitionOffset}: {
                        consumeResult.Message.Value }" );
                }
            } catch (OperationCanceledException) {
                // The consumer was stopped via cancellation token.
            } finally {
                consumer.Close();
            }
            Console.ReadLine();
        }
}
