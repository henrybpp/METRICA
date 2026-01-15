using mic_notification_api.Domain.Entities;

namespace mic_notification_api.Application.Ports.In
{
    public interface INotificationUseCase
    {
        Task Execute(Notification notification);
    }
}
