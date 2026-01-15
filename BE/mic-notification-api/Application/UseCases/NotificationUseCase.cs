using mic_notification_api.Application.Ports.In;
using mic_notification_api.Application.Ports.Out;
using mic_notification_api.Domain.Entities;

namespace mic_notification_api.Application.UseCases
{
    public class NotificationUseCase : INotificationUseCase
    {
        private readonly INotificationRepository _repository;

        public NotificationUseCase(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Notification notification)
        {
            await _repository.CreateEvent(notification);
        }
    }
}
