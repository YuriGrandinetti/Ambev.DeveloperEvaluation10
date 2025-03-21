﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Codigo)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(p => p.Descricao)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(p => p.PrecoUnitario)
                   .IsRequired()
                   .HasColumnType("numeric(10,2)");
        }
    }
}
