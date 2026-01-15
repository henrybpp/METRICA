using mic_bff_orchestator_api.Application.DTO;
using mic_bff_orchestator_api.Application.Ports.In;
using mic_bff_orchestator_api.Application.Ports.Out;

namespace mic_bff_orchestator_api.Application.UseCases
{
    public class CreateEventUseCase : ICreateEventUseCase
    {
        private readonly IMessageProducer _producer;

        public CreateEventUseCase(IMessageProducer producer)
        {
            _producer = producer;
        }

        public async Task HandleAsync(EventDTO dto, CancellationToken cancellationToken)
        {
            // Enviar el evento a Kafka
            await _producer.ProduceAsync("events-topic", dto, cancellationToken);
            var notificationDto = new NotificationDTO(
                dto.MessageId.ToString(), 
                DateTime.UtcNow.ToString() 
            );
            await _producer.ProduceAsync("notifications-topic", notificationDto, cancellationToken);
        }
    }
}

