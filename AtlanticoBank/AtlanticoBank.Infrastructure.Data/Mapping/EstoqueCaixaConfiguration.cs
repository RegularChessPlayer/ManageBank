using AtlanticoBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticoBank.Infrastructure.Data.Mapping
{
    class EstoqueCaixaConfiguration : IEntityTypeConfiguration<EstoqueCaixa>
    {
        public void Configure(EntityTypeBuilder<EstoqueCaixa> builder)
        {
            builder.HasKey(ec => ec.Id);

            builder.Property(ec => ec.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(ec => ec.Cedula).HasColumnName("cedula").IsRequired();
            builder.Property(ec => ec.Qtd).HasColumnName("quantidade").IsRequired();

        }
    }
}
