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
    // Configuração para a entidade Customer
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Codigo)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
