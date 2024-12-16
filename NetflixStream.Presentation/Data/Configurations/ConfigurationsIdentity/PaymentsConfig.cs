using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixStream.Domain.UserIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Persistence.Data.Configurations.ConfigurationsIdentity
{
    public class PaymentsConfig : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> entity)
        {
            entity.ToTable("Payments");

            entity.HasKey(P => P.PaymentId);
            // Configure the properties
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)").IsRequired();

            entity.Property(e => e.PaymentDate).IsRequired().HasDefaultValueSql("GETUTCDATE()"); // Use SQL Server function for default value

            entity.Property(e => e.TransactionId).HasMaxLength(100); // Optional: Specify max length if needed

            entity.HasOne(e => e.UserSubscription)
                .WithMany() // Assuming UserSubscriptions has no navigation property back to Payments
                .HasForeignKey(e => e.UserSubscriptionId)
                .OnDelete(DeleteBehavior.Cascade); // Specify delete behavior

            entity.HasOne(e => e.PaymentMethod)
                .WithMany() // Assuming PaymentMethod has no navigation property back to Payments
                .HasForeignKey(e => e.PaymentMethodid)
                .OnDelete(DeleteBehavior.Restrict); // Specify delete behavior
        }
    }
}
