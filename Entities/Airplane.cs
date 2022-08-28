namespace CompanhiaAerea.Entities
{
    public class Airplane
    {
        public Airplane(string manufacturer, string model, string code)
        {
            Manufacturer = manufacturer;
            Model = model;
            Code = code;
        }

        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Code { get; set; }

        public ICollection<Maintenance> Maintenances { get; set; } = null!;

        public ICollection<Flying> Flyings { get; set; } = null!;

    }
}
