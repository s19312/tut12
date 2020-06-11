using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut12.Models;

namespace tut12.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.IdEmployee)
              .HasName("Employee_pk");

        builder.Property(e => e.Name)
              .IsRequired()
              .HasMaxLength(50);

        builder.Property(e => e.Surname)
                  .IsRequired()
                  .HasMaxLength(60);
        }
    }
}
