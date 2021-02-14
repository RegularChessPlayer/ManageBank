﻿// <auto-generated />
using System;
using AtlanticoBank.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AtlanticoBank.Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AtlanticoBank.Domain.Entities.Caixa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("ativo");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("caixa");

                    b.HasData(
                        new
                        {
                            Id = 100L,
                            Active = true,
                            Name = "A100"
                        },
                        new
                        {
                            Id = 101L,
                            Active = true,
                            Name = "A101"
                        });
                });

            modelBuilder.Entity("AtlanticoBank.Domain.Entities.EstoqueCaixa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("CaixaId")
                        .HasColumnType("bigint")
                        .HasColumnName("caixaid");

                    b.Property<int>("Cedula")
                        .HasColumnType("integer")
                        .HasColumnName("cedula");

                    b.Property<int>("Qtd")
                        .HasColumnType("integer")
                        .HasColumnName("quantidade");

                    b.HasKey("Id");

                    b.HasIndex("CaixaId");

                    b.ToTable("estoquecaixa");

                    b.HasData(
                        new
                        {
                            Id = 200L,
                            CaixaId = 100L,
                            Cedula = 50,
                            Qtd = 10
                        },
                        new
                        {
                            Id = 201L,
                            CaixaId = 100L,
                            Cedula = 20,
                            Qtd = 20
                        },
                        new
                        {
                            Id = 202L,
                            CaixaId = 100L,
                            Cedula = 10,
                            Qtd = 30
                        },
                        new
                        {
                            Id = 203L,
                            CaixaId = 100L,
                            Cedula = 5,
                            Qtd = 40
                        },
                        new
                        {
                            Id = 204L,
                            CaixaId = 100L,
                            Cedula = 2,
                            Qtd = 50
                        },
                        new
                        {
                            Id = 205L,
                            CaixaId = 101L,
                            Cedula = 50,
                            Qtd = 10
                        },
                        new
                        {
                            Id = 206L,
                            CaixaId = 101L,
                            Cedula = 20,
                            Qtd = 20
                        },
                        new
                        {
                            Id = 207L,
                            CaixaId = 101L,
                            Cedula = 10,
                            Qtd = 30
                        },
                        new
                        {
                            Id = 208L,
                            CaixaId = 101L,
                            Cedula = 5,
                            Qtd = 40
                        },
                        new
                        {
                            Id = 209L,
                            CaixaId = 101L,
                            Cedula = 2,
                            Qtd = 50
                        });
                });

            modelBuilder.Entity("AtlanticoBank.Domain.Entities.EstoqueCaixa", b =>
                {
                    b.HasOne("AtlanticoBank.Domain.Entities.Caixa", "Caixa")
                        .WithMany("EstoqueCaixas")
                        .HasForeignKey("CaixaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caixa");
                });

            modelBuilder.Entity("AtlanticoBank.Domain.Entities.Caixa", b =>
                {
                    b.Navigation("EstoqueCaixas");
                });
#pragma warning restore 612, 618
        }
    }
}