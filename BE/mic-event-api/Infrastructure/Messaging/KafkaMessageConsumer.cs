using Confluent.Kafka;
using mic_event_api.Application.Ports.In;
using mic_event_api.Application.Ports.Out;
using mic_event_api.Application.UseCases;
using mic_event_api.Domain.Entities;
using System.Text.Json;

namespace mic_event_api.Infrastructure.Messaging
{
        public class KafkaMessageConsumer : IMessageConsumer
        {
            private readonly string _topic;
            private readonly ConsumerConfig _config;

            public KafkaMessageConsumer(string topic, ConsumerConfig config)
            {
                _topic = topic;
                _config = config;
            }

            public async Task<string?> ConsumeAsync(CancellationToken cancellationToken)
            {
                using var consumer = new ConsumerBuilder<Ignore, string>(_config).Build();
                consumer.Subscribe(_topic);

                try
                {
                    // Consumir un mensaje
                    var result = consumer.Consume(cancellationToken);

                    if (result != null)
                    {
                        Console.WriteLine($"[Kafka] Mensaje recibido: {result.Message.Value}");

                        // Commit manual del offset para avanzar
                        consumer.Commit(result);

                        // Retornar el JSON string al BackgroundService
                        return result.Message.Value;
                    }
                }
                catch (ConsumeException ex)
                {
                    Console.WriteLine($"Error al consumir: {ex.Error.Reason}");
                }
                catch (OperationCanceledException)
                {
                    consumer.Close();
                }

                return null;
            }
        }
    

}


