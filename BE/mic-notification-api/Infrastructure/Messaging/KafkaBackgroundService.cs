using mic_notification_api.Application.Ports.In;
using mic_notification_api.Application.Ports.Out;
using mic_notification_api.Domain.Entities;
using System.Text.Json;

namespace mic_notification_api.Infrastructure.Messaging
{
    public class KafkaBackgroundService : BackgroundService
    {
        private readonly IMessageConsumer _consumer;
        private readonly IServiceScopeFactory _scopeFactory;

        public KafkaBackgroundService(IMessageConsumer consumer, IServiceScopeFactory scopeFactory)
        {
            _consumer = consumer;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // 1. Obtener mensaje desde Kafka (JSON string)
                var message = await _consumer.ConsumeAsync(stoppingToken);
                Console.WriteLine($"[message] in: {message}");
                if (!string.IsNullOrEmpty(message))
                {
                    try
                    {
                        // 2. Deserializar JSON a DTO
                        string? jsonInterno = JsonSerializer.Deserialize<string>(message);

                        if (jsonInterno != null)
                        {
                            Notification? orderNotification = JsonSerializer.Deserialize<Notification>(jsonInterno);
                            // 3. Crear scope para resolver el caso de uso Scoped
                            using var scope = _scopeFactory.CreateScope();
                            var useCase = scope.ServiceProvider.GetRequiredService<INotificationUseCase>();
                            // 4. Invocar el caso de uso
                            if (orderNotification != null)
                            {
                                await useCase.Execute(orderNotification);
                                Console.WriteLine($"[Kafka] Evento procesado y persistido: {orderNotification.Id}");
                            }
                            else
                            {
                                throw new Exception("OrderEvent nulo...");
                            }

                        }
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine($"Error deserializando JSON: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error procesando mensaje: {ex.Message}");
                    }
                }

                // Pequeña pausa para no bloquear el loop
                await Task.Delay(100, stoppingToken);
            }
        }
    }
}
