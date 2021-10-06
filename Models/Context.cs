using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CInvestimentos.Models
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        
        public DbSet<Acao> Acoes { get; set; }
        public DbSet<Investidor> Investidor { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Investimento> Investimentos { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        
    //     protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Investimento>()
    //         .HasOne(p => p.Investidor)
    //         .WithMany(b => b.Investimentos);
    // }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer(@"Server=CHRIS;Database=cidb;Integrated Security=True;");
        // }
    }
}