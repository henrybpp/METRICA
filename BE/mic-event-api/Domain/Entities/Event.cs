namespace mic_event_api.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty;
        public string Lugar { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public Event(Guid id, string nombre, string fecha, string lugar, string estado)
        {
            Id = id;
            Nombre = nombre;
            Fecha = fecha;
            Lugar = lugar;
            Estado = estado;
        }
    }
}
