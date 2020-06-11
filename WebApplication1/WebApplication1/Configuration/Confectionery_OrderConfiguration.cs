using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configuration
{
    public class Confectionery_OrderConfiguration : IEntityTypeConfiguration<Confectionery_Order>
    {
        public void Configure(EntityTypeBuilder<Confectionery_Order> builder)
        {
            builder.HasKey(e => new { e.IdConfectionery, e.IdOrder});
            builder.Property(e => e.Quantity)
                     .IsRequired();

            builder.HasOne(e => e.IdConfectioneryNavigation).WithMany().HasForeignKey(e => e.IdConfectionery).HasConstraintName("idConfectionery");
            builder.HasOne(e => e.IdOrderNavigation).WithMany().HasForeignKey(e => e.IdOrder).HasConstraintName("idOrder");
            builder.Property(e => e.Notes).IsRequired().HasMaxLength(255).HasDefaultValue("None");
        }
    }
}
