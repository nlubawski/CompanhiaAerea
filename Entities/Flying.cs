namespace CompanhiaAerea.Entities
{
    public class Flying
    {
        public Flying(string origin, string destiny, DateTime departureTimeDate, DateTime arrivalTimeDate, int airplaneId, int pilotId)
        {
            Origin = origin;
            Destiny = destiny;
            DepartureTimeDate = departureTimeDate;
            ArrivalTimeDate = arrivalTimeDate;
            AirplaneId = airplaneId;
            PilotId = pilotId;
        }

        public int Id { get; set; }

        public string Origin { get; set; }

        public string Destiny { get; set; }

        public DateTime DepartureTimeDate { get; set; }

        public DateTime ArrivalTimeDate { get; set; }

        public int AirplaneId { get; set; }

        public int PilotId {  get; set; }

        public Airplane Airplane { get; set; } = null!;

        public Pilot Pilot { get; set; } = null!;

        public Cancellation? Cancellation { get; set; }

    }
}
