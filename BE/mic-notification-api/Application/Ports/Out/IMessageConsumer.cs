namespace mic_notification_api.Application.Ports.Out
{
    public interface IMessageConsumer
    {
        Task<String?> ConsumeAsync(CancellationToken cancellationToken);
    }
}
