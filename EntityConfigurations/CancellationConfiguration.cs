using CompanhiaAerea.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CompanhiaAerea.EntityConfigurations
{
    public class CancellationConfiguration : IEntityTypeConfiguration<Cancellation>
    {
        public void Configure(EntityTypeBuilder<Cancellation> builder)
        {
            builder.ToTable("Cancellations");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Reason)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.DateTimeNotification)
             .IsRequired();
        }
    }
}
