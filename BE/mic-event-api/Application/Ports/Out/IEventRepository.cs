namespace mic_event_api.Application.Ports.Out
{
    public interface IEventRepository
    {
        Task CreateEvent(Domain.Entities.Event evt);
    }
}
