/*using Confluent.Kafka;
using mic_event_api.Application.Ports.Out;

namespace mic_event_api.Infrastructure.Messaging
{
    public class KafkaMessageProducer : IMessageProducer
    {
        private readonly IProducer<Null, string> _producer;

        // Constructor to initialize Kafka producer with configuration
        public KafkaMessageProducer()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092" // Kafka server details (ensure this is correct)
            };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        // Method to send message to Kafka topic
        public async Task SendMessageAsync(string topic, string message)
        {
            try
            {
                // Send message to the specified Kafka topic
                await _producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
                Console.WriteLine($"Message '{message}' sent to topic '{topic}'.");
            }
            catch (Exception ex)
            {
                // Log any errors encountered while sending message
                Console.WriteLine($"Error sending message to Kafka: {ex.Message}");
                throw;
            }
        }
    }
}
*/