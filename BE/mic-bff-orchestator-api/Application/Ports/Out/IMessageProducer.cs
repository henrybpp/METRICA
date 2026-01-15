// Application/Ports/Outbound/IMessageProducer.cs
namespace mic_bff_orchestator_api.Application.Ports.Out
{
    public interface IMessageProducer
    {
        Task ProduceAsync<T>(string topic, T message, CancellationToken cancellationToken);
    }
}

