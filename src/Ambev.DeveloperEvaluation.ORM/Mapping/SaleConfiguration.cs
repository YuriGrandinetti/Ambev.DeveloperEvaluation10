using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.NumeroVenda)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(s => s.DataVenda)
                   .IsRequired();

            builder.Property(s => s.ValorTotalVenda)
                   .IsRequired()
                   .HasColumnType("numeric(10,2)");

            builder.HasOne(s => s.Customer)
         .WithMany()
         .HasForeignKey(s => s.CustomerId)
         .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Branch)
                   .WithMany()
                   .HasForeignKey(s => s.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
