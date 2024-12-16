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
    public class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> entity)
        {
            entity.ToTable("PaymentMethods");

            entity.HasKey(PM => PM.PaymentMethodId);

            entity.Property(PM => PM.MethodName).IsRequired().HasMaxLength(50);

            entity.Property(PM => PM.IsActive).IsRequired();

            entity.Property(Pm => Pm.ProcessingFee).HasColumnType("decimal(18,2)").IsRequired();

            entity.HasMany(Pm => Pm.Payments).WithOne(PM => PM.PaymentMethod).HasForeignKey(FR => FR.PaymentMethodid);
        }
    }
}
