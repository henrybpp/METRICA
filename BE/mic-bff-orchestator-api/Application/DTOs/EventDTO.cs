namespace mic_bff_orchestator_api.Application.DTO
{
    public class EventDTO
    {
        //public Guid Id { get; set; }
        public Guid MessageId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty;
        public string Lugar { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public EventDTO(string nombre, string fecha, string lugar, string estado)
        {
            Nombre = nombre;
            Fecha = fecha;
            Lugar = lugar;
            Estado = estado;
        }
    }
}
