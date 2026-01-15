namespace mic_event_api.Application.Ports.Out
{
    public interface IMessageConsumer
    {
        Task<String?> ConsumeAsync(CancellationToken cancellationToken);
    }
}
