using CompanhiaAerea.Entities;
using CompanhiaAerea.EntityConfigurations;
using CompanhiaAerea.EntityConfigurations.CompanhiaAerea.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CompanhiaAerea.Contexts
{
    public class AirlineContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AirlineContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Airplane> Airplanes => Set<Airplane>();
        public DbSet<Pilot> Pilots => Set<Pilot>();
        public DbSet<Flying> Flyings => Set<Flying>();
        public DbSet<Cancellation> Cancellations => Set<Cancellation>();
        public DbSet<Maintenance> Maintenances => Set<Maintenance>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Airline"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AirplaneConfiguration());
            modelBuilder.ApplyConfiguration(new PilotConfiguration());
            modelBuilder.ApplyConfiguration(new FlyingConfiguration());
            modelBuilder.ApplyConfiguration(new CancellationConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceConfiguration());
        }
    }
}
