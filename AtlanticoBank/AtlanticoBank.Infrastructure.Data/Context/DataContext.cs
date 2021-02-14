using AtlanticoBank.Domain.Entities;
using AtlanticoBank.Infrastructure.Data.Extensions;
using AtlanticoBank.Infrastructure.Data.Mapping;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace AtlanticoBank.Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Caixa> Caixa { get; set; }
        public DbSet<EstoqueCaixa> EstoqueCaixa { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CaixaConfiguration());
            modelBuilder.ApplyConfiguration(new EstoqueCaixaConfiguration());

            modelBuilder.Entity<Caixa>().HasData(
                new Caixa { Id = 100L,  Name = "A100", Active = true },    
                new Caixa { Id = 101L,  Name = "A101", Active = true }   
            );

            modelBuilder.Entity<EstoqueCaixa>().HasData(
                new EstoqueCaixa { Id = 200L, Cedula = 50, Qtd = 10 , CaixaId = 100L},
                new EstoqueCaixa { Id = 201L, Cedula = 20, Qtd = 20, CaixaId = 100L },
                new EstoqueCaixa { Id = 202L, Cedula = 10, Qtd = 30, CaixaId = 100L },
                new EstoqueCaixa { Id = 203L, Cedula = 5, Qtd = 40, CaixaId = 100L },
                new EstoqueCaixa { Id = 204L, Cedula = 2, Qtd = 50, CaixaId = 100L },

                new EstoqueCaixa { Id = 205L, Cedula = 50, Qtd = 10, CaixaId = 101L },
                new EstoqueCaixa { Id = 206L, Cedula = 20, Qtd = 20, CaixaId = 101L },
                new EstoqueCaixa { Id = 207L, Cedula = 10, Qtd = 30, CaixaId = 101L },
                new EstoqueCaixa { Id = 208L, Cedula = 5, Qtd = 40, CaixaId = 101L },
                new EstoqueCaixa { Id = 209L, Cedula = 2, Qtd = 50, CaixaId = 101L }

            );

            modelBuilder.LowercaseRelationalTableAndPropertyNames();
            modelBuilder.Ignore<Notification>();

        }

    }
}
