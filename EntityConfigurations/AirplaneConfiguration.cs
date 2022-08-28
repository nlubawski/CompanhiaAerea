using CompanhiaAerea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanhiaAerea.EntityConfigurations
{
    public class AirplaneConfiguration : IEntityTypeConfiguration<Airplane>
    {
        public void Configure(EntityTypeBuilder<Airplane> builder)
        {
            builder.ToTable("Airplanes");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Manufacturer)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Model)
             .IsRequired()
             .HasMaxLength(50);

            builder.Property(a => a.Code)
             .IsRequired()
             .HasMaxLength(10);

            //one airplane has many maintenances and foreing key is in maintenance AirplaneId
            builder.HasMany(a => a.Maintenances)
                .WithOne(m => m.Airplane)
                .HasForeignKey(m => m.AirlaneId); ;


        }
    }
}
