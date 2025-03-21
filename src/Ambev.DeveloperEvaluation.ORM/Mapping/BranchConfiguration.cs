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
    // Configuração para a entidade Branch
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branch");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Codigo)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(b => b.Descricao)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
