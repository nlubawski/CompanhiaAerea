namespace CompanhiaAerea.Entities
{
    public class Cancellation
    {
        public Cancellation(string reason, DateTime dateTimeNotification, int flyingId)
        {
            Reason = reason;
            DateTimeNotification = dateTimeNotification;
            FlyingId = flyingId;
        }

        public int Id {  get; set; }

        public string Reason { get; set; }

        public DateTime DateTimeNotification { get; set; }

        public int FlyingId { get; set; }

        public Flying Flying { get; set; } = null!;

    }
}
