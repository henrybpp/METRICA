using mic_event_api.Application.Ports.Out;
using mic_event_api.Domain.Entities;

namespace mic_event_api.Infrastructure.Persistence.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateEvent(Event evt)
        {
            _context.Events.Add(evt);
            _context.SaveChanges();
        }
        /*
        public Pedido ObtenerPorId(int id)
        {
           return _context.Pedidos.FirstOrDefault(p => p.Id == id);
        }*/
    }
}
