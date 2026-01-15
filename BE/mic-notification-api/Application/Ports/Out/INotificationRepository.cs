namespace mic_notification_api.Application.Ports.Out
{
    public interface INotificationRepository
    {
        Task CreateEvent(Domain.Entities.Notification evt);
    }
}
