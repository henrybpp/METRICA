using mic_event_api.Application.Ports.In;
using mic_event_api.Application.Ports.Out;
using mic_event_api.Domain.Entities;

namespace mic_event_api.Application.UseCases
{
    public class CreateEventUseCase : ICreateEventUseCase
    {
        private readonly IEventRepository _repository;

        public CreateEventUseCase(IEventRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Event evt)
        {
            await _repository.CreateEvent(evt);
        }
    }
}
