using AtlanticoBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticoBank.Infrastructure.Data.Mapping
{
    public class CaixaConfiguration : IEntityTypeConfiguration<Caixa>
    {
        public void Configure(EntityTypeBuilder<Caixa> builder)
        {

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(c => c.Name).HasColumnName("nome").HasMaxLength(100);
            builder.Property(c => c.Active).HasColumnName("ativo").HasDefaultValue(true);
            builder.HasMany<EstoqueCaixa>(c => c.EstoqueCaixas)
                   .WithOne(ec => ec.Caixa)
                   .HasForeignKey(ec => ec.CaixaId);
        }
    }
}
