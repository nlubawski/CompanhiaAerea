namespace CompanhiaAerea.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using global::CompanhiaAerea.Entities;

    namespace CompanhiaAerea.EntityConfigurations
    {
        public class FlyingConfiguration : IEntityTypeConfiguration<Flying>
        {
            public void Configure(EntityTypeBuilder<Flying> builder)
            {
                builder.ToTable("Flyings");

                builder.HasKey(v => v.Id);

                builder.Property(p => p.Origin)
                    .IsRequired()
                    .HasMaxLength(3);

                builder.Property(v => v.Destiny)
                 .IsRequired()
                 .HasMaxLength(3);

                builder.Property(v => v.DepartureTimeDate)
                    .IsRequired();


                builder.Property(v => v.ArrivalTimeDate)
                    .IsRequired();

                builder.HasOne(v => v.Pilot)
                    .WithMany(p => p.Flyings)
                    .HasForeignKey(p => p.PilotId);

                builder.HasOne(v => v.Airplane)
                    .WithMany(p => p.Flyings)
                    .HasForeignKey(v => v.AirplaneId);

                builder.HasOne(v => v.Cancellation)
                    .WithOne(c => c.Flying)
                    .HasForeignKey<Cancellation>(c => c.FlyingId);
            }
        }
    }

}
