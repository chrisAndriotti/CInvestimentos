using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CInvestimentos.Models
{
    public class Investimento : IEntity
    {
        public int Id { get; set; }
        public Acao Acao { get; set; }
        // public int AcaoId { get; set; }
        public double ValorTotal { get; set; }
        public bool Ativo { get; set; }
        public Investidor Investidor { get; set; }
    }
}