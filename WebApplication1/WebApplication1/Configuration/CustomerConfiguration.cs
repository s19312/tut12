using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.IdCustomer)
                  .HasName("Customer_pk");

            builder.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(e => e.Surname)
                      .IsRequired()
                      .HasMaxLength(60);
        }
    }
}
