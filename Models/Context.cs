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
        public DbSet<Investidor> Investidores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Investimento> Investimento { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer(@"Server=CHRIS;Database=cidb;Integrated Security=True;");
        // }
    }
}