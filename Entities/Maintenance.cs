using CompanhiaAerea.Entities.Enums;

namespace CompanhiaAerea.Entities
{
    public class Maintenance
    {
        public Maintenance(DateTime carriedOut, MaintenanceType maintenanceType, int airlaneId, string? comments = null)
        {
            CarriedOut = carriedOut;
            Comments = comments;
            MaintenanceType = maintenanceType;
            AirlaneId = airlaneId;
        }

        public int Id { get; set; }

        public DateTime CarriedOut { get; set; }


        public string?  Comments { get; set; }

        public MaintenanceType MaintenanceType { get; set; }

        public int AirlaneId { get; set; }

        public Airplane Airplane { get; set; } = null!;

    }
}
