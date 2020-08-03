using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCorrida.Models
{
    public class CorridaContext : DbContext
    {
        public DbSet<Corrida> Corridas { get; set; }
        public DbSet<Participante> Participantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=CorridaDB;Integrated Security=True");
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigCorrida(builder);
            base.OnModelCreating(builder);
        }

        private void ConfigCorrida(ModelBuilder builder)
        {
            builder.Entity<Corrida>(x =>
            {
                x.HasKey(c => c.Id);
            });

            builder.Entity<Participante>(x =>
            {
                x.HasKey(c => c.Id);
            });
        }
    }
}
