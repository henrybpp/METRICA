namespace mic_notification_api.Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string MessageId { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty;

        public Notification(Guid id, string messageId, string fecha)
        {
            Id = id;
            MessageId = messageId;
            Fecha = fecha;
        }
    }
}
