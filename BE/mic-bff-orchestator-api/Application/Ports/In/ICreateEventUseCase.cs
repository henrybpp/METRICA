
using mic_bff_orchestator_api.Application.DTO;

namespace mic_bff_orchestator_api.Application.Ports.In
{
    public interface ICreateEventUseCase
    {
        Task HandleAsync(EventDTO dto, CancellationToken cancellationToken);
    }
}
