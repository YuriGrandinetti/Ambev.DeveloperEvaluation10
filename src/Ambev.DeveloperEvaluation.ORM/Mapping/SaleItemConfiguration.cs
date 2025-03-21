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
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("ItensPedido");

            builder.HasKey(si => si.Id);

            builder.Property(si => si.Quantidade)
                   .IsRequired();

            builder.Property(si => si.PrecoUnitario)
                   .IsRequired()
                   .HasColumnType("numeric(10,2)");

            builder.Property(si => si.DescontoItem)
                   .HasColumnType("numeric(10,2)")
                   .HasDefaultValue(0);

            builder.Property(si => si.ValorTotalItem)
                   .IsRequired()
                   .HasColumnType("numeric(10,2)");

            builder.Property(si => si.Cancelado)
                   .IsRequired();

            // Configuração do relacionamento com Product
            builder.HasOne(si => si.Product)
                   .WithMany()   // ou .WithMany(p => p.SaleItems) se a entidade Product tiver essa coleção
                   .HasForeignKey(si => si.ProductId);
        }
    }
}
