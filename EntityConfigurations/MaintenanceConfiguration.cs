using CompanhiaAerea.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CompanhiaAerea.EntityConfigurations
{
    public class MaintenanceConfiguration : IEntityTypeConfiguration<Maintenance>
    {
        public void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            builder.ToTable("Maintenances");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.CarriedOut)
                .IsRequired();

            builder.Property(m => m.Comments)
                .HasMaxLength(100);

            builder.Property(m => m.MaintenanceType)
             .IsRequired();
        }
    }
}
