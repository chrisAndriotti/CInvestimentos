using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CInvestimentos.Models
{
    public class Investimento : IEntity
    {
        public int Id { get; set; }
        public Acao Acao { get; set; }
        public double Valor { get; set; }
        public bool Ativo { get; set; }
    }
}