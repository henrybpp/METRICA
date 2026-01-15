// Infrastructure/Messaging/KafkaMessageProducer.cs
using Confluent.Kafka;
using mic_bff_orchestator_api.Application.Ports.Out;
using System.Text.Json;

namespace mic_bff_orchestator_api.Infrastructure.Messaging
{
    public class KafkaMessageProducer : IMessageProducer
    {
        private readonly ProducerConfig _config;

        public KafkaMessageProducer(ProducerConfig config)
        {
            _config = config;
        }

        public async Task ProduceAsync<T>(string topic, T message, CancellationToken cancellationToken)
        {
            using var producer = new ProducerBuilder<Null, string>(_config).Build();

            var json = JsonSerializer.Serialize(message);
            var jsonEscape = JsonSerializer.Serialize(json);

            try
            {
                var deliveryResult = await producer.ProduceAsync(
                    topic,
                    new Message<Null, string> { Value = jsonEscape },
                    cancellationToken
                );

                Console.WriteLine($"[Kafka] Mensaje enviado a {deliveryResult.TopicPartitionOffset}: {json}");
            }
            catch (ProduceException<Null, string> ex)
            {
                Console.WriteLine($"Error al enviar mensaje: {ex.Error.Reason}");
            }
        }
    }
}
