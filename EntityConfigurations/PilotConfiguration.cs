using CompanhiaAerea.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CompanhiaAerea.EntityConfigurations
{
    public class PilotConfiguration : IEntityTypeConfiguration<Pilot>
    {
        public void Configure(EntityTypeBuilder<Pilot> builder)
        {
            builder.ToTable("Pilots");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Registration)
             .IsRequired()
             .HasMaxLength(10);

           builder.HasIndex(p => p.Registration)
                .IsUnique();
        }
    }
}
