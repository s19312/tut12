using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tut12.Models;

namespace tut12.Configuration
{
    public class ConfectioneryConfiguration : IEntityTypeConfiguration<Confectionery>
    {
        public void Configure(EntityTypeBuilder<Confectionery> builder)
        {
            builder.HasKey(e => e.IdConfectionery)
                  .HasName("Confectionery_pk");

            builder.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(200);

            builder.Property(e => e.PricePerItem)
                      .IsRequired();
            builder.Property(e => e.Type)
             .IsRequired().HasMaxLength(40);
        }
    }
}
