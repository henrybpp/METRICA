namespace mic_bff_orchestator_api.Application.DTO
{
    public class NotificationDTO
    {
        public string MessageId { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty;

        public NotificationDTO(string messageId, string fecha)
        {
            MessageId = messageId;
            Fecha = fecha;
        }
    }
}
