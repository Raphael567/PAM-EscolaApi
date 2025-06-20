using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EscolaApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Escola> TB_ESCOLA { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Escola>().HasKey(e => e.CodEscola);

            modelBuilder.Entity<Escola>().ToTable("TB_ESCOLA");

            Escola esc = new Escola();
            esc.CodEscola = "064";
            esc.CnpjEscola = "62.823.257/0064-84";
            esc.CepEscola = "12345-678";
            esc.NumEnderecoEscola = "113";
            esc.NomeEscola = "Etec Professor Horácio Augusto da Silveira";

            modelBuilder.Entity<Escola>().HasData(esc);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("Varchar").HaveMaxLength(200);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
    