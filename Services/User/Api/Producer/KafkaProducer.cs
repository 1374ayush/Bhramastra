using Confluent.Kafka;
using Domain.Models;
using System.Text.Json;

namespace User.Service.Api.Producer
{
    public static class KafkaProducer
    {
        public static async Task CreateMessage()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                ClientId = "my-app",
                BrokerAddressFamily = BrokerAddressFamily.V4,
            };
            using
            var producer = new ProducerBuilder<Null,
                string>(config).Build();

            var input = new UserEntityModel()
            {
                Id = 1,
                Name = "John Doe",
                Email = "jhon@yandex.com"
            };

            var json = JsonSerializer.Serialize(input);

            var message = new Message<Null,
                string>
            {
                Value = json
            };
            var deliveryReport = await producer.ProduceAsync("my-topic", message);
            Console.WriteLine($"Message delivered to {deliveryReport.TopicPartitionOffset}");
        }
    }
}
