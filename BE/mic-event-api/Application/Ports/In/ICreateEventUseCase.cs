using mic_event_api.Domain.Entities;

namespace mic_event_api.Application.Ports.In
{
    public interface ICreateEventUseCase
    {
        Task Execute(Event evt);
    }
}
